using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CambioDeEscena : MonoBehaviour
{
    float timer = 6; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            SceneManager.LoadScene("Nivel1"); 
        }
    }
    
}
