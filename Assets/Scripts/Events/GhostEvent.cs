using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEvent : BaseEvent
{
    private GameObject Prefab;
    public override void EventTrigger(EventManager manager)
    {
        Prefab = Resources.Load<GameObject>("GhostEnemy");
        GameObject spawn = GameObject.Instantiate(Prefab);
        spawn.transform.position = manager.transform.position;
        GameObject.Destroy(spawn, 2);
        // Debug.Log("Ghost Event");
    }
}
