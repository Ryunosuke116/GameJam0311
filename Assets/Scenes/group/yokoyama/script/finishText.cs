using UnityEngine;
using TMPro;

public class finishTimer : MonoBehaviour
{

    [SerializeField] private TMP_Text countDownText; 
    [SerializeField] private MoveObject moveObject;
    [SerializeField] private SceneTransitionButton sceneManager;

    private void Start()
    {

        countDownText.text = "";

    }

    private void Update()
    {

       if(moveObject.GetIsFinished())
       {
           countDownText.text = "finish!";
            sceneManager.IsInTitle = true;
       }
       else
       {
           countDownText.text = "";
        }

    }

}