using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Bazooka : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float velocidadDisparo = 10f;
    private float cooldown = 3f;
    private float tiempoUltimoDisparo;
    public new Camera camera;
    public Transform spawner;
    public Transform Pistola; // Referencia al objeto Pistola
    private GameObject Player;
    [SerializeField] private AudioClip SonidoBala;
    Transform ShootingRight;
    Transform ShootingLeft;

    void Start()
    {
        camera = Camera.main; // Busca la cámara principal
        Player = GameObject.Find("Player");
        ShootingLeft = GameObject.Find("ShootingLeft").GetComponent<Transform>();
        ShootingRight = GameObject.Find("ShootingRight").GetComponent<Transform>();
    }

    void Update()
    {
        RotateTowardsMouse();

        if (Input.GetMouseButtonDown(0) && Time.time > tiempoUltimoDisparo + cooldown)
        {
            Disparar();
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

    void Disparar()
    {
         // Realizar el disparo
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.GetComponent<Bullet>().ShootSound(SonidoBala);
            bullet.transform.position = spawner.position;
            bullet.transform.rotation = transform.rotation;
            bullet.transform.localScale *= 2f;
            Destroy(bullet, 2f);
        //GameObject bullet = Instantiate(bulletPrefab, spawner.position, Quaternion.identity);
        //bullet.GetComponent<Rigidbody2D>().velocity = transform.right * velocidadDisparo;
    }
}
