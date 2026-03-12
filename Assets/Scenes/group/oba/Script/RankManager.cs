using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class RankManager : MonoBehaviour
{
    private TextAsset _rankingFile;
    private List<string[]> _rankingList = new List<string[]>();
    void Start()
    {
        string[] lines = _rankingFile.text.Split('\n');
        foreach (string line in lines)
        {
            if(string.IsNullOrEmpty(line)) continue;
            string[] fields = line.Split(',');
            _rankingList.Add(fields);
        }
        Debug.Log("CSV読み込み完了:"+_rankingList[0][0]);
    }

    private void SaveRanking()
    {
        var filePath = Application.persistentDataPath + "/RankingData.csv";
        // StreamWriterでファイルを作成
        using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
        {
            sw.WriteLine("ID,Name");
        }
    }
    
}
