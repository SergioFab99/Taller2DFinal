using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] public int munición = 3; // Cantidad inicial de munición
    public TextMeshProUGUI textmunicion;
    public Animator animdisparo;
    public float tiempo;
    public bool yadisparo;

    Vector2 direccion;

    
    void Awake()
    {
        //la pistola empezará en false
        gameObject.SetActive(false);
        direccion = Vector2.down;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    void Start()
    {
        Jugador = GameObject.Find("Player").GetComponent<Jugador>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Player = GameObject.Find("Player");
        ShootingLeft = GameObject.Find("ShootingLeft").GetComponent<Transform>();
        ShootingRight = GameObject.Find("ShootingRight").GetComponent<Transform>();

        textmunicion.text = "3";
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if(horizontal !=0  || vertical !=0)
        {
            direccion = new Vector2(horizontal, vertical);  
        }
        RotateTowardsMouse();
        CheckFiring();

        if (yadisparo)
        {
            tiempo += Time.deltaTime;

            if (tiempo > 0.6f) // Cambiado a 0.6f
            {
                animdisparo.SetBool("Disparo", false);
                yadisparo = false; // Importante restablecer la bandera aquí si es necesario
                tiempo = 0;
            }
        }
        
    }

    private void RotateTowardsMouse()
    {
        return;
        Vector3 mouseWorldPosition = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseDirection = mouseWorldPosition - Player.transform.position;
        mouseDirection.z = 0;
        transform.right = mouseDirection;
        //float angle = GetAngleTowardsMouse();
        Vector3 scale = transform.localScale;
        /*if (mouseDirection.x < 0)
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
        }*/
    }

   /* private float GetAngleTowardsMouse()
    {
        Vector3 mouseWorldPosition = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseDirection = mouseWorldPosition - transform.position;
        mouseDirection.z = 0;
        float angle = (Vector3.SignedAngle(Vector3.right, mouseDirection, Vector3.forward) + 360) % 360;
        return angle;
    }*/
    public void AñadirMunición(int cantidad)
    {
        Debug.Log("Añadiendo munición");
        munición += cantidad;
        textmunicion.text = "5";
    }
    private void RealizarDisparo()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        animdisparo.SetBool("Disparo", true);
        bullet.GetComponent<Bullet>().ShootSound(SonidoBala);
        bullet.transform.position = spawner.position;
        bullet.transform.right = direccion;
        // animdisparo.SetBool("TerminaDisparo", true);
        Destroy(bullet, 1f);
        munición--; // Disminuir munición
        textmunicion.text = munición.ToString();
        
        yadisparo = true;
        Invoke("DesactivarAnimacionDisparo", 0.3f);
    }

    private void DesactivarAnimacionDisparo()
    {
        animdisparo.SetBool("Disparo", false);
    }

    private void CheckFiring()
    {
        currentCooldown -= Time.deltaTime; // Restamos tiempo desde el último disparo

        if (Input.GetMouseButtonDown(0) && currentCooldown <= 0)
        {
            if (munición > 0) // Verificar si hay munición
            {
                // Realizar el disparo
                //GameObject bullet = Instantiate(bulletPrefab);
                Invoke("RealizarDisparo", 0.5f);
                animdisparo.SetBool("Disparo", true);
                currentCooldown = fireCooldown;
                //animdisparo.SetBool("Disparo", false);

            }
            else
            {
                Debug.Log("Sin munición!"); // Mensaje de alerta
            }
        }
    }
}