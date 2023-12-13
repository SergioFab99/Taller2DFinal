using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    //booleanos
    private bool isMovingRight;
    private bool isMovingLeft;
    private bool isMovingUp;
    private bool isMovingDown;
    private bool isIdle;

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
            if (Vector2.Distance(transform.position, Target.position) < 0.2)
            {
                ableToMove = false;
                SetAnimationBooleans(false); // Desactiva todos los booleanos de animación
            }
            else
            {
                SetAnimationBooleans(true); // Activa los booleanos de animación según la dirección
            }
        }

        if (ableToMove)
        {
            Vector2 newPos = Vector2.MoveTowards(transform.position, Target.position, Time.deltaTime * moveSpeed);
            rb2d.MovePosition(newPos);
            if (Vector2.Distance(transform.position, Target.position) < 0.2)
            {
                ableToMove = false;
            }
        }
        //debuging
        if (Input.GetKeyDown(KeyCode.Space))
        {
            life -= 5;
        }
    }

    private void SetAnimationBooleans(bool isActive)
    {
        if (isMovingRight && isMovingUp)
        {
            Debug.Log("caminandoderechaabajo");
            GetComponent<Animator>().SetBool("Right", isActive);
            
        }

        if (isMovingRight && isMovingDown)
        {
            Debug.Log("caminandoderechaabajo");
            GetComponent<Animator>().SetBool("Right", isActive);

        }

        if (isMovingLeft)
        {
            GetComponent<Animator>().SetBool("Left", isActive);
            Debug.Log("caminandoizquierda");
        }
           
        if (isMovingUp)
        {
            GetComponent<Animator>().SetBool("Up", isActive);
            Debug.Log("caminandoarriba");
        }
            
        if (isMovingDown)
        {
            GetComponent<Animator>().SetBool("Down", isActive);
            Debug.Log("caminandoabajo");
        }
        if (isIdle)
        {
            GetComponent<Animator>().SetBool("Idle", isActive);
            Debug.Log("idle");
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
        yield return new WaitForSeconds(1.5f);
    }
    void TriggerWin()
    {
        SceneManager.LoadScene("Victoria");
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
        /*int random = UnityEngine.Random.Range(0, dashesPositions.Length);
        Target = dashesPositions[random];
        ableToMove = true;*/

        int random = UnityEngine.Random.Range(0, dashesPositions.Length);
        Target = dashesPositions[random];
        ableToMove = true;

        Vector2 direction = (Target.position - transform.position).normalized;

        isMovingRight = direction.x > 0.1;
        isMovingLeft = direction.x < 0.1;
        isMovingUp = direction.y > 0.1;
        isMovingDown = direction.y < 0.1;
        isIdle = direction.y == 0;
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
            life -= 10;
        }
    }
}
