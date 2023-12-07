using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mutante : MonoBehaviour
{
    public float detectionRadius = 5.0f;
    public float chaseSpeed = 4.0f;
    private GameObject player;
    private bool isPlayerInRange = false;

    [SerializeField] private AudioClip alertClip; // Clip de sonido de alerta
    private AudioSource alertSound;

    void Start()
    {
        // Encuentra y asigna el jugador
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("No se encontró un GameObject con la etiqueta 'Player'.");
            return;
        }

        // Configura el CircleCollider2D
        CircleCollider2D collider = gameObject.GetComponent<CircleCollider2D>();
        if (collider == null)
        {
            collider = gameObject.AddComponent<CircleCollider2D>();
        }
        collider.isTrigger = true;
        collider.radius = detectionRadius;

        // Configura el AudioSource
        alertSound = gameObject.AddComponent<AudioSource>();
        alertSound.clip = alertClip;
        alertSound.playOnAwake = false;
    }

    void Update()
    {
        // Persecución del jugador
        if (isPlayerInRange && player != null)
        {
            Vector3 directionToPlayer = (player.transform.position - transform.position);
            directionToPlayer.z = 0; // Elimina el movimiento en el eje Z para juegos 2D
            transform.position += directionToPlayer.normalized * chaseSpeed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Detecta la entrada del jugador y reproduce el sonido de alerta
        if (other.gameObject == player)
        {
            isPlayerInRange = true;
            if (alertSound != null && !alertSound.isPlaying)
            {
                alertSound.Play();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Detecta la salida del jugador
        if (other.gameObject == player)
        {
            isPlayerInRange = false;
        }
    }

    void OnDrawGizmos()
    {
        // Dibuja el radio de detección en el editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
