using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Directions
{
    UP,
    DOWN,
    LEFT,
    RIGHT
}

enum state
{
    MOVING,
    SHOOT,
    AFTERSHOOT
}

public class EnemyController : MonoBehaviour
{
    public Directions ComingFromDirection;
    public float speed;
    public float waitTime;
    public GameObject cam;
    private state currentState;
    private float timer;
    public Vector3 pos1;
    public Vector3 pos2;
    public AnimationCurve ac;
    bool isRunning = false;

    private void Start()
    {
        Vector3 RandomInitialPos = new Vector3(Random.Range(cam.transform.position.x, cam.transform.position.x + 10), cam.transform.position.y - 1);
        currentState = state.MOVING;
        pos1 = RandomInitialPos;
    }

    private void Update()
    {
        switch (currentState)
        {
            case state.MOVING:
                if (!isRunning)
                    StartCoroutine(Move(transform.position, pos1, ac, waitTime));
                break;
            case state.SHOOT:
                {
                    if (timer > waitTime)
                    {
                        currentState = state.AFTERSHOOT;
                        Vector3 RandomEndPos = new Vector3(Random.Range(cam.transform.position.x + 1, cam.transform.position.x + 10), cam.transform.position.y - 20);
                        pos2 = RandomEndPos;
                        timer = 0.0f;
                    }
                    else
                        timer += Time.deltaTime;
                }
                break;
            case state.AFTERSHOOT:
                {
                    if(!isRunning)
                    StartCoroutine(Move(transform.position, pos2, ac, waitTime));                    
                }
                break;
        }
    }

    /// <summary>
    /// Mover el sprite de forma suave
    /// </summary>
    /// <param name="pos1"> Posicion Inicial</param>
    /// <param name="pos2"> Posicion Final</param>
    /// <param name="ac"> Curva de tiempo</param>
    /// <param name="time"> Tiempo Total</param>
    /// <returns></returns>
    IEnumerator Move(Vector3 pos1, Vector3 pos2, AnimationCurve ac, float time)
    {
        isRunning = true;        
        pos1 += new Vector3(cam.transform.position.x, cam.transform.position.y);
        pos2 += new Vector3(cam.transform.position.x, cam.transform.position.y);
        
        while (timer <= time)
        {
            transform.position = Vector3.Lerp(pos1, pos2, ac.Evaluate(timer / time));
            timer += Time.deltaTime;
            yield return null;
        }
        yield return null;
        switch (currentState)
        {
            case state.MOVING:
                currentState = state.SHOOT;
                break;
            case state.AFTERSHOOT:
                Destroy(this.gameObject);
                break;
        }
        isRunning = false;
        timer = 0.0f;        
    }
}

