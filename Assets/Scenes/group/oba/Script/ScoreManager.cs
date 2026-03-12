using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    private int Score { get; set; } = 0;

    private void Start()
    {
        Debug.Log("Score:"+Score);
    }

    private void Awake()
    {
        // このオブジェクトはシーン切り替えでも破棄しない
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// スコアの加算
    /// </summary>
    /// <param name="score"> 加算される値 </param>
    private void AddScore(int score)
    {
        Score += score;
    }
    
    
    public void ResetScore()
    {
        Score = 0;
        Destroy(gameObject);
    }
    
    private void Update()
    {
        AddScore(1);
        Debug.Log("Score:"+Score);
    }
    
}
