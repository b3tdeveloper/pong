using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    public float speed = 10f;
    public Score score;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        Invoke("MoveBall", 2);
    }

    // Update is called once per frame
    void Update()
    {

    }

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
        ResetBall();
        Invoke("MoveBall", 2);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = rigidbody2d.velocity.x;
            vel.y = (2 * rigidbody2d.velocity.y / 3) + (coll.collider.attachedRigidbody.velocity.y / 3);
            rigidbody2d.velocity = vel;
        }
        if (coll.collider.CompareTag("EdgeWall") & score.isClap == false)
        {
            
            
            RestartGame();
            
        }
    }
}
