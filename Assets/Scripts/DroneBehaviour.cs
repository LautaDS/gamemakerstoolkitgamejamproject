using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBehaviour : Monsters
{
    public float speed;
    public float distance;
    public Transform wallDetection;
    float timeToRegrab = 1.0f;
    public Transform areaOfGrab;
    public float grabRange;
    public LayerMask whatIsCube;
    public LayerMask whatIsWall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeToRegrab >= 0f)
        {
            timeToRegrab -= Time.deltaTime;
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D wallInfo = Physics2D.Raycast(wallDetection.position, Vector2.right, distance, whatIsWall);
      
       if(wallInfo.collider == true)
       {
           if(this.transform.parent == false)
           {
           if (movingRight == true)
           {
               transform.eulerAngles = new Vector3(0,-180,0);
               movingRight = false;
               ReleaseGrab();
           } else 
           {
               transform.eulerAngles = new Vector3(0,0,0);
               movingRight = true;
               ReleaseGrab();
           }
           } else
           {
               transform.position = transform.parent.position;
           }
       }

         Grab();
    }

    void Grab()
    {
        RaycastHit2D searchForCube = Physics2D.Raycast(areaOfGrab.position, Vector2.down, distance, whatIsCube);
        if (searchForCube == true && timeToRegrab <= 0f)
        {
            Collider2D[] cubesToGrab = Physics2D.OverlapCircleAll(areaOfGrab.position, grabRange, whatIsCube);
            cubesToGrab[0].GetComponent<Transform>().position = areaOfGrab.position;
        }
    }

    void ReleaseGrab()
    {
        timeToRegrab = 0.5f;
        

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 direction = areaOfGrab.transform.TransformDirection(Vector3.down) * distance;
        Gizmos.DrawRay(areaOfGrab.transform.position, direction);

        Vector3 wallDirection = wallDetection.transform.TransformDirection(Vector3.right) * distance;
        Gizmos.DrawRay(wallDetection.transform.position, wallDirection);
    }

}
