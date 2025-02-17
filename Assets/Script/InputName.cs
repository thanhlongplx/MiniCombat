using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections;
using Unity.VisualScripting;

public class InputFieldLogger : MonoBehaviour
{
    public InputField inputField1; // Tham chiếu đến InputField cho Player 1
    public InputField inputField2; // Tham chiếu đến InputField cho Player 2
    public TextMeshProUGUI namePlayer1; // TextMeshPro hiển thị tên Player 1
    public TextMeshProUGUI namePlayer2; // TextMeshPro hiển thị tên Player 2
    public GameObject namepannel;
    public GameObject pausePannel;
    public GameObject pauseButton;
    public String name1;
    public String name2;
    Health1 h1;
    Health2 h2;
    public GameObject Winpannel;
    public TextMeshProUGUI nameWinner1;
    public TextMeshProUGUI nameWinner2;
    ControlGamePlay ctrl;
    Player1 p1;
    Player2 p2;
    public GameObject player1;
    public GameObject player2;
    public bool canControl = true;

    void Start()
    {
        ctrl = FindObjectOfType<ControlGamePlay>();
        h1 = FindObjectOfType<Health1>();
        h2 = FindObjectOfType<Health2>();
        p1 = FindObjectOfType<Player1>();
        p2 = FindObjectOfType<Player2>();
    }

    void Update()
    {
        // Kiểm tra nếu nhấn phím Enter
        if (Input.GetKeyDown(KeyCode.Return))
        {

            // Lấy giá trị từ inputField1
            string inputValue1 = inputField1.text;

            if (namePlayer1 != null)
            {
                namePlayer1.text = inputValue1; // Cập nhật TextMeshPro cho Player 1
                name1 = inputValue1;

            }
            else
            {
                name1 = "Player 1";
            }


            // Lấy giá trị từ inputField2
            string inputValue2 = inputField2.text;
            if (namePlayer2 != null)
            {
                namePlayer2.text = inputValue2; // Cập nhật TextMeshPro cho Player 2
                name2 = inputValue2;
            }
            else
            {
                name2 = "Player 2";
            }

            // Tùy chọn: Xóa giá trị trong InputField

            namepannel.SetActive(false);
        }

        // Kiểm tra để thay the text cho winpannel
        if (h1.health <= 0)
        {
            h1.health = 0;


            // nameWinner1.SetText("Player " + name2 + " wins this round");
            p1.ani.SetTrigger("isDie");
            canControl = false;
            h1.health = 0;
            StartCoroutine(DieDelay1());


        }
        if (h2.health <= 0)
        {
            h2.health = 0;


            // nameWinner2.SetText("Player " + name1 + " wins this round");
            p2.anim.SetTrigger("isDie2");
            canControl = false;
            h2.health = 0;

            StartCoroutine(DieDelay2());
        }
    }
    IEnumerator DieDelay1()
    {
        // Đợi 1.5 giây trước khi ẩn player1
        yield return new WaitForSeconds(1.3f);

        // Ẩn player1
        player1.SetActive(false);
        yield return new WaitForSeconds(1f);
        Winpannel.SetActive(true);
    }
    IEnumerator DieDelay2()
    {
        // Đợi 1.5 giây trước khi ẩn player1
        yield return new WaitForSeconds(1.3f);

        // Ẩn player1
        player2.SetActive(false);
        yield return new WaitForSeconds(1f);
        Winpannel.SetActive(true);
    }
    public void showPausePannel(bool isShow){
        pausePannel.SetActive(isShow);
        pauseButton.SetActive(!isShow);
    }
}