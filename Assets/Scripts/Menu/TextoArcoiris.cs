using UnityEngine;
using TMPro;

public class TextoArcoiris : MonoBehaviour
{
    public TextMeshProUGUI texto;
    public float velocidadCambioColor = 1.0f;
    public Gradient gradienteArcoiris;

    private void Update()
    {
        CambiarColorArcoiris();
    }

    void CambiarColorArcoiris()
    {
        float t = Mathf.PingPong(Time.time * velocidadCambioColor, 1f);
        Color color = gradienteArcoiris.Evaluate(t);
        texto.color = color;
    }
}