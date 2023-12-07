using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyPathfindign : MonoBehaviour
{
    public Transform Target;
    public float Speed = 0;
    public float NextStepDistance = 3f;
    Path path;
    int CurrentStep = 0;
    bool PathEnded = false;
    Seeker seeker;
    Rigidbody2D rb2d;
    Animator animator;
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb2d = GetComponent<Rigidbody2D>();
        seeker.StartPath(rb2d.position, Target.position, OnCompletePath);
        animator = GetComponent<Animator>();
        InvokeRepeating("UpdatePath", 0f, 0.05f);
    }
    private void OnCompletePath(Path _path)
    {
        if(!_path.error)
        {
            path = _path;
            CurrentStep = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Vector2.Distance(rb2d.position, Target.position) >= 10)
        {
            Speed = 0;
            return;
        }*/
        if (path == null)
        {
            return;
        }
        if (CurrentStep >= path.vectorPath.Count)
        {
            PathEnded = true;
            return;
        }
        else
        {
            PathEnded = false;
        }
        Vector2 Angle = ((Vector2)path.vectorPath[CurrentStep] - rb2d.position).normalized;
        Vector2 MoveForce = Angle * Speed * Time.deltaTime;
        Debug.Log(MoveForce);
        float distance = Vector2.Distance(rb2d.position, path.vectorPath[CurrentStep]);
        rb2d.AddForce(MoveForce);
        if (distance < NextStepDistance)
        {
            CurrentStep++;
        }
        
    }
    private void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb2d.position, Target.position, OnCompletePath);
        }
    }
}