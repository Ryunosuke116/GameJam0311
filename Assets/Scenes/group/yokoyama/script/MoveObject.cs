using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

    private int stage = 1;
    private bool canMove=false;


    const float moveSpeed = -0.01f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canMove = false;
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 pos = transform.position;
        pos.y = -1;

        if (stage >= 1 && stage < 3 && Input.GetKey(KeyCode.A))
        {
            canMove = true;
        }

        if (canMove == true)
        {

            pos.x += moveSpeed;

        }

        if (stage == 1 && canMove == true && pos.x <= -11f)
        {
            stage = 2;
            pos.x = -11f;
            canMove = false;
        }
        else if (stage == 2 && canMove == true && pos.x <= -25f)
        {
            stage = 3;
            pos.x = -25f;
            canMove = false;
        }


        transform.position = pos;

    }

}
