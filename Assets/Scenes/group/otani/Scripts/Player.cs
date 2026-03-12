using UnityEngine;

public class Player : MonoBehaviour
{
    private float addAngle = 0.0f;
    const float MoveSpeed = 1.0f;
    [SerializeField] Camera _camera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //マウスの位置を取得
        Vector3 mousePosition=Input.mousePosition;
        Vector3 offset = _camera.transform.forward;
        //オブジェクトをマウスの座標に追従
        this.transform.position = _camera.ScreenToWorldPoint(mousePosition)+offset;
        Transform rotateAngle = this.transform;
        
        //左ボタンを押下している時
        if (Input.GetMouseButton(0))
        {
            if (addAngle >= 120.0f) return;
            addAngle += MoveSpeed;

        }
        //右ボタンを押下している時
        if (Input.GetMouseButton(1))
        {
            if (addAngle <= -40.0f) return;
            addAngle -= MoveSpeed;

        }
        transform.rotation = Quaternion.Euler(0,0,addAngle);
    }
}
