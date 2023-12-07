using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    [SerializeField] Transform[] DashesPositions;
    int life = 100;
    Rigidbody2D rb2d;
    int RateValue = 1;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        StartCoroutine(BossFight());
    }

    // Update is called once per frame
    void Update()
    {
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
        DoRushAtack();
        while(life>75)
        {
            Attack();
            yield return new WaitForSeconds(3);
        }
        RateValue++;
        while (life>50)
        {
            Attack();
            yield return new WaitForSeconds(3);
        }
        RateValue++;
        while (life>20)
        {
            Attack();
            yield return new WaitForSeconds(3);
        }
        RateValue++;
        while (life>1)
        {
            Attack();
            yield return new WaitForSeconds(3);
        }
        TriggerWin();
        Destroy(gameObject);
    }
    void DoRushAtack()
    {
        Debug.Log("Doing Rush Attack");
    }
    void TriggerWin()
    {
        Debug.Log("Ganate");
    }
    void Attack()
    {
        int n = Mathf.FloorToInt(UnityEngine.Random.Range(1, RateValue+1));
        Debug.Log(n);
        switch(n)
        {
            case 1:
                Debug.Log($"Do Attack {n}");;
                break;
            case 2:
                Debug.Log($"Do Attack {n}");
                break;
            case 3:
                Debug.Log($"Do Attack {n}");
                break;
            case 4:
                Debug.Log($"Do Attack {n}");
                break;
            case 5:
                Debug.Log($"Do Attack {n}");
                break;
            case 6:
                Debug.Log($"Do Attack {n}");
                break;
        }
    }
}
