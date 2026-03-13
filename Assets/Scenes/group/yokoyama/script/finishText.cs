using UnityEngine;
using TMPro;

public class finishTimer : MonoBehaviour
{

    [SerializeField] private TMP_Text countDownText; 
    [SerializeField] private MoveObject moveObject;
    [SerializeField] private SceneTransitionButton sceneManager;

    private const float FONT_SIZE_MAX = 100f;
    private const float FONT_SIZE_MIN = 20f;
    private const float FONT_SIZE_CHANGE_SPEED = -0.5f;
    private float fontSize = FONT_SIZE_MIN;

    private void Start()
    {

        countDownText.text = "";
        fontSize = FONT_SIZE_MAX;
 
    }

    private void Update()
    {

       if(moveObject.GetIsFinished() == true)
       {
           countDownText.text = "finish!";
          
            fontSize += FONT_SIZE_CHANGE_SPEED;

            if (fontSize < FONT_SIZE_MIN)
            {

                fontSize = FONT_SIZE_MIN;
                sceneManager.IsInResult = true;

            }
       }
       else
       {
           countDownText.text = "";
       }

        countDownText.fontSize = fontSize;
    
    }

}