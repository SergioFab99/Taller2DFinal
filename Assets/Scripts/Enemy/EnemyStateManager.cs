using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    //State manager
    EnemyBaseState CurrentState;
    public EnemyBaseState AggroState = new EnemyAggroState();
    public EnemyBaseState RestingState = new EnemyRestingState();
    public EnemyPathfindign PathFinder;
    SpriteRenderer SpriteRenderer;
    AudioSource audioSource;
    public GameObject Player;


    private void Awake()
    {
        PathFinder = GetComponent<EnemyPathfindign>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        CurrentState = RestingState;
        SwitchState(CurrentState);
        Player = GameObject.Find("Player");
    }
    void Update()
    {
        CurrentState.UpdateState(this);
    }
    public void SwitchState(EnemyBaseState NewState)
    {
        CurrentState.ExitState(this);
        CurrentState= NewState;
        CurrentState.EnterState(this);
    }
    public AudioSource Audiosource()
    { return audioSource; }
}
