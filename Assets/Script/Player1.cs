using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public AudioSource audioSource; // Tham chiếu đến AudioSource
    public AudioClip soundClip1; // Tham chiếu đến AudioClip
    public AudioClip soundClip2; // Tham chiếu đến AudioClip
    private float speed = 10f;
    public float direction;
    private float jumpForce = 10f;
    public float directionJump;
    private bool isRight = true;
    private bool isGrounded;
    private float d;


    private Rigidbody2D rb;
    public GameObject ata;
    ControlGamePlay ctrl;
    public Animator ani; // Tham chiếu Animator
    InputFieldLogger inp;
    void Start()
    {
        ctrl = FindObjectOfType<ControlGamePlay>();
        // Không cần tìm kiếm Animator nữa
        rb = FindObjectOfType<Rigidbody2D>();
        inp = FindObjectOfType<InputFieldLogger>();
    }

    void Update()
    {
        // Di chuyển trái phải
        if (inp.canControl)
        {
            if (Input.GetKey(KeyCode.A))
            {
                direction = -1;
                d = direction;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                direction = 1;
                d = direction;
            }
            else
            {
                direction = 0;
                d = 0.001f;
            }
            // Nhảy
            if (Input.GetKey(KeyCode.W) && isGrounded)
            {
                Jump();
            }
        







        if (Input.GetKeyDown(KeyCode.F))
        {
            att1();
            PlayOneShot1();

            transform.position = new Vector3(transform.position.x + (d / 1.5f), transform.position.y, transform.position.z);


            StartCoroutine(AttackDelay());
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            att2();
            PlayOneShot1();

            transform.position = new Vector3(transform.position.x + (d / 1.5f), transform.position.y, transform.position.z);


            StartCoroutine(AttackDelay());


        }

        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
        Flip();

        if (Mathf.Abs(direction) > 0)
        {
            ani.SetBool("isRun", true);
        }
        else
        {
            ani.SetBool("isRun", false);
        }
        }
    }
    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        ani.SetTrigger("isJump");

        isGrounded = false; // Đặt trạng thái là không còn trên mặt đất
        ani.SetBool("isGround", isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Đặt trạng thái là đang trên mặt đất
            ani.SetBool("isGround", isGrounded);
        }
    }


    void Flip()
    {
        if ((isRight && direction < 0) || (!isRight && direction > 0))
        {
            isRight = !isRight;
            Vector3 flipx = transform.localScale;
            flipx.x *= -1;
            transform.localScale = flipx;
        }
    }

    IEnumerator AttackDelay()
    {
        // Đợi 1 giây (hoặc thời gian bạn muốn)
        yield return new WaitForSeconds(0.3f);

        ata.SetActive(false); // Tắt đối tượng tấn công
    }
    void PlayOneShot1()
    {
        // Phát âm thanh one shot
        audioSource.PlayOneShot(soundClip1);
    }
    void PlayOneShot2()
    {
        // Phát âm thanh one shot
        audioSource.PlayOneShot(soundClip2);
    }
    void att1()
    {
        ani.SetTrigger("Attack");
        ata.SetActive(true);
    }
    void att2()
    {
        ani.SetTrigger("Attackp1_2");
        ata.SetActive(true);
    }

}