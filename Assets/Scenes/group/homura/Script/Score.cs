using UnityEngine;
using TMPro;
public class Score:MonoBehaviour
{
    private ScoreManager ScoreManager;
    private Collision Collision;

    private int scoreMaxCount = 0;

    [SerializeField]private TMP_Text scoreText;
    void Start()
    {
        GameObject Object = GameObject.Find("scoreManager");
        ScoreManager = Object.GetComponent<ScoreManager>();
        GameObject collisionObject =GameObject.Find("Collision");
        Collision=collisionObject.GetComponent<Collision>();
    }
    void Update()
    {
        int scoreCount = 0;
        for (int i=0;i< Collision.GetTargetItemsLength(); i++)
        {
            if (Collision.GetTargetItems(i) == false) break;
            scoreCount++;
        }

        while (true)
        {
            if (scoreMaxCount < scoreCount)
            {
                ScoreManager.AddScore(15);
                scoreMaxCount++;
            }
            if (scoreMaxCount >= scoreCount) break;
        }
        
        
        scoreText.text = $"{ScoreManager.Score}";
    }
}
