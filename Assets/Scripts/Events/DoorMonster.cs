using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoorMonster : BaseEvent
{
    private GameObject Prefab;
    GameObject Spawn;
    public override void EventTrigger(EventManager manager)
    {
        Prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Prefab/Enemy/Enemigo/Enemigo.prefab");
        Spawn = GameObject.Instantiate(Prefab);
        Spawn.transform.position = manager.transform.position;
        Spawn.GetComponent<Patrullaje>().ActivateSurprise();
    }
}
