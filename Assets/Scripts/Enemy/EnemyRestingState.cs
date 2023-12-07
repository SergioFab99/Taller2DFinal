using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyRestingState : EnemyBaseState
{
    public AudioClip PlayerDetected;
    [SerializeField] private float velocidadMov;
    [SerializeField] public UnityEngine.GameObject[] puntosMov;
    [SerializeField] private float distanciaMinima;
    [SerializeField] private int numeroAleatorio;

    public override void EnterState(EnemyStateManager manager)
    {
        PlayerDetected = Resources.Load<AudioClip>("Efecto_de_sonido_Sorpresa_320_kbps");
        puntosMov = GameObject.FindGameObjectsWithTag("Patrullaje");
        numeroAleatorio = Random.Range(0, puntosMov.Length);
        
        
    }
    public override void ExitState(EnemyStateManager manager)
    {
        manager.Audiosource().PlayOneShot(PlayerDetected, 0.5f);
    }
    public override void UpdateState(EnemyStateManager manager)
    {
        manager.PathFinder.Target = puntosMov[numeroAleatorio].transform;
        //manager.transform.position = Vector2.MoveTowards(manager.transform.position, puntosMov[numeroAleatorio].GetComponent<UnityEngine.Transform>().position, velocidadMov * Time.deltaTime);

        if (Vector2.Distance(manager.transform.position, puntosMov[numeroAleatorio].GetComponent<UnityEngine.Transform>().position) < 2)
        {

            numeroAleatorio = Random.Range(0, puntosMov.Length);
        }
    }
}
