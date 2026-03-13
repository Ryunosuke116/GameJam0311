using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class DrawDisplay : MonoBehaviour
{
    // インスペクターから表示したいTMPオブジェクトをアサイン
    [SerializeField] private TextMeshProUGUI scoreText;
    
    private int _scorePass;
    private int _RankPass;
    private List<string[]> _rankingList;
    [SerializeField] private int displayedRanking;
    [SerializeField] private bool DrowRank; // trueならランクをfalseならスコアを表示

    private void Awake()
    {
        if (GameObject.Find("rankingManager") == null)
        {
            Debug.Log("RankingManager is missing");
            return;
            
        }
        _RankPass = GameObject.Find("rankingManager").GetComponent<RankManager>().RankPass;
        _scorePass = GameObject.Find("rankingManager").GetComponent<RankManager>().ScorePass; 
        _rankingList = GameObject.Find("rankingManager").GetComponent<RankManager>().RankingList;
        if (_rankingList.Count <= 0)
        {
            Debug.LogWarning("RankingList is null");
            return;
        }
        Debug.Log("ランキングリストを読み込みました");
     
    }
    
    void Update()
    {
        //_rankingList = GameObject.Find("rankingManager").GetComponent<RankManager>().RankingList;
        if (_rankingList.Count <= 0)
        {
            Debug.LogWarning("RankingList is null");
            return;
        }

        if (displayedRanking == -1)
        {
            displayedRanking = GameObject.Find("rankingManager").GetComponent<RankManager>().newRank;
        }
        Debug.Log("DrawRank:"+displayedRanking);
        Debug.Log("size:"+_rankingList.Count);
        //Debug.Log("Score: "+_rankingList[displayedRanking][_scorePass]);
        
        if (displayedRanking < 0 || displayedRanking >= _rankingList.Count) return;
        
        if (string.IsNullOrEmpty(scoreText.text))
        {
            if (DrowRank)
            {
                scoreText.text = _rankingList[displayedRanking][_RankPass] + "位";
            }
            else
            {
                scoreText.text = "Score: " + _rankingList[displayedRanking][_scorePass];
            }
        }
     
    }

}
