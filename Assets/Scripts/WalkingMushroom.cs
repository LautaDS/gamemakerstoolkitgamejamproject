using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingMushroom : Monsters
{

    public float speed;
    public float distance;
    public LayerMask whatIsGround;
    public Transform groundDetection;
   

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent == null)
        {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.position = transform.parent.position;
        }
       
        
         RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance, whatIsGround);
         RaycastHit2D wallInfo = Physics2D.Raycast(groundDetection.position, Vector2.right, distance, whatIsGround);
       if(groundInfo.collider == false || wallInfo == true)
       {
           if (movingRight == true)
           {
               transform.eulerAngles = new Vector3(0,-180,0);
               movingRight = false;
           } else 
           {
               transform.eulerAngles = new Vector3(0,0,0);
               movingRight = true;
           }
       }
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Vector3 direction = groundDetection.transform.TransformDirection(Vector3.down) * distance;
        Gizmos.DrawRay(groundDetection.transform.position, direction);
        Vector3 horizontaldirection = groundDetection.transform.TransformDirection(Vector3.right) * distance;
        Gizmos.DrawRay(groundDetection.transform.position, horizontaldirection);
    }
}
