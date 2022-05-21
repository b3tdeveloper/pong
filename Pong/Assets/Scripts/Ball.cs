using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    [SerializeField] private float speed = 3;
    public Score score;

    private int counter;

    public ParticleSystem explosion;
    public ParticleSystem dead;

    [Header("Audio Parameters")]
    [SerializeField] private AudioClip player1hitSound;
    [SerializeField] private AudioClip player2hitSound;
    [SerializeField] private AudioClip deadSound;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        //Call the move ball function 2 seconds after the game starts.
        Invoke("MoveBall", 2);

        //Stop playing the particle effect.
        explosion.Stop();
        dead.Stop();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Initially move the ball in a random direction. The ball can go just 4 direction, these are corners.
    public void MoveBall()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rigidbody2d.velocity = new Vector2(x * speed, y * speed);
    }

    void ResetBall()
    {
        rigidbody2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }
    void RestartGame(){
        //Reset ball position and velocity.
        ResetBall();
        gameObject.GetComponent<TrailRenderer>().enabled = true;
        //Call this function after 2 second when the reset ball called. 
        Invoke("MoveBall", 2);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            //Add player's velocity to ball
            Vector2 vel;
            vel.x = rigidbody2d.velocity.x;
            vel.y = (2 * rigidbody2d.velocity.y / 3) + (coll.collider.attachedRigidbody.velocity.y / 3);
            rigidbody2d.velocity = vel;

            PlayerAudio();

            //When the ball hit the player, play particle effect.
            explosion.Play();

            // Add Difficulty
            counter++;
            Debug.Log(counter);
            SetDifficulty();
        }
        //When the ball collide with left/right walls and if someone didn't win, restart game.
        if (coll.collider.CompareTag("EdgeWall") & score.isClap == false)
        {
            rigidbody2d.velocity = new Vector2(0,0);
            SoundManager.instance.PlaySound(deadSound);
            dead.Play();
            gameObject.GetComponent<TrailRenderer>().enabled = false;
            Invoke("RestartGame", 2f);
            //RestartGame();
            
        }
    }

    void PlayerAudio()
    {
        if (counter%2==0)
        {
            SoundManager.instance.PlaySound(player1hitSound);
        }
        else if (counter%2==1)
        {
            SoundManager.instance.PlaySound(player2hitSound);
        }
    }

    void SetDifficulty()
    {
        if (counter == 2)
        {
            speed = 5;
            rigidbody2d.velocity = new Vector2(speed, speed);
        }
        else if (counter == 6)
        {
            speed = 6;
            rigidbody2d.velocity = new Vector2(speed, speed);
        }
        else if (counter == 8)
        {
            speed = 7;
            rigidbody2d.velocity = new Vector2(speed, speed);
        }
        else if (counter == 10)
        {
            speed = 9;
            rigidbody2d.velocity = new Vector2(speed, speed);
        }
        else if (counter == 16)
        {
            speed = 10;
            rigidbody2d.velocity = new Vector2(speed, speed);
        }
        else if (counter == 25)
        {
            speed = 11;
            rigidbody2d.velocity = new Vector2(speed, speed);
        }
        else if (counter == 35)
        {
            speed = 12;
            rigidbody2d.velocity = new Vector2(speed, speed);
        }
        else if (counter == 50)
        {
            speed = 15;
            rigidbody2d.velocity = new Vector2(speed, speed);
        }
        else if (counter == 100)
        {
            speed = 19;
            rigidbody2d.velocity = new Vector2(speed, speed);
        }
    }
}
