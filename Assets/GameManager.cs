using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static float pont;
    public GUISkin layout;
    public KeyCode sair = KeyCode.T;
    public static bool conseguiu = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnGUI () {
    Scene scene = SceneManager.GetActiveScene();
    if(Boss.health ==0){
        if (scene.name == "fase2"){
        SceneManager.LoadScene("vitoria");
        }
    }
    if(PlayerControl.health <=0){
        if (scene.name == "fase2" ||scene.name == "fase1" ){
        SceneManager.LoadScene("derrota");
        }
    }


    
    GUI.skin = layout;
    if(scene.name != "vitoria" && scene.name != "derrota" && scene.name != "tutorial"){
        GUI.Label(new Rect(Screen.width / 2 - 360 - 12, 15, 100, 100), " "+ PlayerControl.health);
        if(scene.name == "fase2"){
            GUI.Label(new Rect(Screen.width / 2 + 180 - 12, 15, 100, 100), " "+ Boss.health);
        }      
        GUI.Label(new Rect(Screen.width / 2 - 100 - 12, 15, 200, 200), "PONTUACAO: " + pont);
    }
    if(scene.name == "vitoria" || scene.name == "derrota"){
        GUI.Label(new Rect(Screen.width / 2 - 180 - 12, 250, 200, 200), "PONTUACAO: " + pont);
        GUI.Label(new Rect(Screen.width / 2 - 180 - 12, 280, 600, 600), "APERTE T PARA RECOMECAR");
       
    }
    if(conseguiu){
        if(scene.name == "fase1"){
        if(Input.GetKey(sair)){   
            SceneManager.LoadScene("fase2");
            conseguiu =false;
        }
    }
    }

    
    if(scene.name == "vitoria" || scene.name == "derrota"){
        if(Input.GetKey(sair)){   
            pont = 0;
            PlayerControl.health =100;
            Boss.health = 100;    
            SceneManager.LoadScene("tutorial");
        }
    }

    if(scene.name == "tutorial"){
        if(Input.GetKey(sair)){      
            SceneManager.LoadScene("fase1");
        }
    }
    if(scene.name == "tutorial"){
       GUI.Label(new Rect(Screen.width / 2 - 440 - 12, 15, 200, 200), "COMANDOS: ");
       GUI.Label(new Rect(Screen.width / 2 + 240 - 12, 15, 200, 200), "PLATAFORMAS: ");
       GUI.Label(new Rect(Screen.width / 2 - 40 - 12, 15, 200, 200), "INIMIGOS: ");
       GUI.Label(new Rect(Screen.width / 2 - 440 - 12, 350, 200, 200), "COLECIONAVEIS: ");
       GUI.Label(new Rect(Screen.width / 2 - 200 - 12, 350, 200, 200), "+ 10 DE VIDA");
       GUI.Label(new Rect(Screen.width / 2 - 20 - 12, 350, 200, 200), "+ 10 PONTOS");
       GUI.Label(new Rect(Screen.width / 2 +280 - 12, 350, 200, 200), "OBJETIVO:");
       GUI.Label(new Rect(Screen.width / 2 + 50 - 12, 210, 200, 200), "+ 10 PONTOS");
       GUI.Label(new Rect(Screen.width / 2 + 50 - 12, 110, 200, 200), "+ 100 PONTOS");
       GUI.Label(new Rect(Screen.width / 2 - 120 - 12, 280, 600, 600), "APERTE T PARA COMECAR ");
    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
