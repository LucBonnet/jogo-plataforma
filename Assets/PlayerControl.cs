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
    private float speed = 5f;
    private Rigidbody2D rb2d;
    private Vector2 moveDirection;
    private Animator anime;
    private SpriteRenderer sprRend;
    int count =0;
    private bool jumpping = false;
    private bool shooting = false;
    private bool dashing = false;
    private GameObject plataforma;
    private GameObject plataforma2;
    
    public void PlayerAnimation(string animationName){
        anime.Play(animationName);
    }

    // Start is called before the first frame update
    void Start()
    {   
        
        plataforma = GameObject.FindGameObjectWithTag("Plataforma"); 
        plataforma2 = GameObject.FindGameObjectWithTag("Plataforma2"); 
        anime = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        sprRend = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.CompareTag("Chao") || col.gameObject.CompareTag("Plataforma") || col.gameObject.CompareTag("Plataforma2")) {
            jumpping = false;
        }
    }

    void OnTriggerEnter2D (Collider2D hitInfo) {
        
        if(hitInfo.gameObject.CompareTag("Plataformabaixo")) {
            plataforma.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            plataforma2.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
        else if(hitInfo.gameObject.CompareTag("Plataformacima")) {
            plataforma.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            plataforma2.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }


    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Space) && !jumpping)
        {
            jumpping = true;
            rb2d.AddForce(new Vector2(0, 8), ForceMode2D.Impulse);
        } else if (Input.GetKey(moveRight)){
            count =1;
        } else if (Input.GetKey(moveLeft)){       
            count =0;         
        }
        else if (Input.GetKeyDown(atirar) && !shooting)
        {
            shooting =true;
            StartCoroutine(Wait("atirarE"));
            
        }
        else if (Input.GetKeyDown(dash) && !dashing)
        {
            dashing =true;
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
            yield return new WaitForSeconds(clips[index].length-0.7f);
            if(nome == "atirarE"){
                shooting= false;
            }
            else if(nome == "DashE"){
                dashing= false;
            }
                    
    }
    


    private void FixedUpdate()
    { 

        float horizontal = Input.GetAxisRaw("Horizontal");
        moveDirection = new Vector2(horizontal * speed, rb2d.velocity.y);
        rb2d.velocity = moveDirection;
        if(Input.GetKey(KeyCode.Space) && jumpping){
            if(count ==1){
                PlayerAnimation("Pular");
            }
            else if(count ==0){
                PlayerAnimation("PularE");
            }
            
        }else if(Input.GetKey(moveRight) && !jumpping){
            PlayerAnimation("CorrerD");
            
        }
        else if(Input.GetKey(moveLeft) && !jumpping){
            PlayerAnimation("CorrerE");
        }
        else if(Input.GetKey(atirar) && shooting && !jumpping && !dashing){
            if(count ==1){
                PlayerAnimation("atirarD");
            }
            else if(count ==0){
                PlayerAnimation("atirarE");
            }           
        }
        else if(Input.GetKey(dash) && dashing && !jumpping && !shooting){
            if(count ==1){
                PlayerAnimation("DashD");
            }
            else if(count ==0){
                PlayerAnimation("DashE");
            }            
        }
        else if(!jumpping && !shooting && !dashing){
            PlayerAnimation("Parado");
        }
        
    }
}
