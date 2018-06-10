using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum goTo
{
    LEFT_TORIGHT,
    RIGHT_TOLEFT
}

public class EnemyFollow : MonoBehaviour
{    
    // put the points from unity interface    
    private Transform[] wayFollow = new Transform[3];
    private GameObject waypoint1;
    private GameObject waypoint2;
    private GameObject waypoint3;
    private GameObject waypoint4;
    private GameObject waypoint5;
    private GameObject waypoint6;
    public GameObject PowerUp;
    public GameObject explosionPrefab;
    public GameObject bullet;
    public goTo direction;
    public int currentWayPoint = 0;
    public float speed = 4f;
    public float waitTime = 3f;

    private Transform targetWayPoint;
    private float timer;    


    private void Awake()
    {
        waypoint1 = GameObject.Find("Waypoint1");
        waypoint2 = GameObject.Find("Waypoint2");
        waypoint3 = GameObject.Find("Waypoint3");
        waypoint4 = GameObject.Find("Waypoint4");
        waypoint5 = GameObject.Find("Waypoint5");
        waypoint6 = GameObject.Find("Waypoint6");
    }

    // Use this for initialization
    private void Start()
    {
        switch (direction)
        {
            case goTo.LEFT_TORIGHT:
                wayFollow[0] = waypoint1.transform;
                wayFollow[1] = waypoint2.transform;
                wayFollow[2] = waypoint3.transform;
                break;                  
            case goTo.RIGHT_TOLEFT:     
                wayFollow[0] = waypoint4.transform;
                wayFollow[1] = waypoint5.transform;
                wayFollow[2] = waypoint6.transform;
                break;
        }
        timer = 0;
    }
    // Update is called once per frame
    private void Update()
    {
        if (timer >= waitTime)
        {
            if (Random.Range(0f, 100f) > 50f)
            {
                Instantiate(bullet, this.transform.position, Quaternion.identity);
            }
            timer = 0;
        }
        else
            timer += Time.deltaTime;

        // check if we have somewere to walk
        if (currentWayPoint < this.wayFollow.Length)
        {
            if (targetWayPoint == null)
                targetWayPoint = wayFollow[currentWayPoint];
            Walk();
        }
    }
    private void Walk()
    {
        // move towards the target
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        targetWayPoint.position = new Vector3(targetWayPoint.position.x, targetWayPoint.position.y, 0);
        transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, speed * Time.deltaTime);

        if (transform.position == targetWayPoint.position && currentWayPoint != this.wayFollow.Length - 1)
        {
            currentWayPoint++;
            targetWayPoint = wayFollow[currentWayPoint];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Bomb" || collision.gameObject.tag == "Explosion")
        {
            if (Random.Range(0f, 100f) > 95f)
            {
                Instantiate(PowerUp, this.transform.position, Quaternion.identity);
            }
            if (Random.Range(0f, 100f) > 70f)
            {
                Instantiate(explosionPrefab, this.transform.position, Quaternion.identity);
            }         
        }
        if (collision.gameObject.tag == "BoundWallBottom")
            Destroy(this.gameObject);
    }
}
