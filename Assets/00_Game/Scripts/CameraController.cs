using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private static CameraController instance;
    public static CameraController Get()
    {
        return instance;
    }

    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }
    private void Awake()
    {
        if (!instance)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    public float speed = 1;

    void Update()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);
    }
    public float GetSpeed()
    {
        return speed;
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
