using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

    private int stage = 1;
    private float moveDistance = 3.5f;
    private bool canMove=false;
    private int STAGE_MAX = 0;

    const float MOVE_SPEED = -0.01f;
    const float MOVE_DIST = -14.5f;

    private checkNextStage[] NextStage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stage = 1;
        moveDistance = 3.5f;
        canMove = false;

        NextStage = gameObject.GetComponentsInChildren<checkNextStage>();
        STAGE_MAX = gameObject.transform.childCount - 1;

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 pos = transform.position;
        pos.y = -0.85f;

        // 次のステージに進むことができる場合、オブジェクトを左に移動させる
        if (stage < STAGE_MAX && canMove == false && NextStage[stage].GetIsNextStage() == true)
        {

            canMove = true;
            moveDistance += MOVE_DIST;
            stage++;
           
        }

        // オブジェクトが移動できる場合、オブジェクトを左に移動させる
        if (canMove == true)
        {

            pos.x += MOVE_SPEED;

        }

        // 一定の移動距離を超えた場合、オブジェクトの位置を移動距離に固定し、移動できないようにする
        if (moveDistance > pos.x)  
        {

            pos.x = moveDistance;
            canMove = false;
            

        }


        transform.position = pos;
       
    }

}
