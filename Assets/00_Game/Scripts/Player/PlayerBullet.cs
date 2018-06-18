using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, Random.Range(-10, 10)));
    }
    private void Update()
    {
        OffCamera();
        transform.position += transform.up * speed * Time.deltaTime;
        
    }
    private void OffCamera()
    {
        Vector3 PosInCamera = CameraController.Get().GetViewPort().WorldToViewportPoint(transform.position);
        if (PosInCamera.y > 1 || PosInCamera.x < 0 || PosInCamera.x > 1)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            GameManager.Get().AddScore(100);
            Destroy(this.gameObject);            
        }
    }
}
