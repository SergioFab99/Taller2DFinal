using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PuertaDeslizante : MonoBehaviour
{
    public float slideDistance = 3.0f;  // Distancia que se deslizará la puerta
    public float slideSpeed = 1.0f;     // Velocidad de deslizamiento
    public float detectionRadius = 3.0f; // Radio de detección
    public float closeDelay = 2.0f;      // Retraso antes de cerrar la puerta
    private Vector3 closedPosition;      // Posición original (cerrada) de la puerta
    private Vector3 openPosition;        // Posición abierta de la puerta
    private bool isOpen = false;         // Controla si la puerta está abierta o cerrada
    private Coroutine closeCoroutine;    // Referencia a la corrutina de cierre

    void Start()
    {
        closedPosition = transform.position;  // Guarda la posición inicial de la puerta
        openPosition = closedPosition - transform.right * slideDistance; // Calcula la posición abierta
    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            if (distanceToPlayer <= detectionRadius && !isOpen)
            {
                if (closeCoroutine != null)
                {
                    StopCoroutine(closeCoroutine);
                    closeCoroutine = null;
                }
                StartCoroutine(SlideDoor(openPosition));
            }
            else if (distanceToPlayer > detectionRadius && isOpen && closeCoroutine == null)
            {
                closeCoroutine = StartCoroutine(CloseDoorAfterDelay());
            }
        }
    }

    IEnumerator SlideDoor(Vector3 targetPosition)
    {
        isOpen = targetPosition != closedPosition;
        float timeElapsed = 0;

        while (timeElapsed < 1.0f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, timeElapsed);
            timeElapsed += Time.deltaTime * slideSpeed;
            yield return null;
        }

        transform.position = targetPosition;
    }

    IEnumerator CloseDoorAfterDelay()
    {
        yield return new WaitForSeconds(closeDelay);

        // Verifica si el jugador ha vuelto al radio de detección antes de cerrar la puerta
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null || Vector3.Distance(player.transform.position, transform.position) > detectionRadius)
        {
            StartCoroutine(SlideDoor(closedPosition));
        }
        closeCoroutine = null;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
