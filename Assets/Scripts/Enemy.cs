using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float yMin = -4f;
    [SerializeField] float yMax = 4f;
    [SerializeField] float moveSpeed = 6f;

    // state
    Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float ballYPos = ball.transform.position.y;
        float newYPos = Mathf.Clamp(ballYPos, yMin, yMax);
        transform.position = new Vector2(transform.position.x, newYPos);
    }
}
