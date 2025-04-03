using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float speed = 10f;
    public float direction;
    private bool isRight = false;
    public Animator anim;
    private float jumpForce = 10f;
    public bool isGrounded;
    public GameObject ata;
    public AudioSource audioSource; // Tham chiếu đến AudioSource
    public AudioClip soundClip1; // Tham chiếu đến AudioClip
    public AudioClip soundClip2; // Tham chiếu đến AudioClip
    ControlGamePlay ctrl;
    public Rigidbody2D rb;
    float d;
    public InputFieldLogger inp;

    void Start()
    {
        ctrl = FindObjectOfType<ControlGamePlay>();
        
    }
    void Update()
    {
        if(inp.canControl){
            if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = -1;
            d = direction;

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = 1;
            d = direction;
        }
        else
        {
            direction = 0;
            d = 0.001f;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            Jump();
        }


        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            att1();
            PlayOneShot1();

            transform.position = new Vector3(transform.position.x + (d / 1.5f), transform.position.y, transform.position.z);


            StartCoroutine(AttackDelay());//delay sau đó setAtive  false

        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            att2();
            PlayOneShot1();

            transform.position = new Vector3(transform.position.x + (d / 1.5f), transform.position.y, transform.position.z);


            StartCoroutine(AttackDelay());//delay sau đó setAtive  false

        }
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
        Flip();
        if (Mathf.Abs(direction) > 0)
        {
            anim.SetBool("isRun2", true);
        }
        else
        {
            anim.SetBool("isRun2", false);
        }
        }
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Đặt trạng thái là đang trên mặt đất
            anim.SetBool("isGround", isGrounded);
        }
    }
    void Flip()
    {
        if ((!isRight && direction > 0) || (isRight && direction < 0))
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
        anim.SetTrigger("Attackp2");
        ata.SetActive(true);
    }
    void att2()
    {
        anim.SetTrigger("Attackp2_2");
        ata.SetActive(true);
    }
    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        anim.SetTrigger("isJump");

        isGrounded = false; // Đặt trạng thái là không còn trên mặt đất
        anim.SetBool("isGround", isGrounded);
    }
}
