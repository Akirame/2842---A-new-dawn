using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Directions {
    UP,
    DOWN,
    LEFT,
    RIGHT
}

enum state {
    MOVING,
    SHOOT,
    AFTERSHOOT
}

public class EnemyController : MonoBehaviour
{
    public Directions ComingFromDirection;
    public float speed;
    public float waitTime;
    private state currentState;
    private float timer;

    private void Start()
    {
        currentState = state.MOVING;
        timer = 0;
    }

    private void Update()
    {
        switch (currentState)
        {
            case state.MOVING:
                if (timer < waitTime)
                {
                    Movement();
                    timer += Time.deltaTime;
                }
                else
                {
                    timer = 0;
                    currentState = state.SHOOT;
                }
                break;
            case state.SHOOT:
                {
                    Debug.Log("HOLA");
                    currentState = state.AFTERSHOOT;
                }
                break;
            case state.AFTERSHOOT:
                {
                    Movement();
                }
                break;            
        }
    }

    private void Movement()
    {
        switch (ComingFromDirection)
        {
            case Directions.UP:
                if (currentState == state.MOVING)
                {
                    transform.position += new Vector3(0, -speed) * Time.deltaTime;
                }
                else if (currentState == state.AFTERSHOOT)
                {
                    transform.position += new Vector3(speed, 0) * Time.deltaTime;
                }
                break;
            case Directions.DOWN:
                break;
            case Directions.LEFT:
                break;
            case Directions.RIGHT:
                break;
        }
    }
}

