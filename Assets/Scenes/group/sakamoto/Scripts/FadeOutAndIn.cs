using UnityEngine;
using UnityEngine.UI;

public class FadeOutAndIn : MonoBehaviour
{
    [SerializeField]
    private float fadeSpeed = 0.01f;

    float alpha = 0;
    float red, green, blue;
    private bool isFadeOut = false;
    private bool isFadeIn = false;

    public bool IsFadeOut
    {
        get { return isFadeOut; }
        set { isFadeOut = value; }
    }

    public bool IsFadeIn
    {
        get { return isFadeIn; }
        set { isFadeIn = value; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Image>().color = new Color(red, green, blue, alpha);
        alpha = alpha + (fadeSpeed * Time.deltaTime);
    }
}
