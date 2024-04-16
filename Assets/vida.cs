using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vida : MonoBehaviour
{
    public float vidas =10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D (Collider2D hitInfo) {
        if (hitInfo.CompareTag("Player")){
            PlayerControl.health += vidas;
            Destroy(gameObject);				
            
    	}
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
