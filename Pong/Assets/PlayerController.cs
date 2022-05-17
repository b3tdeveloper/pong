using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isPlayer1;
    public Rigidbody2D rigidbody;
    public float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isPlayer1)
        {
            rigidbody.velocity = Vector2.up * speed * Input.GetAxisRaw("Vertical1");
        }
        else
        {
            rigidbody.velocity = Vector2.up * speed * Input.GetAxisRaw("Vertical2");
        }
    }
}
