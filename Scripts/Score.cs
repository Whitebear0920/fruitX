using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    public int score;
    public Text scoreText;
    void Awake()
    {
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }
    void Start()
    {
        score = 0;
    }
    public void AddScore(int point){
        score += point;
        if(score<0){
            score =0;
        }
        UpdateScoreDisplay();
    }
    public void UpdateScoreDisplay(){
        scoreText.text = score.ToString();
    }
}