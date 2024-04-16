using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataqueBoss : MonoBehaviour
{
    bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        isRight = Boss.facingRight;
        if(isRight){
            transform.position = new Vector3(Boss.posX+1.1f, Boss.posY, 0);
        }
        else{
            transform.position = new Vector3(Boss.posX-1.1f, Boss.posY, 0);
        }
        
        Destroy(gameObject, 0.017f); 
    }

    void OnTriggerEnter2D (Collider2D hitInfo) {      
        if (hitInfo.CompareTag("Player")){
            PlayerControl.SubVida();			                       
    	}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
