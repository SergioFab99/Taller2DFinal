using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class Creditos : MonoBehaviour
{
    Image ima; 
    // Start is called before the first frame update
    void Awake()
    {
        ima = GetComponent<Image>();
        StartCoroutine(showcredits()); 
    }

    IEnumerator showcredits() 
    { 
    int count = 0;  
        while (true) 
        {
            count++;
            while(ima.fillAmount <= count * (1f / 6f)) 
            {
                ima.fillAmount += Time.deltaTime / 10;
                yield return null;
            }
            yield return new WaitForSeconds(1); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
