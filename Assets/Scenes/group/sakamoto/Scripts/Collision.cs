using UnityEngine;

public class Collision : MonoBehaviour
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
