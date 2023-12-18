using System.Collections;
using TMPro;
using UnityEngine;

public class Metralleta : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float velocidadDisparo = 10f;
    private float cooldown = 0.5f;
    private float tiempoUltimoDisparo;
    public new Camera camera;
    public Transform spawner;
    private GameObject Player;
    [SerializeField] private AudioClip SonidoBala;
    Transform ShootingRight;
    Transform ShootingLeft;

    public TextMeshProUGUI txtcontador;

    public Animator animdisparo;
    public float tiempo;
    public bool yadisparo;

    Vector2 direccion;

    // Escala original de la metralleta
    private Vector3 escalaOriginal;

    [SerializeField] public int munición = 20; // Cantidad inicial de munición

    void Start()
    {
        camera = Camera.main; // Busca la cámara principal
        Player = GameObject.Find("Player");
        escalaOriginal = transform.localScale;
        ShootingLeft = GameObject.Find("ShootingLeft").GetComponent<Transform>();
        ShootingRight = GameObject.Find("ShootingRight").GetComponent <Transform>();

        // Actualizar el TextMeshProUGUI al inicio para mostrar la munición inicial
        ActualizarTextoMunicion();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            direccion = new Vector2(horizontal, vertical);
        }
        RotateTowardsMouse();


        if (Input.GetMouseButtonDown(0) && Time.time > tiempoUltimoDisparo + cooldown)
        {
            if (munición >= 3) // Verificar si hay suficiente munición para una ráfaga
            {
                StartCoroutine(Rafaga());
                tiempoUltimoDisparo = Time.time;
            }
            else
            {
                Debug.Log("Munición insuficiente para una ráfaga");
            }
        }
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

        if (munición >= 20)
        {
            munición = 20;
            txtcontador.text = munición.ToString();
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
        }
    }

    private float GetAngleTowardsMouse()
    {
        Vector3 mouseWorldPosition = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseDirection = mouseWorldPosition - transform.position;
        mouseDirection.z = 0;
        float angle = (Vector3.SignedAngle(Vector3.right, mouseDirection, Vector3.forward) + 360) % 360;
        return angle;*/
    }

    IEnumerator Rafaga()
    {
        for (int i = 0; i < 3; i++)
        {
            if (munición > 0)
            {
                Disparar();
                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                Debug.Log("Sin munición");
                break; // Detener la ráfaga si se queda sin munición
            }
        }
    }

    public void AñadirMunición(int cantidad)
    {
        Debug.Log("Añadiendo munición");
        munición += cantidad;

        // Actualizar el TextMeshProUGUI después de añadir munición
        ActualizarTextoMunicion();
    }

    void Disparar()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        animdisparo.SetBool("Disparo", true);
        bullet.GetComponent<Bullet>().ShootSound(SonidoBala);
        bullet.transform.position = spawner.position;
        bullet.transform.right = direccion;
        Destroy(bullet, 2f);

        munición--; // Disminuir munición

        // Actualizar el TextMeshProUGUI después de disparar
        ActualizarTextoMunicion();
        yadisparo = true;
        Invoke("DesactivarAnimacionDisparo", 0.3f);
    }
    private void DesactivarAnimacionDisparo()
    {
        animdisparo.SetBool("Disparo", false);
    }
    // Método para actualizar el TextMeshProUGUI
    void ActualizarTextoMunicion()
    {
        txtcontador.text = munición.ToString();
    }
}