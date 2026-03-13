using UnityEngine;
using UnityEngine.UI;

public class FadeOutAndIn : MonoBehaviour
{
    [SerializeField]
    private float fadeSpeed = 0.3f;

    [SerializeField]
    private Image overlay;

    private float alpha = 1;
    float red, green, blue;
    private bool isFadeOut = false;
    private bool isFadeIn = false;
    private bool isFirstFadeOut = true;

    public float Alpha
    {
        get { return alpha; }
        set { alpha = value; }
    }

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

    public void AlphaChangeMax()
    {
        alpha = 255;
    }

    public void AlphaChangeMin()
    {
        alpha = 0;
    }

    public void UpdateAlphaAdd()
    {
        GetComponent<Image>().color = new Color(red, green, blue, alpha);
        alpha = alpha + (fadeSpeed * Time.deltaTime);

        if (alpha > 1.0f)
        {
            alpha = 1.0f;
        }
    }

    public void UpdateAlphaSub()
    {
        GetComponent<Image>().color = new Color(red, green, blue, alpha);
        alpha = alpha - (fadeSpeed * Time.deltaTime);

        if(alpha < 0)
        {
            alpha = 0;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
        GetComponent<Image>().color = new Color(red, green, blue, alpha);
    }

    // Update is called once per frame
    void Update()
    {
        if(isFirstFadeOut)
        {
            var colorData = overlay.color;

            colorData.a = alpha;
            overlay.color = colorData;

            alpha = alpha - (fadeSpeed * Time.deltaTime);
            Debug.Log($"{alpha}");

            if (alpha < 0)
            {
                alpha = 0;
                isFirstFadeOut = false;
                gameObject.SetActive(false);
            }
        }
    }
}
