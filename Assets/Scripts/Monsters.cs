using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsters : MonoBehaviour
{
    public bool movingRight = false;

    public void DirectionOfMovement(bool movingRight)
    {
        this.movingRight = movingRight;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Goal")
        {
            this.gameObject.SetActive(false);
        }
    }

   
}
