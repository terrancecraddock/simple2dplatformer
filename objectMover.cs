using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectMover : MonoBehaviour
{
    [SerializeField] float moveDistance = 1f;
    Rigidbody2D r2d;
    bool movingUp = false;
    bool movingDown = false;

    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        moveUp();
    }


    void Update()
    {
        if (!movingUp)
        {
            moveDown();
        }
        if (!movingDown)
        {
            moveUp();
        }
    }
    void moveUp()
    {
        movingUp = true;
        r2d.velocity = new Vector2(0, 1);
        if (transform.position.y >= moveDistance)
        {
            r2d.velocity = new Vector2(0, 0);
            movingUp = false;
        }

    }
    void moveDown()
    {
        movingDown = true;
        r2d.velocity = new Vector2(0, -1);
        if (transform.position.y <= -moveDistance)
        {
            r2d.velocity = new Vector2(0, 0);
            movingDown = false;
        }

    }
}
