using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public static float paddleSpeed = 1.5f;  // Velocidade inicial do Boss
    GameObject Player;
    public BoxCollider2D bc2d;
    public Animator animator;
    public static bool facingRight = true;
    public float horizontal;
    public static float posX;
    public static float posY;
    public GameObject square;
    public static float health = 100f;

    public static void SubVida(){
        health--;
    }
    // Start is called before the first frame update
    void Start()
    {
       Player = GameObject.FindGameObjectWithTag("Player"); 
       animator = GetComponent<Animator>();
       bc2d = GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = (Player != null) ? Vector2.Distance(transform.position, Player.transform.position) : float.MaxValue;
        if(distanceToPlayer <=1.5f){
            animator.Play("ataqueBoss");
            Instantiate(square, this.transform.position, Quaternion.identity);
        }
        if (Player != null && distanceToPlayer >1.5f)
    {
        animator.Play("moverBoss");
        // Move a raquete da IA em direção à posição Y da bola ativa
        Transform paddleTransform = transform;
        float step = Boss.paddleSpeed * Time.deltaTime;
        Vector2 targetPosition = new Vector2(Player.transform.position.x, Player.transform.position.y);
        horizontal = Player.transform.position.x;
        paddleTransform.position = Vector2.MoveTowards(paddleTransform.position, targetPosition, step);
        posX = paddleTransform.position.x;
        posY = paddleTransform.position.y;
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
        if(health ==0){
            animator.Play("morteBoss");
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
