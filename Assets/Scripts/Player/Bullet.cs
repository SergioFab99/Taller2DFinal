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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {

            // Destruye al enemigo
            Destroy(collision.gameObject);

            // Destruye la bala    
            Destroy(gameObject);

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
}
