using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Text text;
    public Asteroid asteroid;
    public int score;
    public Rigidbody2D rb2d;
    public float speed;
    public float angularSpeed;
    public float maxSpeed;
    public float drag;

    public float offsetBullet;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.drag = drag;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = score.ToString();
        Move();
        Rotation();
        Shoot();
    }

    public void Move()
    {
        
        float vertical = Input.GetAxis("Vertical");
        var forwardMotor = Mathf.Clamp(vertical, 0f, 1f);
        rb2d.AddForce(transform.up * speed * forwardMotor);
        if (rb2d.velocity.magnitude > maxSpeed)
        {
            rb2d.velocity = rb2d.velocity.normalized * maxSpeed;
        }
    }

    public void Rotation()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(0, 0, -angularSpeed * horizontal * Time.deltaTime);
    }

    public void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var pos = transform.up * offsetBullet + transform.position;

            var bullet = Instantiate(bulletPrefab, pos, transform.rotation);
            Destroy(bullet, 5);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

}
