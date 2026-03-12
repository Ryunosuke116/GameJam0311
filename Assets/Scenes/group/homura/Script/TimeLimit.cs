using System.Runtime.CompilerServices;
using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.UI;
public class TimeLimit
{
    [Header("Refs")]
    [SerializeField] private Image overlay;

    [Header("Timer")]
    [SerializeField] private float maxTime = 90f;
    [SerializeField] private bool useUnscaledTime = false;

    [Header("Blink Settings")]
    [SerializeField] private float blinkStartAt = 10f;
    [SerializeField] private float blinkpPeriod = 1f;
    [SerializeField, Range(0f, 1f)] private float maxAlpha = 0.6f;

    private float current;
    private bool ended;

    void Start()
    {
        if (maxTime <= 0f) maxTime = 1f;
        current = maxTime;

        SetOverlayAlpha(0f);
    }

    void Update()
    {
        if (ended) return;

        current = Mathf.Max(0f, current - Time.deltaTime);

        if(current <= blinkStartAt && current > 0f)
        {
            float t = Mathf.PingPong((blinkStartAt - current) / blinkpPeriod, 1f);
            float a = Mathf.Lerp(0f, maxAlpha, t);
            
        }
    }

    private void SetOverlayAlpha(float a)
    {
        var c = overlay.color;
        c.a = a;
        overlay.color = c;
    }
}