using System.Runtime.CompilerServices;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private RectTransform[] targetRectTransform;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 addPos = new Vector3(0.0f, 0.0f, 0.0f);

        if (Input.GetKey(KeyCode.W))
        {
            addPos.y = 15.0f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            addPos.y = -15.0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            addPos.x = 15.0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            addPos.x = -15.0f;
        }

        transform.position = transform.position + (addPos * Time.deltaTime);
    
        //èdÇ»Ç¡ÇƒÇ¢ÇÈÇ©
        for (int i = 0; i < targetRectTransform.Length; i++)
        {
            if (rectTransform.IsOverLapping(targetRectTransform[i]))
            {
                Debug.Log("Ç†ÇΩÇ¡ÇΩ");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("ìñÇΩÇ¡ÇΩ");
    }
}
