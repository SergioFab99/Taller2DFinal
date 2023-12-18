using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float velocidadMovimiento = 5.0f;
    private Rigidbody2D rb2d;
    public Animator animacion;

    public ControlArmas control;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animacion = GetComponent<Animator>();
    }
    private void Start()
    {
        control = GetComponent<ControlArmas>(); 
        animacion.SetBool("izquierda", false);
    }
    void Update()
    {
        MoverJugador();
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(control.activarevolver)
        {
            if ((collision.gameObject.CompareTag("Pistola")))
            {
                animacion.SetBool("TienePistola", true);
            }
        }

        if ((collision.gameObject.CompareTag("akm")))
        {
            animacion.SetBool("TieneMetralleta", true);
            
            
        }
       
    }
}
