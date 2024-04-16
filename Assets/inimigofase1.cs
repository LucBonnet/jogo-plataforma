using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;
using System.Collections.Generic;

public class inimigofase1 : MonoBehaviour
{
    public float velocidade = 5f;
    public Tilemap tilemap;
    private Collider2D colliderInimigo;
    private bool indoParaDireita = true;
    public float health = 10f;
    public bool isDead = false;
    public Animator animator;
    GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); 
        animator = GetComponent<Animator>();
        colliderInimigo = GetComponent<Collider2D>();
    }


    void OnTriggerEnter2D (Collider2D hitInfo) {
        
        if (hitInfo.CompareTag("pareded")){
           indoParaDireita = false;
           Flip();
    	}

        if (hitInfo.CompareTag("paredee")){
            indoParaDireita = true;
            Flip();
    	}
    }

    void OnCollisionEnter2D (Collision2D coll) {
    	if(coll.collider.CompareTag("Player")){
			PlayerControl.SubVida();
    	}
	}

    public IEnumerator DestroyGameObject(float damage) {
        health -= damage;
        if(health <= 0) {
            AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
            colliderInimigo.enabled = false;
            isDead = true;
            animator.Play("morteInimigo");
            int index = 0;
            for(int i = 0; i < clips.Length; i++){
                if(clips[i].name == "morteInimigo") {
                    index = i;
                    break;
                }
            }
            yield return new WaitForSeconds(clips[index].length);
            Destroy(gameObject);
        }
    }

    void Flip ()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    private void Update()
    {
        // Move o inimigo na direção atual
        Vector3 movimento = indoParaDireita ? Vector3.right : Vector3.left;
        transform.Translate(movimento * velocidade * Time.deltaTime);
    }
}