using UnityEngine;
using System.Collections;

public class Pistola : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float velocidadDisparo = 10f;
    private float cooldown = 1f;
    private float tiempoUltimoDisparo;
    public new Camera camera;
    public Transform spawner;

    // Escala original de la pistola
    private Vector3 escalaOriginal;

    void Start()
    {
        camera = Camera.main; // Busca la cámara principal
        // Guarda la escala original al inicio
        escalaOriginal = transform.localScale;
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
        Vector3 mouseDirection = mouseWorldPosition - transform.position;
        mouseDirection.z = 0;
        transform.right = mouseDirection;
        // Mantén la escala original de la pistola
        transform.localScale = escalaOriginal;
    }

    void Disparar()
    {
        GameObject bullet = Instantiate(bulletPrefab, spawner.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * velocidadDisparo;
    }
}
