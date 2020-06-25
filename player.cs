﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] int moveSpeed = 3;
    [SerializeField] int jumpHeight = 4;
    bool isGrounded = false;
    Rigidbody2D r2d;
    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigid Body 2D Component
        r2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            // Apply movement velocity

            r2d.velocity = new Vector2(-moveSpeed, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            r2d.velocity = new Vector2(moveSpeed, 0);
        }
        else if(Input.GetKey(KeyCode.Space))
        {
            if(isGrounded)
            {
                r2d.velocity = new Vector2(0, jumpHeight);
            }else
            {
                r2d.velocity = new Vector2(0, 0);
            }
           
        }
        else
        {
            r2d.velocity = new Vector2(0, 0);
        }
    }
    // called when the player hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "ground")
        {
            isGrounded = !isGrounded;
        }
        if (col.collider.tag == "coin")
        {
            
            Destroy(col.gameObject);
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if(isGrounded)
        {
            isGrounded = !isGrounded;
        }
    }
}
