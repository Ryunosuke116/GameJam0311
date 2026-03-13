using UnityEngine;
using TMPro; // TextMeshProを使用するため
using UnityEngine.UI;
using System.IO;

public class TextLoader : MonoBehaviour
{
    // TextMeshPro - Text (UI) コンポーネントをインスペクターで指定
    [SerializeField] private TextMeshProUGUI textComponent;
    
    // 読み込むテキストファイル名 (Assets/Resourcesに配置)
    [SerializeField] private string fileName = "text"; 

    void Start()
    {
        LoadTextFile();
    }

    void LoadTextFile()
    {
        // Assets/Resourcesフォルダからテキストを読み込む方法
        TextAsset textFile = Resources.Load<TextAsset>(fileName);
        
        if (textFile != null)
        {
            textComponent.text = textFile.text; // テキストを設定
        }
        else
        {
            Debug.LogError("ファイルが見つかりません: " + fileName);
        }
    }
}