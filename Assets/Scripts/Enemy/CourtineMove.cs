using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CourtineMove : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private Vector2 direction;

    [SerializeField] private float velocity;


    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (true)
        {
            int count = 0;
            while (count < 3)
            {
                rb2d.velocity = velocity * direction;
                yield return new WaitForSeconds(1);
                direction *= -1;
                count++;
            }
            if (direction == Vector2.up || direction == Vector2.down)
            {
                direction = Vector2.right;
            }
            else
            {
                direction = Vector2.up;
            }
            
        }
    }
}
