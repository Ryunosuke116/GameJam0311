using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Object = UnityEngine.Object;
[DefaultExecutionOrder(-10)]
[RequireComponent(typeof(Button))]
public class SceneTransitionButton : MonoBehaviour
{
    [SerializeField] private string sceneName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Obsolete("Obsolete")]
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener
        (
            DoTransition
        );
    }

    [Obsolete("Obsolete")]
    private void DoTransition()
    {
        if (sceneName == "Title")
        {
            Object.FindObjectOfType<ScoreManager>().GetComponent<ScoreManager>().ReSet();
        }
      
        
        SceneManager.LoadScene(sceneName);
        
    }
    // Update is called once per frame
    
}