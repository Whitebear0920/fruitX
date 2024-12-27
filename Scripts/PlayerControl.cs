using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Score Score;
    public float playerMoveSpeed;
    private Rigidbody2D r2d;
    private Vector2 movement;

    void Start()
    {
        Score = Score.instance;
        r2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.S)){
            Debug.Log(Score.score);
        }
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        r2d.linearVelocity = movement * playerMoveSpeed;
    }
}