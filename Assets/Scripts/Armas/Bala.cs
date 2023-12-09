using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float speed = 30f;

    // El método que se ejecuta cuando se dispara la bala
    public void Disparar(Vector3 direccion)
    {
        // Asignar la dirección y velocidad al instanciar la bala
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = direccion.normalized * speed;
    }
    void update()
    {
        Destroy(gameObject, 2f);
    }
}
