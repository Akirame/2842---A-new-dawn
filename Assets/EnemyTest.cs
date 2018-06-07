using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    public AnimationCurve ac;
    public Vector3 pos1 = new Vector3(-4.0f, 0.0f, 0.0f);
    public Vector3 pos2 = new Vector3(4.0f, 0.0f, 0.0f);
    public Camera cam;

    void Start()
    {               
            StartCoroutine(Move(pos1, pos2, ac, 3.0f));        
    }

    IEnumerator Move(Vector3 pos1, Vector3 pos2, AnimationCurve ac, float time)
    {
        float timer = 0.0f;
        pos1 += new Vector3(cam.transform.position.x, cam.transform.position.y);
        pos2 += new Vector3(cam.transform.position.x, cam.transform.position.y);
        while (timer <= time)
        {
     
            transform.position = Vector3.Lerp(pos1, pos2, ac.Evaluate(timer / time));
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
