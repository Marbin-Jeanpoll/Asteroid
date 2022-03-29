using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Asteroid : MonoBehaviour
{
      
    public Player player;
    public int Points;
    Rigidbody2D rb2d;
    public float speed;
    public GameObject[] subAsteroids;
    public int numberAsteroids;
    bool isDestroying = false; 

    void Start()
    {
        
        player = FindObjectOfType<Player>();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.drag = 0;
        rb2d.angularDrag = 0;

        rb2d.velocity = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            0
            ).normalized* speed;
        rb2d.angularVelocity = Random.Range(-50f, 50);
    }

    public void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDestroying)
        {
            return;
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            isDestroying = true;
            Destroy(gameObject);
            Destroy(collision.gameObject);
            player.score = player.score+Points;
            for(var i = 0; i < numberAsteroids; i++)
            {
                Instantiate(
                    subAsteroids[Random.Range(0, subAsteroids.Length)],
                    transform.position,
                    Quaternion.identity
                    
                    );
            }
        }
    }
}
