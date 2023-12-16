using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PlayerWeapon : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private GameObject Player;
    public new Camera camera;
    public GameObject bulletPrefab;
    public Transform spawner;
    public float fireCooldown = 0.9f; // Tiempo de enfriamiento entre disparos
    private float currentCooldown = 0f;
    [SerializeField] private AudioClip SonidoBala;
    Jugador Jugador;
    Transform ShootingRight;
    Transform ShootingLeft;
    [SerializeField] private int munición = 10; // Cantidad inicial de munición

    //public Animator animdisparo;
    void Awake()
    {
        //la pistola empezará en false
        gameObject.SetActive(false);
    }

    void Start()
    {
        Jugador = GameObject.Find("Player").GetComponent<Jugador>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Player = GameObject.Find("Player");
        ShootingLeft = GameObject.Find("ShootingLeft").GetComponent<Transform>();
        ShootingRight = GameObject.Find("ShootingRight").GetComponent<Transform>();
    }

    void Update()
    {
        RotateTowardsMouse();
        CheckFiring();
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
            transform.localScale = scale;
        }
        else
        {
            transform.position = ShootingRight.transform.position;
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
    public void AñadirMunición(int cantidad)
    {
        Debug.Log("Añadiendo munición");
        munición += cantidad;
    }

    private void CheckFiring()
    {
        currentCooldown -= Time.deltaTime; // Restamos tiempo desde el último disparo

        if (Input.GetMouseButtonDown(0) && currentCooldown <= 0)
        {
            if (munición > 0) // Verificar si hay munición
            {
                // Realizar el disparo
                GameObject bullet = Instantiate(bulletPrefab);
                //animdisparo.SetBool("Disparo", true);
                bullet.GetComponent<Bullet>().ShootSound(SonidoBala);
                bullet.transform.position = spawner.position;
                bullet.transform.rotation = transform.rotation;
               // animdisparo.SetBool("TerminaDisparo", true);
                Destroy(bullet, 2f);

                munición--; // Disminuir munición
                currentCooldown = fireCooldown;
                //animdisparo.SetBool("Disparo", false,)2f;
                //animdisparo.SetBool("TerminaDisparo", false);
            }
            else
            {
                Debug.Log("Sin munición!"); // Mensaje de alerta
            }
        }
    }
}