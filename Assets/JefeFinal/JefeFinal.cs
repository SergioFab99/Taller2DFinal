using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JefeFinal : MonoBehaviour
{
    [Header("Cuerpo")]
    public Rigidbody2D rgb;
    Animator anim;
    [Header("Moverse")]
    public int Velocidad;
    int Direccion;
    float TimerMovimiento;
    bool Moviendose;
    [Header("Ataques")]
    public GameObject[] Ataque;
    public Transform  Spawn1, Spawn2;
    public float timer;
    int Ataques;
    bool atacando;
    bool AtacandoSinmoverse;
    [Header("Invocacion")]
    public bool Invocado;
    public GameObject ZombiePrefab;
    public int limiteSpawnZombies = 4;
    int zombiesCreados = 0;
    [Header("Dificultad")]
    public float Dificultad;
    public float Health;
    public float DañoARecibirPorBala;
    bool Fase2;

    [Header("Scenes")]
    string Victoria;
    void Start()
    {
        anim = GetComponent<Animator>();
        timer = 2.5f;
        Invocado = true;
    }


    void Update()
    {
        Movimiento();
        Comportamiento();
        Fase2State();
        MuerteJefe();
    }
    IEnumerator ataque_disparo()
    {
        if (Invocado)
        {
        Ataque[0].SetActive(true);

        Ataque[0].GetComponent<BalaEnemigo>().speed = 10f * Dificultad;
        Ataque[0].GetComponent<BalaEnemigo>().mover = true;
        AtacandoSinmoverse = true;
        if (Fase2)
        {
            yield return new WaitForSeconds(0.4f);
            Ataque[3].SetActive(true);
            Ataque[3].GetComponent<BalaEnemigo>().speed = 5f * Dificultad;
            Ataque[3].GetComponent<BalaEnemigo>().mover = true;
        }
        yield return new WaitForSeconds(1);
        AtacandoSinmoverse = false;
        }

    }
    IEnumerator SpawnZombies()
    {
        if (zombiesCreados < limiteSpawnZombies)
        {
            AtacandoSinmoverse = true;
            Ataque[1].SetActive(true);
            Ataque[2].SetActive(true);
            Moviendose = true;
            yield return new WaitForSeconds(1);
            AtacandoSinmoverse = false;
            Ataque[1].SetActive(false);
            Ataque[2].SetActive(false);

            if (zombiesCreados < limiteSpawnZombies)
            {
                Instantiate(ZombiePrefab, Spawn1.position, Quaternion.identity);
                Instantiate(ZombiePrefab, Spawn2.position, Quaternion.identity);
                zombiesCreados += 2;
            }
        }
    }
        void Comportamiento()
        {
            if (timer != 0)
            {
                timer -= 1   * Time.deltaTime * Dificultad;
            }
            if (timer <= 0)
            {
                atacando = true;
                timer = 2.5f;
                Ataques = Random.Range(1, 6);
            }
            if (Ataques == 1 || (Ataques > 2 && Ataques < 6))
            {
                StartCoroutine(ataque_disparo());
                Ataques = 0;
                atacando = false;
            }
            if (Ataques == 2 && zombiesCreados < limiteSpawnZombies)
            {
                StartCoroutine(SpawnZombies());
                Ataques = 0;
                atacando = false;
            }
        }
        void Movimiento()
        {
     
            if(AtacandoSinmoverse)
            {
            Moviendose = true;
            rgb.velocity = Vector2.zero;
            anim.SetInteger("Direccion", 0);
            anim.SetBool("Invocando", true);
            }
        else
        {
            anim.SetBool("Invocando", false);
            if (!Moviendose)
            {
                TimerMovimiento -= 1 * Time.fixedDeltaTime;
            }
            if (TimerMovimiento <= 0)
            {
                Moviendose = true;
                TimerMovimiento = 2;
                Direccion = Random.Range(1, 5);
            }
            if (Direccion == 1)
            {
                Moviendose = false;
                rgb.velocity = Vector2.right * Velocidad;
                anim.SetInteger("Direccion", 1);
            }
            if (Direccion == 2)
            {
                Moviendose = false;
                rgb.velocity = Vector2.up * Velocidad;
                anim.SetInteger("Direccion", 2);
            }
            if (Direccion == 3)
            {
                Moviendose = false;
                rgb.velocity = Vector2.left * (Velocidad);
                anim.SetInteger("Direccion", 3);
            }
            if (Direccion == 4)
            {
                Moviendose = false;
                rgb.velocity = Vector2.down * (Velocidad);
                anim.SetInteger("Direccion", 4);

            }
            
        }

    }
    void Fase2State()
    {
        if(Health <= 10f)
        {
            Dificultad = 1.4f;
            limiteSpawnZombies = 6;
            Fase2 = true;
        }
    }
    void MuerteJefe()
    {
        if(Health <= 0)
        {
            Destroy(gameObject);
            Ataque[1].SetActive(false);
            Ataque[2].SetActive(false);
            Ataque[0].SetActive(false);
            Ataque[3].SetActive(false);
            Ataque[4].SetActive(false);
            SceneManager.LoadScene(Victoria);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bala")) 
        {
            Health -= DañoARecibirPorBala;
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(collision.gameObject,2);
        }   
    }
}


