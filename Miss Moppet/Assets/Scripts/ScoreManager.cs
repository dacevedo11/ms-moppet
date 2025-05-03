using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public Transform player;
    public TMP_Text scoreText;
    

    private float startX;
    private float score;

    void Start()
    {
        startX = player.position.x;
    }

    void Update()
    {
        if (player == null) return;
        
        score = player.position.x - startX;

        if (scoreText != null)
        {
            scoreText.text = "Distance: " + Mathf.FloorToInt(score).ToString() + " m";
        }
    }
    
    public float GetScore()
    {
        return score;
    }

}
