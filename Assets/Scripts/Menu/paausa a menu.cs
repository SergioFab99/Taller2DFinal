using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class paausaamenu : MonoBehaviour
{

    public GameObject pausa;
    public GameObject canvaseventos;
    public GameObject virtuual;
    public GameObject caamera;
    public GameObject evento;
    public GameObject hud;
    public GameObject player;
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        pausa.SetActive(false);
        canvaseventos.SetActive(false);
        virtuual.SetActive(false);
        caamera.SetActive(false);
        evento.SetActive(false);
        hud.SetActive(false);
        player.SetActive(false);

    }
}

