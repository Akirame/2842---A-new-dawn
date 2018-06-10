using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviourSingleton<CameraController> {

    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    public float speed = 1;

    void Update()
    {
        if (GameManager.Get().Playing())
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            cam.ViewportToScreenPoint(transform.position);
        }

    }
    public float GetSpeed()
    {
        return speed * Time.deltaTime;
    }
    public Vector3 GetPosition()
    {
        return transform.position;
    }
    public Camera GetViewPort()
    {
        return cam;
    }
}
