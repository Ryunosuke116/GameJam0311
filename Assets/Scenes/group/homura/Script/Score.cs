using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    private ScoreManager ScoreManager;
    private Collision Collision;

    private int scoreMaxCount = 0;

    public AudioSource audioSource;
    public AudioClip seClip;

    [SerializeField] private TMP_Text scoreText;
    void Start()
    {
        GameObject Object = GameObject.Find("scoreManager");
        ScoreManager = Object.GetComponent<ScoreManager>();

        GameObject collisionObject = GameObject.Find("Collision");
        Collision = collisionObject.GetComponent<Collision>();
    }
    void Update()
    {
        int scoreCount = 0;
        for (int i = 0; i < Collision.GetTargetItemsLength(); i++)
        {
            if (Collision.GetTargetItems(i) == false) continue;
            scoreCount++;

        }

        while (true)
        {
            if (scoreMaxCount < scoreCount)
            {
                ScoreManager.AddScore(15);
                audioSource.PlayOneShot(seClip, 1.0f);
                scoreMaxCount++;
            }
            if (scoreMaxCount >= scoreCount) break;
        }


        scoreText.text = $"{ScoreManager.Score}";
    }


    void Awake()
    {
        if (!audioSource)
        {
            // 同じオブジェクトにAudioSourceがあれば拾う
            audioSource = GetComponent<AudioSource>();
        }

        if (audioSource)
        {
            audioSource.playOnAwake = false;
            audioSource.spatialBlend = 0f; // 2D再生（効果音向け）
            audioSource.volume = 1f;
        }
    }


}
