using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    [SerializeField] private Transform[] dashesPositions;
    [SerializeField] private Transform[] spawnerPositions;
    [SerializeField] private int life = 100;
    [SerializeField] private float moveSpeed;
    Rigidbody2D rb2d;

    bool ableToMove;
    Transform Target;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private Transform shootingPoint;

    GameObject Player;
    void Start()
    {
        Player = GameObject.Find("Player");
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
        InvokeAttack(1);
        while (life>50)
        {
            Attack();
            yield return new WaitForSeconds(3);
        }
        InvokeAttack(2);
        while (life>20)
        {
            Attack();
            yield return new WaitForSeconds(3);
        }
        InvokeAttack(3);
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
            float DirectionAngleX = Player.transform.position.x - transform.position.x;
            float DirectionAngley = Player.transform.position.y - transform.position.y;
            float Angle = Mathf.Atan2(DirectionAngley, DirectionAngleX) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.Euler(new Vector3(0,0,Angle));
            Destroy(bullet, 2f);
    }
    private void InvokeAttack(int extraSpawns)
    {
        for (int i = 0; i < UnityEngine.Random.Range(1, 3) + extraSpawns; i++)
        {
            GameObject Spawn = Instantiate(zombiePrefab);
            Spawn.transform.position = spawnerPositions[UnityEngine.Random.Range(0, spawnerPositions.Length)].position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bala"))
        {
            life -= 5;
            Destroy(collision.gameObject);
        }
    }
}
