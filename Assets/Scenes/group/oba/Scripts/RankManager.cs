using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using UnityEngine;
[DefaultExecutionOrder(-5)]
public class RankManager : MonoBehaviour
{
    private TextAsset _rankingFile;
    private List<string[]> _rankingList = new List<string[]>();
    public List<string[]> RankingList => _rankingList;

    private const int scorePass = 1;
    private const int rankPass = 0;
    public int newRank { get; private set; } = 10; 
    public int ScorePass => scorePass;
    public int RankPass => rankPass;
    
    void Awake()
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

        RankingDataSort();
        newRank = SearchList(30.ToString());
        Debug.Log("CSV読み込み完了");
    }
    
    /// <summary>
    /// 新しいスコアを追加
    /// </summary>
    /// <param name="newScore"></param>
    private void SaveRanking(int newScore = 0)
    {
        var size = _rankingList.Count;
        _rankingList[ size - 1][scorePass] = newScore.ToString();  // スコアの書き込み
        RankingDataSort();
        WriteRankingData();
        newRank = SearchList(newScore.ToString());
    }
    
    /// <summary>
    /// スコアを降順にする
    /// </summary>
    void RankingDataSort()
    {
        int[] swap = new int[_rankingList.Count];
        var size = 0;
        for (var i = 0; i < _rankingList.Count - 2; i++)
        {
            if(_rankingList[i+1][scorePass] == "") _rankingList[i+1][scorePass] = "0";
            size++;
            // Debug.Log(":"+int.Parse(_rankingList[i+1][1]));
            swap[i] = int.Parse(_rankingList[i+1][scorePass]);
        }
        Debug.Log("Sort");
        Array.Sort(swap);
        Array.Reverse(swap);
        for (var i = 0; i < size; i++)
        {
            _rankingList[i+1][scorePass] = swap[i].ToString();
        }
        
    }
    
    /// <summary>
    /// CSVに書き込み
    /// </summary>
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

    public int SearchList(string target)
    {
        var rowIndex = -1;

        // --- 検索処理 ---
        for (int row = 0; row < _rankingList.Count; row++)
        {
            // IndexOfを使って列のインデックスを取得
            if (target == null) continue;
            var col = _rankingList[row][1].IndexOf(target, StringComparison.Ordinal);

            if (col == -1) continue;
            rowIndex = row;
            break; // 見つかったらループを抜ける
        }
        return rowIndex;
    }
}
