using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] 
    private RectTransform rectTransform;

    [SerializeField] 
    private RectTransform[] targetRectTransform;

    [SerializeField]
    private GameObject productShelf;

    private RandamRotation[] targetItems;

    public bool GetTargetItems(int num)
    {
        return targetItems[num].IsSticker;
    }

    public int GetTargetItemsLength()
    {
        return targetItems.Length;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetItems = productShelf.GetComponentsInChildren<RandamRotation>();
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
                targetItems[i].IsSticker = true;
            }
        }
    }
}
