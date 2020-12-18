using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    private bool facingRight = false;
    public Rigidbody2D rb;
    public Animator anim;
    public float jumpForce;
    public float maxSpeed = 7f;
    public float maxAirSpeed = 25f;
    public float linearDrag = 4f;
    public float gravity = 1f;
    public float fallMultiplier = 5f;
    public float moveSpeed = 5f;
    public Vector2 direction;
    public LayerMask whatIsGround;
    private bool isGrounded;
    public Vector3 colliderOffset;
    public float groundLenght = 0.6f;
    public Transform grab;
    public float grabRange;
    public LayerMask whatIsMonsters;
    Collider2D monsterInGrab;
    private float storedGravity;
    public BoxCollider2D body;


    // Start is called before the first frame update
    void Start()
    {
         rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        anim.SetFloat("Horizontal", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("Vertical", rb.velocity.y);
        isGrounded = Physics2D.Raycast(transform.position - colliderOffset, Vector2.down, groundLenght, whatIsGround) || Physics2D.Raycast(transform.position + colliderOffset, Vector2.down, groundLenght, whatIsGround);
        anim.SetBool("IsGrounded", isGrounded);
        if(Input.GetKeyDown("space") && isGrounded)
        {
           Jump(rb);
        }

       
            
            if(Input.GetButtonDown("Fire1"))
            {
                Grab();
                AudioManagerScript.PlaySound("agarrar");
            }   
     

        if (Input.GetButtonUp("Fire1"))
        {
            Release();
        }


       if (Input.GetKeyDown("r"))
       {
           Reset();
       }
    }

    void FixedUpdate()
    {
        Walk(direction.x);
        modifyPhysics();
        if(facingRight == false && direction.x < 0)
        {
            Flip();
        } else if (facingRight == true && direction.x > 0)
        {Flip();}

    }

     void Walk(float horizontal)
    {
        rb.AddForce(Vector2.right * horizontal * moveSpeed);
        if(Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        }
    }    

     void Jump (Rigidbody2D rb)
    {
         rb.velocity = new Vector2 (rb.velocity.x, 0);
         rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
         anim.SetTrigger("Jump");
         AudioManagerScript.PlaySound("mover");
    }

      void modifyPhysics()
    {
        bool changingDirections = (direction.x > 0 && rb.velocity.x < 0) || (direction.x < 0 && rb.velocity.x > 0); 
       
       if(isGrounded) {
           if(Mathf.Abs(direction.x) < 0.4f || changingDirections) {
               rb.drag = linearDrag;
           } else {
               rb.drag = 0f;
           }
           rb.gravityScale = 0;
       } else {
           rb.gravityScale = gravity;
           rb.drag = linearDrag * 0.15f;
           if (rb.velocity.y < 0 ) {
               rb.gravityScale = gravity * fallMultiplier;
           } else if (rb.velocity.y > 0 && !Input.GetButton("Jump")){
               rb.gravityScale = gravity * (fallMultiplier / 2 );
           }
       }
    }

    void Grab()
    {
        Collider2D monsterToGrab = Physics2D.OverlapCircle(grab.position, grabRange, whatIsMonsters);
            
            if (monsterToGrab != null)
            {
            monsterToGrab.GetComponent<Transform>().position = grab.position;
            monsterToGrab.GetComponent<Transform>().parent = grab.transform;
            storedGravity = monsterToGrab.GetComponent<Rigidbody2D>().gravityScale;
            monsterToGrab.GetComponent<Rigidbody2D>().gravityScale = 0f;
            monsterInGrab = monsterToGrab;
            body.size = new Vector2(2.45f, 1.9f);
            body.offset = new Vector2(0.7f,0.045f);
            }
    }

    void Release()
    {
        if (monsterInGrab != null)
        {
            monsterInGrab.transform.parent = null;
            monsterInGrab.GetComponent<Rigidbody2D>().gravityScale = storedGravity;
            body.size = new Vector2(1.4f,1.9f);
            body.offset = new Vector2(0.1f,0.045f);
        }
    }

    void Flip()
    {
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
    }
        

    void Reset() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + colliderOffset, transform.position + colliderOffset + Vector3.down * groundLenght);
        Gizmos.DrawLine(transform.position - colliderOffset, transform.position - colliderOffset + Vector3.down * groundLenght);
    }

   
}