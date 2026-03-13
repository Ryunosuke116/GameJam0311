using TMPro;
using UnityEngine;

public class ScoreOutput : MonoBehaviour
{
    [SerializeField] 
    private TMP_Text scoreText;

    private ScoreManager scoreManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject gameObject = GameObject.Find("scoreManager");
        scoreManager = gameObject.GetComponent<ScoreManager>();

        scoreText.text = $"{scoreManager.Score}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
