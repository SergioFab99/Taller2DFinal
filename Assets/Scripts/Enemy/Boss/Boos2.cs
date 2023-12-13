using UnityEngine;
using System.Collections;
public class Boos2 : MonoBehaviour
{
  /*  public float velocidad = 5f;
    public float tiempoDeEspera = 2f;

    private Rigidbody2D rb2d;
    private Animator anim;

    private bool isMovingRight;
    private bool isMovingLeft;
    private bool isMovingUp;
    private bool isMovingDown;
    private bool isIdle;

    public float frecuenciaDisparo = 1f;
    public GameObject balaPrefab;
    public Transform puntoDisparo;

    public bool puedeDisparar = true;
    public Vector2 jugadorPosition; // Almacena la posición del jugador

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        // Iniciar el movimiento al comienzo del juego
        StartCoroutine(MoverPeriodicamente());
    }

    void Update()
    {
        // Lógica para el disparo
        Disparar();
    }

   public IEnumerator MoverPeriodicamente()
    {
        while (true)
        {
            if (!puedeDisparar)
            {
                // Mover hacia la derecha
                Mover(new Vector2(1, 0));
                yield return new WaitForSeconds(tiempoDeEspera);

                // Mover hacia la izquierda
                Mover(new Vector2(-1, 0));
                yield return new WaitForSeconds(tiempoDeEspera);

                // Mover hacia arriba
                Mover(new Vector2(0, 1));
                yield return new WaitForSeconds(tiempoDeEspera);

                // Mover hacia abajo
                Mover(new Vector2(0, -1));
                yield return new WaitForSeconds(tiempoDeEspera);
            }
            else
            {
                // Si puede disparar, esperar antes de continuar
                yield return null;
            }
        }
    }

    void Mover(Vector2 direccion)
    {
        // Normalizar la dirección para asegurar la misma velocidad en todas las direcciones
        direccion.Normalize();
        rb2d.velocity = direccion * velocidad;

        // Actualizar las variables booleanas del Animator
        ActualizarAnimaciones(direccion);
    }

    void ActualizarAnimaciones(Vector2 direccion)
    {
        isMovingRight = direccion.x > 0;
        isMovingLeft = direccion.x < 0;
        isMovingUp = direccion.y > 0;
        isMovingDown = direccion.y < 0;
        isIdle = direccion == Vector2.zero;

        // Actualizar los booleanos en el Animator
        anim.SetBool("Right", isMovingRight);
        anim.SetBool("Left", isMovingLeft);
        anim.SetBool("Up", isMovingUp);
        anim.SetBool("Down", isMovingDown);
        anim.SetBool("Idle", isIdle);
    }

    public void ComenzarDisparo()
    {
        // Lógica para activar el disparo cuando se inicia la colisión
        puedeDisparar = true;
    }

    private void Disparar()
    {
        if (puedeDisparar)
        {
            // Lógica de disparo en la dirección almacenada del jugador
            Vector2 direccionDisparo = (jugadorPosition - (Vector2)transform.position).normalized;
            Instantiate(balaPrefab, puntoDisparo.position, Quaternion.LookRotation(Vector3.forward, direccionDisparo));
        }
    }*/
}
