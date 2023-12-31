using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    public float speed = 90f;
    private AudioClip clip;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {
            // Destruye al enemigo
            Destroy(collision.gameObject);

            // Destruye la bala    
            DestroyBullet();

        }
        if (collision.CompareTag("Boss"))
        {
            DestroyBullet();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            DestroyBullet();
        }
    }
    public void ShootSound(AudioClip Sound)
    {
        this.clip = Sound;
        GetComponent<AudioSource>().clip = clip;
        GetComponent<AudioSource>().PlayOneShot(clip);
    }

    void FixedUpdate()
    {
        rigidbody.MovePosition(transform.position + transform.right * speed * Time.fixedDeltaTime);
    }

    public void DestroyBullet()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
    }
}
