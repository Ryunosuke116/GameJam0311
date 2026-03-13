using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Object = UnityEngine.Object;

[RequireComponent(typeof(Button))]
public class SceneTransitionButton : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private GameObject gameObjectFadeOutAndIn;

    public GameObject scoreManagerPrefab;
    private FadeOutAndIn fadeOutAndIn;

    private AudioSource audioSource;
    public AudioClip startSound;

    bool isInGame = false;
    bool isInResult = false;
    bool isInTitle = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Obsolete("Obsolete")]
    private void Start()
    {
        GameObject obj = GameObject.Find("FadeOutAndIn");
        fadeOutAndIn = obj.GetComponent<FadeOutAndIn>();

        Debug.Log("処理の開始");
        GetComponent<Button>().onClick.AddListener
        (
            DoTransition
        );

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //タイトルシーン
        if(isInTitle)
        {
            //画面が暗くなったらシーン遷移する
            if (fadeOutAndIn.Alpha >= 1.0f)
            {
                if (Object.FindObjectOfType<ScoreManager>() != null)
                {
                    Destroy(Object.FindObjectOfType<ScoreManager>());
                }

                isInTitle = false;
                SceneManager.LoadScene(sceneName);
            }

            fadeOutAndIn.UpdateAlphaAdd();
        }

        //ゲームシーンに移行
        if(isInGame)
        {
            //画面が暗くなったらシーン遷移する
            if (fadeOutAndIn.Alpha >= 1.0f)
            {
                if (Object.FindObjectOfType<ScoreManager>() == null)
                {
                    Instantiate(scoreManagerPrefab, Vector3.zero, Quaternion.identity);
                }

                isInGame = false;
                SceneManager.LoadScene(sceneName);
            }

            fadeOutAndIn.UpdateAlphaAdd();
        }

        //リザルトシーンに移行
        if (isInResult)
        {
            if (fadeOutAndIn.Alpha >= 1.0f)
            {
                if (Object.FindObjectOfType<ScoreManager>() == null)
                {
                    Instantiate(scoreManagerPrefab, Vector3.zero, Quaternion.identity);
                }

                isInResult = false;
                SceneManager.LoadScene(sceneName);
            }

            fadeOutAndIn.UpdateAlphaAdd();
        }


        if (Input.GetKey(KeyCode.Space))
        {
            DoTransition();
        }
    }

    [Obsolete("Obsolete")]
    private void DoTransition()
    {
        if (sceneName == "Game" &&
            !isInGame)
        {
            fadeOutAndIn.IsFadeOut = true;
            isInGame = true;

            audioSource.PlayOneShot(startSound);
        }
        if (sceneName == "Title")
        {
            fadeOutAndIn.IsFadeOut = true;
            isInTitle = true;
        }
        if (sceneName == "Result")
        {
            fadeOutAndIn.IsFadeOut = true;
            isInResult = true;
        }

        gameObjectFadeOutAndIn.SetActive(true);
    }
    // Update is called once per frame

}