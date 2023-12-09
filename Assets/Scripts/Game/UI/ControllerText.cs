using UnityEngine;
using TMPro;
using System.Collections;

public class ControladorTexto : MonoBehaviour
{

    public TextMeshProUGUI Text;
    public AudioSource sonido;
    public bool activar;
    public AudioClip clip1;

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
        }
    }

       IEnumerator CambiarTextoDespuesDeEspera()
    {
        sonido.PlayOneShot(clip1);
        TextoFuncion("Seishu, hola, soy tu maestra de quimica");
        yield return new WaitForSeconds(5f);
        TextoFuncion("Como veras, ha pasado algo muy extraño...");
        yield return new WaitForSeconds(5f);
        TextoFuncion("Necesitamos tu ayuda, varios de tus compañeros y yo estamos encerrados abajo del colegio,");
        yield return new WaitForSeconds(5f);
        TextoFuncion("Tienes que encontrar la entrada y rescatarnos, por favor");
        yield return new WaitForSeconds(5f);
        sonido.Stop();
    }
    void TextoFuncion(string Texto)
    {
        Text.text = Texto;
    }
}