using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.linearVelocity = new Vector2(GameControl.Instance.scrollSpeed, 0);
    }

    void Update()
    {
        if (GameControl.Instance.gameOver == true)
            rb2d.linearVelocity = Vector2.zero;
    }
}
