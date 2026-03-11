using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SceneTransitionButton : MonoBehaviour
{
    [SerializeField] private string sceneName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Debug.Log("処理の開始");
        GetComponent<Button>().onClick.AddListener
        (
            DoTransition
        );
    }

    private void DoTransition()
    {
        SceneManager.LoadScene(sceneName);
        
    }
    // Update is called once per frame
    
}