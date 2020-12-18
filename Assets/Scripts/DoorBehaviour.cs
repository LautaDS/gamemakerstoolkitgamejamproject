using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public GameObject block;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Monster" || other.tag == "Cube")
        {
            block.SetActive(false);
            AudioManagerScript.PlaySound("boton");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Cube")
        {
            block.SetActive(true);
        }
    }
}
