using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PuertaDeslizante : MonoBehaviour
{
    public float slideDistance = 3.0f;
    public float slideSpeed = 1.0f;
    public float detectionRadius = 3.0f;
    public float closeDelay = 2.0f;
    public GameObject targetObject;  // Agrega un campo para el GameObject objetivo
    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isOpen = false;
    private Coroutine closeCoroutine;

    void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition - transform.right * slideDistance;
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
                StartCoroutine(SlideDoor(openPosition, targetObject));  // Pasa el GameObject objetivo
            }
            else if (distanceToPlayer > detectionRadius && isOpen && closeCoroutine == null)
            {
                closeCoroutine = StartCoroutine(CloseDoorAfterDelay());
            }
        }
    }

    IEnumerator SlideDoor(Vector3 targetPosition, GameObject target)
    {
        isOpen = targetPosition != closedPosition;
        float timeElapsed = 0;

        while (timeElapsed < 1.0f)
        {
            target.transform.position = Vector3.Lerp(target.transform.position, targetPosition, timeElapsed);
            timeElapsed += Time.deltaTime * slideSpeed;
            yield return null;
        }

        target.transform.position = targetPosition;
    }

    IEnumerator CloseDoorAfterDelay()
    {
        yield return new WaitForSeconds(closeDelay);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null || Vector3.Distance(player.transform.position, transform.position) > detectionRadius)
        {
            StartCoroutine(SlideDoor(closedPosition, targetObject));
        }
        closeCoroutine = null;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}