using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;

    void Start()
    {                
        Vector3 dir = ShipController.Get().transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        // Move the projectile forward towards the player's last known direction;
        transform.position += transform.up * speed * Time.deltaTime;
        OffCamera();

    }
    private void OffCamera()
    {
        Vector3 PosInCamera = CameraController.Get().GetViewPort().WorldToViewportPoint(transform.position);
        if (PosInCamera.y < 0 || PosInCamera.y > 1 || PosInCamera.x < 0 || PosInCamera.x > 1)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {            
            Destroy(this.gameObject);
        }
    }
}
