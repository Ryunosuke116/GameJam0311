using UnityEngine;

public class checkNextStage : MonoBehaviour
{
    
    private bool isNextStage = false; 
    private bool isAllStickerPasted = false;

    private int childNum = 0;

    private RandamRotation[] randamRotations;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        randamRotations = gameObject.GetComponentsInChildren<RandamRotation>();

    }

    // Update is called once per frame
    void Update()
    {

        // 子オブジェクトのRandamRotationコンポーネントを取得
        foreach (RandamRotation randamRotation in randamRotations)
        {

            // RandamRotationコンポーネントのisStickerがtrueの場合、childNumを増やす
            if (randamRotation.GetIsSticker() == true)
            {
                childNum++;
            }
        }
        // childNumがrandamRotationsの数と等しい場合、isAllStickerPastedをtrueにする
        if (childNum == randamRotations.Length)
        {
            isAllStickerPasted = true;
        }
        // isNextStageをtrueにする
        if (isAllStickerPasted == true)
        {
            isNextStage = true;
        }

    }

    
    public bool GetIsNextStage()
    {
        return isNextStage;
    }

}
