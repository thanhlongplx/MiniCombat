using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health1 : MonoBehaviour
{

    public int health = 100;
    public GameObject Winpannel;
    public TextMeshProUGUI nameWinner1;
    public GameObject namePannel;
    public TextMeshProUGUI heart1;

    InputFieldLogger n;
    public TextMeshProUGUI nameWiner;

    private Player2 p2;
    private Player1 p1;

    void Start()
    {
        p2 = GameObject.Find("Player2").GetComponent<Player2>();
        p1 = GameObject.Find("Player1").GetComponent<Player1>();
        n = FindObjectOfType<InputFieldLogger>();
    }

    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("AttackArea2"))
        {
            healthDecr();
            
            heart1.text = health.ToString();
            Vector3 newPosition = transform.position;
            newPosition.x += p2.direction / 2;
            transform.position = newPosition;
            Debug.Log("Health of Player 1: " + health);


            if (health <= 0)
            {
                p1.ani.SetTrigger("isDie");
                health = 0;
                if (n != null)
                {

                    nameWiner.SetText("Player " + n.name2 + " wins this round");
                }
                else
                {
                    Debug.LogWarning("InputFieldLogger not found!");
                }



            }

        }
    }
    void healthDecr(){
        health -= 5;
        p1.ani.SetTrigger("isHited");
    }

}
