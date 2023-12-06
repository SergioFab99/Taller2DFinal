using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneSimple : MonoBehaviour
{
    public string nombrescena;
    public void ChangeScene()
    {
        SceneManager.LoadScene(nombrescena);
    }
}
