using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControl : MonoBehaviour
{
    bool isRight = true;
    private Rigidbody2D rb2d;
    public float speed = 0.5f;
    public float damage = 10f;


    // Start is called before the first frame update
    void Start()
    {
        isRight = PlayerControl.isRight;
        if(isRight){
            rb2d = GetComponent<Rigidbody2D>();
            var vel = rb2d.velocity;
            vel.x += speed;
            rb2d.velocity = vel;
        }
        else{
            rb2d = GetComponent<Rigidbody2D>();
            var vel = rb2d.velocity;
            vel.x -= speed;
            rb2d.velocity = vel;
        }
        
    }

    void OnTriggerEnter2D (Collider2D hitInfo) {
        
        if (hitInfo.CompareTag("Inimigo")){
            Destroy(gameObject);				
            hitInfo.gameObject.SendMessage("DestroyGameObject", damage, SendMessageOptions.RequireReceiver); 
            GameManager.pont +=10;           
    	}

        if (hitInfo.CompareTag("Boss")){
            Destroy(gameObject);				
            Boss.SubVida();
            GameManager.pont +=1;
    	}
    }


    
    // Update is called once per frame
    void Update()
    {
        // var vel = rb2d.velocity;
        // vel.x += speed;
        // rb2d.velocity = vel;
        
    }
}
