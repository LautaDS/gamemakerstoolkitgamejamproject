using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey)
        {
             StartCoroutine(Ending());
        }
    }

    IEnumerator Ending()
    {
        yield return new WaitForSeconds(1f);
        Application.Quit();
    }
}
