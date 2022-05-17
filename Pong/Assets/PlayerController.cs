using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isPlayer1;
    private Rigidbody2D rigidbody2d;
    private float speed = 7f;
    private float boundY = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isPlayer1)
        {
            rigidbody2d.velocity = Vector2.up * speed * Input.GetAxisRaw("Vertical1");
        }
        else
        {
            rigidbody2d.velocity = Vector2.up * speed * Input.GetAxisRaw("Vertical2");
        }

        var pos = transform.position;
        if (pos.y > boundY)
        {
            pos.y = boundY;
        }
        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
        }
        transform.position = pos;
    }
}
