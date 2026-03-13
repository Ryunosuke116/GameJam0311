using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

    private float countDownTimer = 4f;
    private bool isStartCountDown = true;
    private bool isStarted = false;
    private const float COUNT_DOWN_TIME = 4f;

    private bool isFinished = false;

    private int stage = 0;
    private float moveDistance = 21.5f;
    private bool canMove=false;
    private int STAGE_MAX = 0;
    private const float MOVE_SPEED = -0.02f;
    private const float MOVE_DIST = -18f;

    private checkNextStage[] NextStage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        countDownTimer = COUNT_DOWN_TIME;
        isStartCountDown = true;
        isStarted = false;

        isFinished = false;

        stage = 0;
        moveDistance = 21.5f;
        canMove = false;

        NextStage = gameObject.GetComponentsInChildren<checkNextStage>();
        STAGE_MAX = gameObject.transform.childCount - 2;

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 pos = transform.position;
        pos.y = -0.85f;

        // ゲームが開始した瞬間にカウントダウンタイマーを開始する
        if (isStartCountDown == true)
        {
            countDownTimer -= Time.deltaTime;
          
            if (countDownTimer < 0)
            {
                isStarted = true;
                countDownTimer = 0f;
                isStartCountDown = false;
            }

        }

        if(isStarted == true)
        {
            canMove = true;
            moveDistance += MOVE_DIST;
            isStarted = false;
        }

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

        if(stage == STAGE_MAX && NextStage[stage].GetIsNextStage() == true)
        {
            isFinished = true;
        }


        transform.position = pos;

    }

    public int GetCountDownTimer()
    {
        return (int)countDownTimer;
    }

    public bool GetIsFinished()
    {
        return isFinished;
    }

}
