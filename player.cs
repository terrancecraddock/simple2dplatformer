using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] int moveSpeed = 3;
    [SerializeField] int jumpHeight = 4;
    AudioSource jumpSound;
    Rigidbody2D r2d;
    BoxCollider2D bc2D;
    
    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigid Body 2D Component
        r2d = GetComponent<Rigidbody2D>();
        bc2D = GetComponent<BoxCollider2D>();
        jumpSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            // Apply movement velocity

            r2d.velocity = new Vector2(-moveSpeed, 0);
            if (Input.GetKey(KeyCode.Space))
            {
                
                    playerJump();
                
                
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            r2d.velocity = new Vector2(moveSpeed, 0);
            if (Input.GetKey(KeyCode.Space))
            {
                
                    playerJump();
                
            }
        }
        else if(Input.GetKey(KeyCode.Space))
        {
           
                playerJump();
            

        }
        else
        {
            //r2d.velocity = new Vector2(0, 0);
        }
    }
    // called when the player hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {      
        if (col.collider.tag == "coin")
        {
            
            Destroy(col.gameObject);
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
      
    }
    private bool IsGrounded()
    {
        float extraHeightTest = 0.1f; //makes math less precise and thus better for this
        RaycastHit2D raycastHit = Physics2D.Raycast(bc2D.bounds.center, Vector2.down, bc2D.bounds.extents.y + extraHeightTest, groundLayerMask);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(bc2D.bounds.center, Vector2.down * (bc2D.bounds.extents.y + extraHeightTest));
        return raycastHit.collider != null;
    }
    void playerJump()
    {
        if (IsGrounded())
        {
            jumpSound.Play();
            r2d.velocity = new Vector2(0, jumpHeight);
        }
        else
        {
            r2d.velocity = new Vector2(0, 0);
        }
    }
}
