using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainScream : BaseEvent
{
    AudioSource m_AudioSource;
    AudioClip m_Clip;
    public override void EventTrigger(EventManager manager)
    {
        // Debug.Log("you should hear a scream");
        m_Clip = Resources.Load<AudioClip>("WomanScream");
        m_AudioSource = manager.gameObject.GetComponentInChildren<AudioSource>();
        m_AudioSource.PlayOneShot(m_Clip);
    }
}
