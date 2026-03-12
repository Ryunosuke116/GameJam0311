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

    public GameObject scoreManagerPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Obsolete("Obsolete")]
    private void Start()
    {
        Debug.Log("処理の開始");
        GetComponent<Button>().onClick.AddListener
        (
            DoTransition
        );
    }

    [Obsolete("Obsolete")]
    private void DoTransition()
    {
        if (sceneName == "Game")
        {
            if (Object.FindObjectOfType<ScoreManager>() == null) Instantiate(scoreManagerPrefab, Vector3.zero, Quaternion.identity);
        }
        if (sceneName == "Title")
        {
            if (Object.FindObjectOfType<ScoreManager>() != null) Destroy(Object.FindObjectOfType<ScoreManager>()); 
        }
      
        
        SceneManager.LoadScene(sceneName);
        
    }
    // Update is called once per frame
    
}