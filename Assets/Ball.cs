using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody2D rb2D;
    public Vector2 Vel;
    public int leftPlayerScor = 0;
    public int rightPlayerScor = 0;
    public TextMeshProUGUI lefPlayerText;
    public TextMeshProUGUI rightPlayerText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        ResetBall();
        SendBallToRandomDirection();
        lefPlayerText.text = "0";
        rightPlayerText.text = "0";
    }

    private void Update()
    {
        if (rb2D.velocity.magnitude < .1f && Input.GetKeyUp(KeyCode.Space)) 
        {
                SendBallToRandomDirection();
            }
        
    }

    private void ResetBall()
    {
        rb2D.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    private void SendBallToRandomDirection()
    {
  rb2D.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * speed;
        Vel = rb2D.velocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb2D.velocity = Vector2.Reflect(Vel, collision.contacts[0].normal);
        Vel = rb2D.velocity;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.position.x < 0)
            rightPlayerScor += 1;
        {
            
        }
            
        {
            

            if (transform.position.x > 0)
                leftPlayerScor += 1;
            
            lefPlayerText.text = leftPlayerScor.ToString();
            rightPlayerText.text = rightPlayerScor.ToString();
            ResetBall();
            //SendBallToRandomDirection(); 
        }
    }
}
