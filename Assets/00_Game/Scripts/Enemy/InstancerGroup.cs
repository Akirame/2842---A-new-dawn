using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancerGroup : MonoBehaviour
{
    public GameObject toInstance;
    public Transform startPoint;
    public int cantEnemy;

    private List<GameObject> enemyGroup;

    private void Start()
    {
        enemyGroup = new List<GameObject>();
        for (int i = 0; i < cantEnemy; i++)
        {
            enemyGroup.Add(toInstance);
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BoundWall")
        {
            StartCoroutine(instance());
        }
    }
    IEnumerator instance()
    {
        for (int i = 0; i < enemyGroup.Count; i++)
        {
            Instantiate(enemyGroup[i], startPoint.transform.position, Quaternion.identity, this.transform.parent);
            yield return new WaitForSeconds(0.5f);
        }
        Destroy(this.gameObject);
    }
}
