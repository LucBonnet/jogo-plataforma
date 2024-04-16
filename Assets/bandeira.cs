using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bandeira : MonoBehaviour
{

    public GUISkin layout;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D (Collision2D coll) {
    	if(coll.collider.CompareTag("Player")){
			GameManager.conseguiu =true;
    	}
        else{
           GameManager.conseguiu =false; 
        }
	}

    void OnGUI () {
        if(GameManager.conseguiu){
            GUI.Label(new Rect(Screen.width / 2 - 180 - 12, 280, 600, 600), "APERTE T PARA AVANCAR");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
