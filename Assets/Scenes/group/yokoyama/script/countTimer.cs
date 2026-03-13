using UnityEngine;
using TMPro;

public class countTimer : MonoBehaviour
{

    [SerializeField] private TMP_Text countDownText; 
    [SerializeField] private MoveObject moveObject;  

    private void Start()
    {

        countDownText.text = "3";

    }

    private void Update()
    {

        int countValue = moveObject.GetCountDownTimer(); 

        switch (countValue)
        {

            case 3: countDownText.text = "3"; break;
            case 2: countDownText.text = "2"; break;
            case 1: countDownText.text = "1"; break;
            case 0: countDownText.text = "start"; break;
            default: countDownText.text = ""; break;

        }

    }

}