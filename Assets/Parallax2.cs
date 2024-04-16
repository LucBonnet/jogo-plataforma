using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax2 : MonoBehaviour
{
    private float lenght, startpos;
    public static float movingSpeed;
    private float initialMovingSpeed;
    public GameObject cam;
    public float parallaxEffect;
    private float time;
    private float waitTime = 2f;


    // Start is called before the first frame update
    void Start()
    {
        initialMovingSpeed = movingSpeed;
        startpos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    public static void Stop() {
      movingSpeed = 0;
    }


    // Update is called once per frame
    void Update()
    {
      if(time >= waitTime) {
          movingSpeed = initialMovingSpeed;
          time = 0;
      }
              
      if(movingSpeed <= 0) {
        time += Time.deltaTime;
      }

      transform.position += Vector3.left * Time.deltaTime * movingSpeed * parallaxEffect;
      if(transform.position.x < startpos - 2*lenght ) transform.position = new Vector3(startpos, transform.position.y, transform.position.z);
    }

}
