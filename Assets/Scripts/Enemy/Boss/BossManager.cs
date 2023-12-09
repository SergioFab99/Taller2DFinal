using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    [SerializeField] private Transform[] dashesPositions;
    [SerializeField] private int life = 100;
    [SerializeField] private float moveSpeed;
    Rigidbody2D rb2d;
    private float currentActivityTimer;
    private float resetTimer = 5;

    bool ableToMove;
    Transform Target;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private Transform shootingPoint;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        StartCoroutine(BossFight());
    }

    // Update is called once per frame
    void Update()
    {
        if (ableToMove)
        {
            Vector2 newPos = Vector2.MoveTowards(transform.position, Target.position, Time.deltaTime * moveSpeed);
            rb2d.MovePosition(newPos);
            if(Vector2.Distance(transform.position, Target.position) < 0.2)
            {
                ableToMove = false;
            }
        }
        //debuging
        if(Input.GetKeyDown(KeyCode.Space))
        {
            life -= 5;
        }
    }
    IEnumerator BossFight()
    {
        while(life>90)
        {
            Attack();
            yield return new WaitForSeconds(3);
        }
        InvokeAttack();
        while(life>75)
        {
            Attack();
            yield return new WaitForSeconds(3);
        }
        while (life>50)
        {
            Attack();
            yield return new WaitForSeconds(3);
        }
        while (life>20)
        {
            Attack();
            yield return new WaitForSeconds(3);
        }
        while (life>1)
        {
            Attack();
            yield return new WaitForSeconds(3);
        }
        TriggerWin();
        Destroy(gameObject);
    }
    void TriggerWin()
    {
        Debug.Log("Ganate");
    }
    void Attack()
    {
        int n = Mathf.FloorToInt(UnityEngine.Random.Range(1, 3));
        switch(n)
        {
            case 1:
                Debug.Log($"Do Attack Movement");
                MoveAttack();
                break;
            case 2:
                Debug.Log($"Do Attack Shoot");
                ShootAttack();
                break;
        }
    }
    private void MoveAttack()
    {
        int random = UnityEngine.Random.Range(0, dashesPositions.Length);
        Target = dashesPositions[random];
        ableToMove = true;
    }
    private void ShootAttack()
    {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = shootingPoint.position;
            bullet.transform.rotation = transform.rotation;
            Destroy(bullet, 2f);
    }
    private void InvokeAttack()
    {

    }
}
