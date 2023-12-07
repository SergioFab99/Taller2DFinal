using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggroState : EnemyBaseState
{
    AudioClip EnemyLongGrowl;
    AudioClip EnemyZombieGrowl;
    float randomSoundInterval;
    float Timer = 0;
    public override void EnterState(EnemyStateManager manager)
    {
        manager.PathFinder.Target = GameObject.Find("Player").transform;
        EnemyLongGrowl = Resources.Load<AudioClip>("Enemy_Long_Growl");
        EnemyZombieGrowl = Resources.Load<AudioClip>("Enemy_Zombie_Growl");
        randomSoundInterval = Random.Range(5, 10);
    }
    public override void ExitState(EnemyStateManager manager)
    {

    }
    public override void UpdateState(EnemyStateManager manager)
    {
        Timer += Time.deltaTime;
        if(Timer >= randomSoundInterval)
        {
            int randomAudio = Random.Range(1, 3);
            switch (randomAudio)
            {
                case 1:
                    manager.Audiosource().PlayOneShot(EnemyLongGrowl, 0.5f);
                    break;
                case 2:
                    manager.Audiosource().PlayOneShot(EnemyZombieGrowl, 0.5f);
                    break;
            }
            randomSoundInterval = Random.Range(5, 10);
            Timer = 0;
        }
    }
}
