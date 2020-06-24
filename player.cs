using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

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

            r2d.velocity = new Vector2(-1, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            r2d.velocity = new Vector2(1, 0);
        }
        else
        {
            r2d.velocity = new Vector2(0, 0);
        }
    }
}
