using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health2 : MonoBehaviour
{
    public int health = 100;
    private Player1 p1;
    private Player2 p2;
    InputFieldLogger n;
    public TextMeshProUGUI heart2;
    public GameObject namePannel;

    public TextMeshProUGUI nameWiner; // TextMeshPro for displaying Player 1's name
    public GameObject Winpannel;

    void Start()
    {
        n = FindObjectOfType<InputFieldLogger>();
        p1 = GameObject.Find("Player1").GetComponent<Player1>();
        p2 = GameObject.Find("Player2").GetComponent<Player2>();
        

        // Ensure nameWiner is assigned in the Inspector instead of finding it here
        // nameWiner = FindObjectOfType<TextMeshProUGUI>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("AttackArea1"))
        {
            if (health > 0)
            {
                healthDecr();
                
                heart2.text = health.ToString();
                Vector3 newPosition = transform.position;
                newPosition.x += p1.direction / 2;
                transform.position = newPosition;
                Debug.Log("Health of Player 2: " + health);
                
                if (health <= 0)
                {

                    health = 0;
                    if (n != null)
                    {
                        
                        nameWiner.SetText("Player " + n.name1 + " wins this round");
                    }
                    
                    
                }
            }
        }
    }
    void healthDecr(){
        health -= 5;
        p2.anim.SetTrigger("isAttacked");
    }
}