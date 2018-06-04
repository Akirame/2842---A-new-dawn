using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed; 

    private void Update()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);
    }
}
