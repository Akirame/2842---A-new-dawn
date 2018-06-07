using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Camera cam;

    private void Update()
    {
        OffCamera();
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);
                
    }
    private void OffCamera()
    {
        Vector3 PosInCamera = cam.WorldToViewportPoint(transform.position);
        if (PosInCamera.y > 1 || PosInCamera.x < 0 || PosInCamera.x > 1)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
