using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

    private int stage = 1;
    private float moveDistance = 3.5f;
    private bool canMove=false;

    const float MOVE_SPEED = -0.01f;
    const float MOVE_DIST = -14.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stage = 1;
        moveDistance = 3.5f;
        canMove = false;
       
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 pos = transform.position;
        pos.y = -0.85f;

        if (canMove ==false && Input.GetKeyDown(KeyCode.A))
        {

            canMove = true;
            moveDistance += MOVE_DIST;
           
        }

        if (canMove == true)
        {

            pos.x += MOVE_SPEED;

        }

        if (moveDistance > pos.x)  
        {

            switch (stage)
            {
                case 1:

                    stage = 2;
                   
                    break;

                case 2:

                    stage = 3;
                    
                    break;

                case 3:

                    stage = 4;

                    break;

            }

            pos.x = moveDistance;
            canMove = false;

        }


        transform.position = pos;

    }

}
