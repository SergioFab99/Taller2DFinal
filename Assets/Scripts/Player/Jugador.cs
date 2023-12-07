using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float rangoAtaque = 2f; // Alcance del ataque cuerpo a cuerpo
    public LayerMask capaEnemigos; // Capa para identificar enemigos
    
    Animator animacion;

    private Rigidbody2D rb2d;
    private bool mirandoDerecha = true;
    private Camera cam;

    void Start()
    {  
        rb2d = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        animacion = GetComponent<Animator>();
    }

    void Update()
    {
        MoverJugador();
        RotarJugador();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Se activa el cuerpo a cuerpo");
            AtaqueCuerpoACuerpo();
        }
    }

    void MoverJugador()
    {
        float movimientoHorizontal = Input.GetAxisRaw("Horizontal");
        float movimientoVertical = Input.GetAxisRaw("Vertical");
        Vector2 velocidad = new Vector2(movimientoHorizontal, movimientoVertical).normalized * velocidadMovimiento;
        rb2d.velocity = velocidad;
        animacion.SetFloat("horizontal", Mathf.Abs(rb2d.velocity.x));
        animacion.SetFloat("vertical", Mathf.Abs(rb2d.velocity.y));
        if (rb2d.velocity.x > 0)
        {
         animacion.SetBool("izquierda", false);
        }
        else 
        {
         animacion.SetBool("izquierda", true);
        }
        if (rb2d.velocity.y > 0) 
        {
         animacion.SetBool("arriba", true);        
        }
        else
        {
         animacion.SetBool("arriba", false);
        }
    }


    void RotarJugador()
    {
        
       
    }

    void AtaqueCuerpoACuerpo()
    {
        Debug.Log("Atacando...");

        // Detectar enemigos dentro del rango de ataque
        Collider2D[] enemigosGolpeados = Physics2D.OverlapCircleAll(transform.position, rangoAtaque, capaEnemigos);

        foreach (var enemigo in enemigosGolpeados)
        {
            // Comprobar si el objeto tiene el tag "Enemy"
            if (enemigo.CompareTag("Enemy"))
            {
                Destroy(enemigo.gameObject); // Destruir el objeto enemigo
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BulletEnemy"))
        {
            SceneManager.LoadScene("Derrota");
        }
    }

    void OnDrawGizmosSelected()
    {
        // Esto es para visualizar el rango de ataque en el editor de Unity
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoAtaque);
    }
}
