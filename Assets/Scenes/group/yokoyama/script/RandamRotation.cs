using UnityEngine;
using System.Collections;

public class RandamRotation : MonoBehaviour
{
    private bool isPasted = false;
    private bool isSticker = false;

    const float MOVE_SPEED = 0.01f;
    const float MOVE_DIST = 8f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        const float rotationMax = 360.0f;
        const float rotationMin = 0.0f;

        // ランダムな回転角度を生成
        Vector3 rotation;
        rotation.z = Random.Range(rotationMin, rotationMax);
       transform.localEulerAngles = new Vector3(0, 0, rotation.z);

        isSticker = false;
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 pos = transform.position;

        // Dキーを押すとステッカーの表示/非表示を切り替える
        if (Input.GetKeyDown(KeyCode.D))
        {
            isSticker = !isSticker;

        }

        // ステッカーの表示/非表示を切り替える
        transform.GetChild(0).gameObject.SetActive(isSticker);

        // ステッカーが表示されている場合は、オブジェクトを上に移動させる
        if (isSticker == true)
        {
            isPasted = true;
        }

        if(isPasted == true)
        {
            pos.y += MOVE_SPEED;
        }

        if(pos.y > MOVE_DIST)
        {
            pos.y = MOVE_DIST;
            isPasted = false;
        }


        transform.position = pos;
    }

    public bool GetIsSticker()
    {
        return isSticker;
    }

}
