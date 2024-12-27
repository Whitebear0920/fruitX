using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time;
    public Text timeText;
    private float startTime;
    void Start(){
        time = 60;
        startTime = Time.time;
    }
    void Update(){
        timeText.text =(time-Mathf.Floor(Time.time - startTime)).ToString();
    }
}