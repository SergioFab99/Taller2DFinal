using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrullaje : MonoBehaviour
{
    private Transform currentTarget;
    private GameObject[] targetList;
    private GameObject Player;
    private AIDestinationSetter targetSetter;
    [SerializeField] private bool playerDetected = false;
    RaycastHit2D Hit;

    [SerializeField] LayerMask LayersHit;
    [SerializeField] float AggroDistance = 25;
    private void Awake()
    {
        targetList = GameObject.FindGameObjectsWithTag("Patrullaje");
        targetSetter = GetComponent<AIDestinationSetter>();
        Player = GameObject.Find("Player");
        GetRandomTarget();
        UpdateTarget();
    }
    private void Update()
    {
        checkForPlayer();
        if (targetList != null)
        {
            if (IsDoneWithTarget() && !playerDetected)
            {
                GetRandomTarget();
            }
        }
        UpdateTarget();
    }
    bool IsDoneWithTarget()
    {
        if(Vector2.Distance(transform.position, currentTarget.position) < 0.5)
        {
            return true;
        }
        else 
        {
            return false; 
        }
    }
    void GetRandomTarget()
    {
        int random = UnityEngine.Random.Range(0, targetList.Length);
        currentTarget = targetList[random].transform;
    }
    void UpdateTarget()
    {
        targetSetter.target = currentTarget;
        if (playerDetected)
        {
            targetSetter.target = Player.transform;
        }
    }
    void checkForPlayer()
    {
        Vector2 Direction = Player.transform.position - transform.position;
        Hit = Physics2D.Raycast(transform.position, Direction.normalized, AggroDistance, LayersHit);
        Debug.DrawRay(transform.position, Direction);
        if(Hit.collider != null)
        {
            if (Hit.collider.gameObject.CompareTag("Player"))
            {
                playerDetected = true;
            }
        }
    }
    public void ActivateSurprise()
    {
        StartCoroutine(Surprise());
        //GetComponent<AIPath>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
    }
    IEnumerator Surprise()
    {
        yield return new WaitForSeconds(3f);
        //GetComponent<AIPath>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<CapsuleCollider2D>().enabled = true;
        StopCoroutine(Surprise());
        UpdateTarget();
    }
}