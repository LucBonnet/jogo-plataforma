using UnityEngine;
using UnityEngine.Tilemaps;

public class ParallaxVDchao : MonoBehaviour
{
    private float length, startpos;
    private float initialMovingSpeed;
    private float time;
    private float waitTime = 2f;

    public static float movingSpeed = 2;
    public float parallaxEffect;
    public GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        initialMovingSpeed = movingSpeed;
        startpos = transform.position.x;
        TilemapRenderer tilemapRenderer = GetComponent<TilemapRenderer>();
        if (tilemapRenderer != null)
        {
            length = tilemapRenderer.bounds.size.x;
        }
        else
        {
            Debug.LogWarning("TilemapRenderer component not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= waitTime)
        {
            movingSpeed = initialMovingSpeed;
            time = 0;
        }

        if (movingSpeed <= 0)
        {
            time += Time.deltaTime;
        }

        transform.position += Vector3.left * Time.deltaTime * movingSpeed * parallaxEffect;
        if (transform.position.x < startpos - 0.5 * length)
        {
            transform.position = new Vector3(startpos, transform.position.y, transform.position.z);
        }
    }
}