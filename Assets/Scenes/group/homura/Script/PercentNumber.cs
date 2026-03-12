
using UnityEngine;
using UnityEngine.UI;

public class PercentNumber : MonoBehaviour
{
    [SerializeField] private Slider progress;
    [SerializeField] private float maxTime = 90f;

    private float current;

    private void Start()
    {
        if (progress == null)
        {
            Debug.LogError("Slider がセットされていません");
            enabled = false;
            return;
        }

        if (maxTime <= 0f) maxTime = 1f;

        progress.minValue = 0;
        progress.maxValue = maxTime;

        current = maxTime;
        progress.value = current;
    }

    private void Update()
    {
        current = Mathf.Max(0f, current - Time.deltaTime);
        progress.value = current;

        if (current <= 0f)
        {
            // 必要なら終了処理
        }
    }
}
