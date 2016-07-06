using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BallScript : MonoBehaviour
{
    public float speed = 30;
    public Text BlueScore;
    public Text GreenScore;

    public int lastBlueScore = 0;
    public int lastGreenScore = 0;

    // Use this for initialization
    void Start()
    {
        //initial velocity
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        BlueScore.text = lastBlueScore.ToString();
        GreenScore.text = lastGreenScore.ToString();
    }
    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.y - racketPos.y) / racketHeight;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        // Note: 'col' holds the collision information. If the
        // Ball collided with a racket, then:
        //   col.gameObject is the racket
        //   col.transform.position is the racket's position
        //   col.collider is the racket's collider

        // Hit the left Racket?
        if (col.gameObject.name == "PongRacketLeft")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        // Hit the right Racket?
        if (col.gameObject.name == "PongRacketRight")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;
            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;

        }

        if (col.gameObject.name == "5inchPongWallHorizontalRight")
        {            
                lastBlueScore = lastBlueScore + 1;
                BlueScore.text = lastBlueScore.ToString();                       
        }
        if (col.gameObject.name == "5inchPongWallHorizontalLeft")
        {
            lastGreenScore = lastGreenScore + 1;
            GreenScore.text = lastGreenScore.ToString();
        }
    }
}
