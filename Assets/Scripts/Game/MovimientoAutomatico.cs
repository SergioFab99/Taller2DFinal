using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoAutomatico : MonoBehaviour
{
    public GameObject player, direccion1, direccion2, direccion3, direccion4, direccion5;
    bool Seguir;
    float angulo;
    float angulo2;
    bool Patron1, Patron2, Patron3, Patron4, Patron5, termina;
    public bool Siguiendo, Sangrando = true;
    public float Velocidad;
    public bool muerta;
    Rigidbody2D rgb;
    Rigidbody2D rgbSobreviviente;
    public float PosicionCompaR;
    public float PosicionCompaL;
    BoxCollider2D Area;
    CapsuleCollider2D Box;
    int direccionAnimator, direccionanimator2, direccionanimator3, direccionanimator4, direccionanimator5 = 0;
    Animator anim;

    void Start()
    {
        Seguir = false;
        Siguiendo = false;
        termina = false;
        muerta = false;
        player = GameObject.Find("Player");
        rgb = player.GetComponent<Rigidbody2D>();
        rgbSobreviviente = GetComponent<Rigidbody2D>();
        Area = GetComponentInChildren<BoxCollider2D>();
        OnTriggerEnter2D(Area);
        Box = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        rgbSobreviviente.constraints = RigidbodyConstraints2D.FreezeAll;


    }

    
    // Update is called once per frame
    void Update()
    {
        if(!muerta)
        {
            float umbral = 1f;
            if (!termina && Siguiendo)
            {
                Seguir = true;
                Area.enabled = false;

                if (Seguir && Siguiendo)
                {
                    Patron1 = true;
                }
            }
            if (Patron1)
            {
                Vector2 direccionCamino1 = (direccion1.transform.position - transform.position).normalized;

                gameObject.transform.Translate(direccionCamino1 * Time.fixedDeltaTime * Velocidad);
                angulo = Mathf.Atan2(direccionCamino1.y, direccionCamino1.x) * Mathf.Rad2Deg;
                if (angulo > -45f && angulo <= 45f)
                {
                    direccionAnimator = 2; //derecha
                }
                else if (angulo > 45f && angulo <= 135f)
                {
                    direccionAnimator = 3; // arriba
                }
                else if (angulo > -135 && angulo <= -45f)
                {
                    direccionAnimator = 1; // abajo
                }
                else
                {
                    direccionAnimator = 4; // izquierda
                }
                anim.SetInteger("Direccion", direccionAnimator);
                anim.SetBool("Seguir", Seguir);
                anim.SetBool("Sangre", true);
                if (Vector2.Distance(transform.position, direccion1.transform.position) <= umbral)
                {
                    Patron1 = false;
                    Siguiendo = false;
                    anim.SetBool("Seguir", false);


                }
            }
            if (!Sangrando)
            {
                anim.SetBool("Sangre", false);
                if (direccion2 != null)
                {
                    Patron2 = true;
                }

            }

            if (Patron2)
            {
                Sangrando = true;
                Vector2 direccionCamino2 = (direccion2.transform.position - transform.position).normalized;

                gameObject.transform.Translate(direccionCamino2 * Time.fixedDeltaTime * Velocidad);
                angulo = Mathf.Atan2(direccionCamino2.y, direccionCamino2.x) * Mathf.Rad2Deg;
                if (angulo > -45f && angulo <= 45f)
                {
                    direccionanimator2 = 2; //derecha
                }
                else if (angulo > 45f && angulo <= 135f)
                {
                    direccionanimator2 = 3; // arriba
                }
                else if (angulo > -135 && angulo <= -45f)
                {
                    direccionanimator2 = 1; // abajo
                }
                else
                {
                    direccionanimator2 = 4; // izquierda
                }
                anim.SetInteger("Direccion", direccionanimator2);
                anim.SetBool("Seguir", Seguir);
                if (Vector2.Distance(transform.position, direccion2.transform.position) <= umbral)
                {
                    Patron2 = false;
                    if (direccion3 != null)
                    {
                        Patron3 = true;


                    }
                    else
                    {
                        anim.SetInteger("Direccion", 0);
                        anim.SetBool("Seguir", false);
                        termina = true;
                    }
                }
            }
            if (Patron3)
            {
                Vector2 direccionCamino3 = (direccion3.transform.position - transform.position).normalized;

                gameObject.transform.Translate(direccionCamino3 * Time.fixedDeltaTime * Velocidad);
                angulo = Mathf.Atan2(direccionCamino3.y, direccionCamino3.x) * Mathf.Rad2Deg;
                if (angulo > -45f && angulo <= 45f)
                {
                    direccionanimator3 = 2; //derecha
                }
                else if (angulo > 45f && angulo <= 135f)
                {
                    direccionanimator3 = 3; // arriba
                }
                else if (angulo > -135 && angulo <= -45f)
                {
                    direccionanimator3 = 1; // abajo
                }
                else
                {
                    direccionanimator3 = 4; // izquierda
                }
                anim.SetInteger("Direccion", direccionanimator3);
                anim.SetBool("Seguir", Seguir);
                if (Vector2.Distance(transform.position, direccion3.transform.position) <= umbral)
                {
                    Patron3 = false;
                    if (direccion4 == null)
                    {
                        anim.SetInteger("Direccion", 0);
                        anim.SetBool("Seguir", false);
                        termina = true;
                    }
                    else
                    {
                        Patron4 = true;
                    }
                }
            }
            if (Patron4)
            {

                Vector2 direccionCamino4 = (direccion4.transform.position - transform.position).normalized;

                gameObject.transform.Translate(direccionCamino4 * Time.fixedDeltaTime * Velocidad);
                angulo = Mathf.Atan2(direccionCamino4.y, direccionCamino4.x) * Mathf.Rad2Deg;
                if (angulo > -45f && angulo <= 45f)
                {
                    direccionanimator4 = 2; //derecha
                }
                else if (angulo > 45f && angulo <= 135f)
                {
                    direccionanimator4 = 3; // arriba
                }
                else if (angulo > -135 && angulo <= -45f)
                {
                    direccionanimator4 = 1; // abajo
                }
                else
                {
                    direccionanimator4 = 4; // izquierda
                }
                anim.SetInteger("Direccion", direccionanimator4);
                anim.SetBool("Seguir", Seguir);
                if (Vector2.Distance(transform.position, direccion4.transform.position) <= umbral)
                {
                    Patron4 = false;
                    if (direccion5 != null)
                    {
                        Patron5 = true;


                    }
                    else
                    {
                        anim.SetInteger("Direccion", 0);
                        anim.SetBool("Seguir", false);
                        termina = true;
                    }
                }
            }
            if (Patron5)
            {

                Vector2 direccionCamino5 = (direccion5.transform.position - transform.position).normalized;

                gameObject.transform.Translate(direccionCamino5 * Time.fixedDeltaTime * Velocidad);
                angulo = Mathf.Atan2(direccionCamino5.y, direccionCamino5.x) * Mathf.Rad2Deg;
                if (angulo > -45f && angulo <= 45f)
                {
                    direccionanimator5 = 2; //derecha
                }
                else if (angulo > 45f && angulo <= 135f)
                {
                    direccionanimator5 = 3; // arriba
                }
                else if (angulo > -135 && angulo <= -45f)
                {
                    direccionanimator5 = 1; // abajo
                }
                else
                {
                    direccionanimator5 = 4; // izquierda
                }
                anim.SetInteger("Direccion", direccionanimator5);
                anim.SetBool("Seguir", Seguir);
                if (Vector2.Distance(transform.position, direccion5.transform.position) <= umbral)
                {
                    Patron5 = false;


                    anim.SetInteger("Direccion", 0);
                    anim.SetBool("Seguir", false);
                    termina = true;

                }
            }
        }
        else
        {
            anim.SetBool("Muerta", true);
        }
        
        


    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Siguiendo = true;
        }

    }

}