using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        var vel = rb2d.velocity;
        vel.x += speed;
        rb2d.velocity = vel;
    }

    // Update is called once per frame
    void Update()
    {
        // var vel = rb2d.velocity;
        // vel.x += speed;
        // rb2d.velocity = vel;
        
    }
}
