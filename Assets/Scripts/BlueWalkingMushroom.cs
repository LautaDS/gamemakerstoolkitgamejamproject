using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueWalkingMushroom : Monsters
{

    public float speed;
    public float distance;
    public LayerMask whatIsGround;
 
    public Transform wallDetection;

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
        RaycastHit2D wallInfo = Physics2D.Raycast(wallDetection.position, Vector2.right, distance/2, whatIsGround);

       if(wallInfo == true)
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
        Vector3 direction = wallDetection.transform.TransformDirection(Vector3.right) * distance;
        Gizmos.DrawRay(wallDetection.transform.position, direction);
    }
}
