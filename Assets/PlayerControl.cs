using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{   
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode jump = KeyCode.Space;
    public KeyCode atirar = KeyCode.E;
    public KeyCode dash = KeyCode.Q;
    public GameObject Arrow;
    private float speed = 5f;
    public static float health = 100f;
    private Rigidbody2D rb2d;
    private Vector2 moveDirection;
    private Animator anime;
    private SpriteRenderer sprRend;
    public static bool isRight = true;
    private bool jumpping = false;
    private bool dashing = false;
    private bool chargingShoot = false;
    private bool keepingShot = false;
    private bool shooting = false;
 
    
    public void PlayerAnimation(string animationName){
        anime.Play(animationName);
    }
    public static void SubVida(){
        health--;
    }

    // Start is called before the first frame update
    void Start()
    {   
        anime = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        sprRend = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.CompareTag("Chao") || col.gameObject.CompareTag("Plataforma")) {
            jumpping = false;
        }
    }
    
        
    

    void Shoot() {
        Instantiate(Arrow, transform.position, Quaternion.identity);
        chargingShoot = false;
        keepingShot = false;
        shooting = false;
    }

    // Update is called once per frame
    void Update()
    {  
        Debug.Log(health); 
        if (Input.GetKeyDown(KeyCode.Space) && !jumpping)
        {
            jumpping = true;
            rb2d.AddForce(new Vector2(0, 8), ForceMode2D.Impulse);
        } else if (Input.GetKey(moveRight)){
            isRight = true;
        } else if (Input.GetKey(moveLeft)){       
            isRight = false;         
        }
        else if (Input.GetKeyDown(atirar))
        { 
            chargingShoot = true;
            PlayerAnimation("CarregandoArco"); 
            StartCoroutine(Wait("CarregandoArco"));
        } else if (Input.GetKey(atirar)) {
            if(!chargingShoot) {
                keepingShot = true;
                PlayerAnimation("SegurandoTiro");
            }
        }
        else if (Input.GetKeyUp(atirar)) {
            chargingShoot = false;
            keepingShot = false;
            shooting = true;
            PlayerAnimation("Atirar");
            Shoot();
            StartCoroutine(Wait("Atirar"));
        }
        else if (Input.GetKeyDown(dash) && !dashing)
        {
            dashing = true;
            StartCoroutine(Wait("DashE"));
            
        }
    }

    public IEnumerator Wait(string nome) {
        
        AnimationClip[] clips = anime.runtimeAnimatorController.animationClips;
            int index = 0;
            for(int i = 0; i < clips.Length; i++){
                if(clips[i].name == nome) {
                    index = i;
                    break;
                }
            }
            yield return new WaitForSeconds(clips[index].length);
            if(nome.Equals("Atirar")){
                shooting = false;
                chargingShoot= false;
                keepingShot = false;
            }else if(nome.Equals("CarregandoArco")){
                chargingShoot= false;
                keepingShot = true;
            }
            else if(nome.Equals("DashE")){
                dashing= false;
            }
                    
    }
    


    private void FixedUpdate()
    { 

        sprRend.flipX = !isRight;

        float horizontal = Input.GetAxisRaw("Horizontal");
        moveDirection = new Vector2(horizontal * speed, rb2d.velocity.y);
        rb2d.velocity = moveDirection;
        if(Input.GetKey(KeyCode.Space) && jumpping){
    
            PlayerAnimation("Pular");
        }else if(Input.GetKey(moveRight) && !jumpping){
            Parallax.movingSpeed  =2f;
            Parallax1.movingSpeed =4f;
            Parallax2.movingSpeed =6f;
           
            PlayerAnimation("CorrerD");
        }
        
        else if(Input.GetKey(moveLeft) && !jumpping){
            Parallax.movingSpeed  =-2f;
            Parallax1.movingSpeed =-4f;
            Parallax2.movingSpeed =-6f;
          
            PlayerAnimation("CorrerD");
        }
        else if(!jumpping && !shooting && !dashing && !keepingShot && !chargingShoot){
            Parallax.movingSpeed  =0f;
            Parallax1.movingSpeed =0f;
            Parallax2.movingSpeed =0f;
            PlayerAnimation("Parado");
        }
        
    }
}
