using System;
using System.Collections;
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
        var size = _rankingList.Count;
        _rankingList[ size - 1][1] = newScore.ToString();  // スコアの書き込み
        RankingDataSort();
        WriteRankingData();
    }

    void RankingDataSort()
    {
        int[] swap = new int[_rankingList.Count];
        var size = 0;
        for (var i = 0; i < _rankingList.Count - 2; i++)
        {
            if(_rankingList[i+1][1] == "") _rankingList[i+1][1] = "0";
            size++;
            // Debug.Log(":"+int.Parse(_rankingList[i+1][1]));
            swap[i] = int.Parse(_rankingList[i+1][1]);
        }
        Debug.Log("size:"+size);
        for (var i = 0; i < size; i++)
        {
            Debug.Log(":"+swap[i]);
        }
        Debug.Log("Sort");
        System.Array.Sort(swap);
        for (var i = 0; i < size; i++)
        {
            Debug.Log(":"+swap[i]);
        }
        for (var i = 0; i < size; i++)
        {
            //_rankingList[i+1][1] = swap[i].ToString();
        }
        
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
