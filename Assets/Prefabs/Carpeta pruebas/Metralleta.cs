using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Metralleta : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float velocidadDisparo = 10f;
    private float cooldown = 0.5f;
    private float tiempoUltimoDisparo;
    public new Camera camera;
    public Transform spawner;
    public Transform Pistola;
    private GameObject Player;
    [SerializeField] private AudioClip SonidoBala;
    Transform ShootingRight;
    Transform ShootingLeft;

    // Escala original de la metralleta
    private Vector3 escalaOriginal;

    void Start()
    {
        camera = Camera.main; // Busca la cámara principal
        Player = GameObject.Find("Player");
        escalaOriginal = transform.localScale;
        ShootingLeft = GameObject.Find("ShootingLeft").GetComponent<Transform>();
        ShootingRight = GameObject.Find("ShootingRight").GetComponent<Transform>();
    }
    
    void Update()
    {
        RotateTowardsMouse();

        if (Input.GetMouseButtonDown(0) && Time.time > tiempoUltimoDisparo + cooldown)
        {
            StartCoroutine(Rafaga());
            tiempoUltimoDisparo = Time.time;
        }
    }

    private void RotateTowardsMouse()
    {
        Vector3 mouseWorldPosition = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseDirection = mouseWorldPosition - Player.transform.position;
        mouseDirection.z = 0;
        transform.right = mouseDirection;
        float angle = GetAngleTowardsMouse();
        Vector3 scale = transform.localScale;
        if (mouseDirection.x < 0)
        {
            transform.position = ShootingLeft.transform.position;
            scale.y = -0.04f;
            //scale.x = -0.04f;
            transform.localScale = scale;

        }
        else
        {

            transform.position = ShootingRight.transform.position;
            //scale.x = 0.04f;
            scale.y = 0.04f;
            transform.localScale = scale;
        }
    }

    private float GetAngleTowardsMouse()
    {
        Vector3 mouseWorldPosition = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseDirection = mouseWorldPosition - transform.position;
        mouseDirection.z = 0;
        float angle = (Vector3.SignedAngle(Vector3.right, mouseDirection, Vector3.forward) + 360) % 360;
        return angle;
    }

    IEnumerator Rafaga()
    {
        for (int i = 0; i < 3; i++)
        {
            Disparar();
            yield return new WaitForSeconds(0.1f);
        }
    }

    void Disparar()
    {
         // Realizar el disparo
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.GetComponent<Bullet>().ShootSound(SonidoBala);
            bullet.transform.position = spawner.position;
            bullet.transform.rotation = transform.rotation;
            Destroy(bullet, 2f);
        //GameObject bullet = Instantiate(bulletPrefab, spawner.position, Quaternion.identity);
        //bullet.GetComponent<Rigidbody2D>().velocity = transform.right * velocidadDisparo;
    }
}
