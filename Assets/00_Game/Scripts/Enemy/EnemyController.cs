using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type {
    LINEAR,
    SHOOTER
}
enum state
{
    MOVING,
    SHOOT,
    AFTERSHOOT
}

public class EnemyController : MonoBehaviour
{

    public float speed;
    public float waitTime;
    public Vector3 initialPos;
    public Vector3 endPos;
    public AnimationCurve movementCurve;
    public GameObject PowerUp;
    public GameObject explosionPrefab;
    public GameObject bullet;
    public Type _type;

    private state currentState;
    private float timer;
    private bool isRunning = false;
    private float maxScreen = 0.9f;
    private float minScreen = 0.1f;

    private void Start()
    {
        currentState = state.MOVING;
        Vector3 RandomInitialPos = new Vector3((Random.Range(minScreen, maxScreen)), maxScreen);
        initialPos = CameraController.Get().GetViewPort().ViewportToWorldPoint(RandomInitialPos);
        initialPos -= new Vector3(CameraController.Get().GetPosition().x, CameraController.Get().GetPosition().y);
    }

    private void LateUpdate()
    {
        // lock z
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        //look at player
        if (_type == Type.SHOOTER)
        {
            Vector3 dir = ShipController.Get().transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        }
    }

    private void Update()
    {
        switch (_type)
        {
            case Type.LINEAR:
                if (timer < waitTime)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
                    timer += Time.deltaTime;
                }
                else
                    Destroy(this.gameObject);
                    break;
            case Type.SHOOTER:
                switch (currentState)
                {
                    case state.MOVING:
                        if (!isRunning)
                            StartCoroutine(Move(transform.position, initialPos, movementCurve, waitTime));
                        break;
                    case state.SHOOT:
                        {
                            if (timer > waitTime)
                            {
                                Instantiate(bullet, this.transform.position, Quaternion.identity);
                                currentState = state.AFTERSHOOT;
                                Vector3 RandomEndPos = new Vector3((Random.Range(minScreen, maxScreen)), maxScreen - 5);
                                endPos = RandomEndPos;
                                timer = 0.0f;
                            }
                            else
                            {
                                transform.position = (initialPos + new Vector3(CameraController.Get().GetPosition().x, CameraController.Get().GetPosition().y));
                                timer += Time.deltaTime;

                            }
                        }
                        break;
                    case state.AFTERSHOOT:
                        {
                            if (!isRunning)
                                StartCoroutine(Move(transform.position, endPos, movementCurve, waitTime));
                        }
                        break;
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
        while (timer <= time)
        {
            Vector3 camPos = new Vector3(CameraController.Get().GetPosition().x, CameraController.Get().GetPosition().y);
            if (currentState == state.MOVING)
                transform.position = Vector3.Lerp(pos1 + camPos, pos2 + camPos, ac.Evaluate(timer / time));
            else if (currentState == state.AFTERSHOOT)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Bomb")
        {
            if (Random.Range(0f, 100f) > 90f)
            {
                Instantiate(PowerUp, this.transform.position, Quaternion.identity);
            }
            if (Random.Range(0f, 100f) > 70f)
            {
                Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
            }
        }
    }
}