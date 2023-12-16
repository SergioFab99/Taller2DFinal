using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VidaUI : MonoBehaviour
{
    public GameObject Jefe;
    public Image Salud, Rojo;
    public float Velocidad;
    public float health, maxhealth;
    void Start()
    {
        maxhealth = Jefe.GetComponent<JefeFinal>().Health;
        health = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        float target = health / maxhealth;

        Rojo.fillAmount = Mathf.Lerp(Rojo.fillAmount, target, Time.deltaTime * Velocidad);
        Salud.fillAmount = target;
        health = Jefe.GetComponent<JefeFinal>().Health;
    }
}
