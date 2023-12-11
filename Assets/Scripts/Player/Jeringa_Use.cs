using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Jeringa_Use : MonoBehaviour
{
    public GameObject jeringaPrefab;
    private bool invulnerable;
    private Animator animator;
    private float cooldownTime = 15f;
    private bool canUseJeringa = true;

    private void Start()
    {
        invulnerable = false;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && canUseJeringa)
        {
            UsarJeringa();
        }
    }

    public void UsarJeringa()
    {
        if (!invulnerable)
        {
            
            GameObject jeringaInstance = Instantiate(jeringaPrefab, transform.position, Quaternion.identity);

           
            jeringaInstance.transform.parent = transform;

            StartCoroutine(ActivarInvulnerabilidad());
            if (animator != null)
            {
                animator.SetBool("Invulnerable", true);
            }
        }
    }

    private IEnumerator ActivarInvulnerabilidad()
    {
        UnityEngine.Debug.Log("Usando Jeringa - activar invulnerabilidad");
        invulnerable = true;

        yield return new WaitForSeconds(10);

        invulnerable = false;
        UnityEngine.Debug.Log("Terminar invulnerabilidad");

        if (animator != null)
        {
            animator.SetBool("Invulnerable", false);
        }
    }

    public bool EstaInvulnerable()
    {
        return invulnerable;
    }
}
