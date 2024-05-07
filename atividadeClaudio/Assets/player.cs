using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public int life = 3;
    public BoxCollider2D boxCollider;
    public SpriteRenderer spriteRenderer;
    public GameObject bullet;
    public Transform foot;
    public bool groundCheck;
    public float speed = 5, jumpStrength = 5, bulletSpeed = 8;
    public float horizontal;
    public Rigidbody2D body;
    int direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(horizontal * speed, body.velocity.y);
        groundCheck = Physics2D.OverlapCircle(foot.position, 0.05f);
        if (Input.GetButtonDown("Jump") && groundCheck)
        {
            body.AddForce(new Vector2(0, jumpStrength * 100));
        }
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject temp = Instantiate(bullet, transform.position, transform.rotation);
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed * direction, 0);
        }
        if (Input.GetButtonDown("Fire3"))
        {
            speed = speed * 2;
        }

        if (horizontal != 0)
        {
            direction = (int)horizontal;
        }
    }
}
