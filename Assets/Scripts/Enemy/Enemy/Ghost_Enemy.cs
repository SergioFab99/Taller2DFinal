using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_Enemy : MonoBehaviour
{
    Rigidbody2D rigidbody2;
    AudioClip AudioClip;
    AudioSource Source;
    private void Awake()
    {
        AudioClip = Resources.Load<AudioClip>("GhostEffect");
        rigidbody2 = GetComponent<Rigidbody2D>();
        Source = GetComponent<AudioSource>();
        Destroy(gameObject, 1.5f);
    }

    void Start()
    {
        Source.clip = AudioClip;
        Source.PlayOneShot(AudioClip);
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2.velocity = new Vector2(0, -1)*50;
    }
}
