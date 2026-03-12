using UnityEngine;
using TMPro;
using System.Collections;

public class Timer : MonoBehaviour {

    [SerializeField] private float startSceconds = 90;
    [SerializeField] private bool useUnscaledTime = false;
    [SerializeField] private TMP_Text timerText;

    public System.Action OnTimerEnd;

    private float current;
    public float CurrentTime => current;
    void Start()
    {
        current = startSceconds;
        UpdateText(current);
        //StartCoroutine(Tick());
    }

    void Update()
    {
       

            current-=Time.deltaTime;

            UpdateText(current);
        

        if(current <= 0)
        {
            current = 0;
            OnTimerEnd ? .Invoke();
        }

    }

    private void UpdateText(float seconds)
    {
        seconds = Mathf.Max(0f, seconds);

        float m = Mathf.FloorToInt(seconds / 60);
        float s = Mathf.FloorToInt(seconds % 60);
        timerText.text = $"{m:00}:{s:00}";
    }
}


