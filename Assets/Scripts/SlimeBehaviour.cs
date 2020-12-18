using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBehaviour : Monsters
{

    public float timer = 3f;
    private float startingTimer;
    public float force;
    Rigidbody2D rb;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        startingTimer = timer;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0.1f)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = startingTimer;
            if (this.transform.parent == null)
            {
            Jump();
            } 
        }

        if (this.transform.parent != null)
        {
            this.transform.position = this.transform.parent.position;
        }

    }
    
    void Jump()
    {
        if(transform.parent == null)
        {
        if (movingRight == true)
        {
            rb.AddForce(Vector2.one * force, ForceMode2D.Impulse);
            movingRight = false;
            transform.eulerAngles = new Vector3(0,-180,0);
            movingRight = false;
            anim.SetTrigger("Jump");
        }
        else
        {
            rb.AddForce(new Vector2(-1,1) * force, ForceMode2D.Impulse);
            movingRight = true;
            transform.eulerAngles = new Vector3(0,0,0);
            movingRight = true;
            anim.SetTrigger("Jump");
        }
        }
    }

   
   
}
