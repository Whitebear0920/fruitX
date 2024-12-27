using UnityEngine;

public class FallItem : MonoBehaviour
{
    public int fallItemHealth;
    public int itemScore;
    public int index;
    public Score Score;
    private Rigidbody2D r2d;
    void Start()
    {
        Score = Score.instance;
        fallItemHealth = 3;
        r2d = GetComponent<Rigidbody2D>();
        r2d.gravityScale = 0.1f;//Random.Range(1,0.5f);
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.name == "DelArea"){
            FallItemManager.fallItemPool[index].Recycle(this);
        }
        else if(other.name == "Player"){
            FallItemManager.fallItemPool[index].Recycle(this);
            Score.AddScore(itemScore);
        }
    }

}