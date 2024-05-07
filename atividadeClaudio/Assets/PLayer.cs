using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer : MonoBehaviour
{
    public int life = 3;
    public int lifeMax;
    public BoxCollider2D boxCollider;
    public SpriteRenderer spriteRenderer;
    public GameObject bullet;
    public Transform foot;
    bool groundCheck;
    public float speed = 5, jumpStrength = 5, bulletSpeed = 8;
    public float horizontal;
    public Rigidbody2D body;
    public float velocity;
    int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(horizontal * speed, body.velocity.y);
        groundCheck = Physics2D.OverlapCircle(foot.position, 0.05f);

        if (Input.GetButtonDown("Jump") && groundCheck)
        {
            body.AddForce(new Vector2(0, jumpStrength * 100));
        }
        if (horizontal != 0)
        {
            direction = (int)horizontal;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject temp = Instantiate(bullet, transform.position, transform.rotation);
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed * direction, 0);

        }
        if (Input.GetButtonDown("Fire2"))
        {
            speed = speed * 2;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // life--;
            //life -=1;
            //life = life -1;
            life -= collision.gameObject.GetComponent<Enemy>().damage;
            if (life <= 0)
            {
                Destroy(gameObject);

            }
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("cor"))
        {
            spriteRenderer.color = Color.red;
            boxCollider.isTrigger = false;
        }
    }
}

