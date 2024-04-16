using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public static float paddleSpeed = 2f;  // Velocidade inicial do Boss
    public float health = 10f;
    GameObject Player;
    Vector2 startPosition;
    public PolygonCollider2D bc2d;
    public Animator animator;
    public bool facingRight = true;
    public bool isDead = false;
    public float horizontal;
    public float posX;
    // Start is called before the first frame update
    void Start()
    {
       startPosition = transform.position;
       Player = GameObject.FindGameObjectWithTag("Player"); 
       animator = GetComponent<Animator>();
       bc2d = GetComponent<PolygonCollider2D>();
    }

    void OnTriggerEnter2D (Collider2D hitInfo) {
        if (hitInfo.CompareTag("Player")){
            PlayerControl.SubVida();				
            
    	}
    }
    public IEnumerator DestroyGameObject(float damage) {
        health -= damage;
        if(health <= 0) {
            AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
            bc2d.enabled = false;
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
            transform.position = startPosition;
            yield return new WaitForSeconds(5f);
            isDead = false;
            bc2d.enabled = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = (Player != null) ? Vector2.Distance(transform.position, Player.transform.position) : float.MaxValue;
        if (Player != null)
    {
        // Move a raquete da IA em direção à posição Y da bola ativa
        if(!isDead){
            animator.Play("movendoInimigo");
            Transform paddleTransform = transform;
            float step = Inimigo.paddleSpeed * Time.deltaTime;
            Vector2 targetPosition = new Vector2(Player.transform.position.x, Player.transform.position.y);
            horizontal = Player.transform.position.x;
            paddleTransform.position = Vector2.MoveTowards(paddleTransform.position, targetPosition, step);
            posX = paddleTransform.position.x;
        }
        
    }

    
    
        
    }

    
    private void FixedUpdate()
    { 
        if(horizontal > posX && !facingRight){
            Flip();
        }
        else if(horizontal < posX && facingRight){
            Flip();
        }
        
    }

    void Flip ()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
