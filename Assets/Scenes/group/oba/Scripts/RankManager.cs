using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using UnityEngine;

public class RankManager : MonoBehaviour
{
    private TextAsset _rankingFile;
    private List<string[]> _rankingList = new List<string[]>();
    void Start()
    {
        // 1. ResourcesからCSVを読み込み (拡張子.csvは不要)
        // ※Resourcesにランキングデータを入れていないと動かない
        var csvFile = Resources.Load<TextAsset>($"RankingData");
        if (csvFile == null) return;

        // 2. StringReaderでテキストを読み込む
        var reader = new StringReader(csvFile.text);

        // 3. 一行ずつ読み込んでリストに格納
        List<string[]> csvData = new List<string[]>();
        if (csvData == null) throw new ArgumentNullException(nameof(csvData));
        while (reader.Peek() != -1)
        {
            var line = reader.ReadLine();
            if (line != null) csvData.Add(line.Split(',')); // カンマで分割
        }

        if (csvData.Count > 0)
        {
            _rankingList = csvData;
        }
        Debug.Log("CSV読み込み完了");
        SaveRanking();
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="newScore"></param>
    private void SaveRanking(int newScore = 0)
    {
        var i = 0;
        while (_rankingList[i][1].Length != 0)
        {
            i++;
        }
        _rankingList[i][0] = i.ToString();          // 順位の書き込み
        _rankingList[i][1] =  newScore.ToString();  // スコアの書き込み
                
        WriteRankingData();
    }

    void RankingDataSort()
    {
        var swap = _rankingList[0][0].ToIntArray();
        
    }
    
    private void WriteRankingData()
    {
        var filePath = "C:\\Users\\student\\Desktop\\2406010007\\GameJam0311\\Assets\\Resources\\RankingData.csv";
        // StreamWriterでファイルを作成
        using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
        {
            for (var i = 0; i < _rankingList.Count; i++)
            {
                string[] row = new string[_rankingList[0].Length];
                for (var j = 0; j < _rankingList[0].Length; j++)
                {
                    // Debug.Log("row:"+_rankingList[i][j]);
                    row[j] = _rankingList[i][j];
                }
                sw.WriteLine(string.Join(",", row));
            }
        }
    }
   
}
