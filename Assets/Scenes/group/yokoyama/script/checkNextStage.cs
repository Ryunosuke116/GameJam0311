using UnityEngine;

public class checkNextStage : MonoBehaviour
{
    
    private bool isNextStage = false; 
    
    private RandamRotation[] randamRotations;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        randamRotations = gameObject.GetComponentsInChildren<RandamRotation>();
    
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public bool GetIsNextStage()
    {

        for (int i = 0; i < randamRotations.Length; i++)
        {
           
            if (randamRotations[i].GetIsSticker() == false)
            {
                return false;
            }
           
        }
        return true;
    }

}
