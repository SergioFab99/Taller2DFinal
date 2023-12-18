using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

public class ControladorTexto : MonoBehaviour
{

    public TextMeshProUGUI Text;
    public TextMeshProUGUI TextMision;
    public AudioSource sonido;
    public bool activar;
    public AudioClip clip1;
    public BoxCollider2D col;
    public Animator animar;

    public TextMeshProUGUI textayuda;
    void Start()
    {

    }
    void Update()
    {
        if (activar)
        {
            StartCoroutine(CambiarTextoDespuesDeEspera());
            activar = false;
            
        }

      
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            activar = true;
            animar.SetBool("Animarlo", true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            (col).enabled = false;

        }
    }
    
    IEnumerator CambiarTextoDespuesDeEspera()
    {
        sonido.PlayOneShot(clip1);
        TextoFuncion("Seishu, hola, soy tu maestra de química");
        yield return new WaitForSeconds(5f);
        TextoFuncion("Como verás, ha pasado algo fuera de lo normal...");
        yield return new WaitForSeconds(5f);
        TextoFuncion("Necesitamos tu ayuda, algunos de tus amigos y yo estamos encerrados abajo del colegio ");
        yield return new WaitForSeconds(5f);
        TextoFuncion("Tienes que encontrar la entrada y rescatarnos, por favor");
        yield return new WaitForSeconds(5f);
        animar.SetBool("Animarlo", false);
        TextoFuncion(" ");
        TextMision.text = ("Encuentra las llaves (0/3)");
        textayuda.text = ("Aprieta la letra C para ver tus nuevas misiones.");
        sonido.Stop();
    }
    void TextoFuncion(string Texto)
    {
        Text.text = Texto;
    }
}