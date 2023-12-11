using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Locker : MonoBehaviour
{
    EventManager Manager;
    public bool SetEvent;
    
    GameObject MunicionPrefab;
    GameObject JeringaPrefab;
    
    [SerializeField] GameObject LetraE;
    bool Pickable = false;

    SpriteRenderer UI;
    [SerializeField] Sprite Opened;
    bool Used = false;
    private void Awake()
    {
        MunicionPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Prefab/Items/Municion.prefab");
        JeringaPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Prefab/Items/Jeringa.prefab");
        Manager = GetComponent<EventManager>();
        UI = LetraE.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !Used)
        {
            Pickable = true;
            UI.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !Used)
        {
            Pickable = false;
            UI.enabled = false;
        }
    }
    private void Update()
    {
        if(Pickable && Input.GetKeyDown(KeyCode.E) && !Used)
        {
            Use();
        }
    }
    private void Use()
    {
        if (SetEvent)
        {
            Manager.ActivateTouchEvent();
            StartCoroutine(Spawned());
        }
        else
        {
            int num = Random.Range(0, 6);
            switch (num)
            {
                case 0:
                    Instantiate(MunicionPrefab, transform);
                    break;
                case 1:
                    Instantiate(JeringaPrefab, transform);
                    break;
                case 2:
                    Manager.ActivateTouchEvent();
                    StartCoroutine(Spawned());
                    break;
                default:
                    break;
            }
        }
        Used = true;
        UI.enabled = false;
        GetComponent<SpriteRenderer>().sprite = Opened;
    }
    IEnumerator Spawned()
    {
        GetComponent<BoxCollider2D>().enabled = false;
         yield return new WaitForSeconds(2f);
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
