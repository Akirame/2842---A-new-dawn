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
    public Transform[] wayPointList;
    private Transform[] wayFollow = new Transform[3];
    public goTo direction;

    public int currentWayPoint = 0;
    Transform targetWayPoint;

    public float speed = 4f;

    // Use this for initialization
    private void Start()
    {
        switch (direction)
        {
            case goTo.LEFT_TORIGHT:
                wayFollow[0] = wayPointList[0];
                wayFollow[1] = wayPointList[1];
                wayFollow[2] = wayPointList[2];
                break;
            case goTo.RIGHT_TOLEFT:
                wayFollow[0] = wayPointList[3];
                wayFollow[1] = wayPointList[4];
                wayFollow[2] = wayPointList[5];
                break;
        }
    }
    // Update is called once per frame
    private void Update()
    {
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
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Get().ReduceEnergy();
        }
        if (collision.gameObject.tag == "BoundWallBottom")
            Destroy(this.gameObject);
    }
}
