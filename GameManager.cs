using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public Paddle paddle;

    public static Vector2 bottomLeft;
    public static Vector2 topRight;

    // Start is called before the first frame update
    void Start()
    {
        // convert screen's pixel cooridante into game's coordinate
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        // create ball
        Instantiate(ball);

        // create 2 paddle
        Paddle paddle1 = Instantiate(paddle);
        Paddle paddle2 = Instantiate(paddle);
        paddle1.Init (true); // right peddle
        paddle2.Init (false); // left peddle
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
