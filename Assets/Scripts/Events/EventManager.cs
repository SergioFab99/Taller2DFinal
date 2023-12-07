using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class EventManager : MonoBehaviour
{
    private enum Classes
    {
        DoorMonster,
        PainScream,
        GhostEvent
    }
    private enum Conditions
    {
        OnTouch,
        OnTrigger,
        OnKill
    }

    [SerializeField] private Classes Selector;
    [SerializeField] private Conditions TriggerCondition;
    BaseEvent SelectedEvent;
    public bool Done = false;
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DetermineCondition();
        if(TriggerCondition == Conditions.OnTrigger)
        {
            ActivateEvent(this);
        }
    }
    public void ActivateEvent(EventManager manager)
    {
        if (!Done)
        {
            // Debug.Log("Event Activated");
            SelectedEvent = DetermineEvent();  
            SelectedEvent.EventTrigger(manager);
            Done = true;
        }
    }
    private BaseEvent DetermineEvent()
    {
        switch(Selector)
        {
            case Classes.PainScream : return new PainScream();
            case Classes.DoorMonster : return new DoorMonster();
            case Classes.GhostEvent : return new GhostEvent();
            default: return null;
        }
    }
    private Conditions DetermineCondition()
    {
        switch(TriggerCondition)
        {
            case Conditions.OnTouch : return Conditions.OnTouch;
            case Conditions.OnTrigger : return Conditions.OnTrigger;
            case Conditions.OnKill : return Conditions.OnKill;
            default : return Conditions.OnTrigger;
        }
    }
}
