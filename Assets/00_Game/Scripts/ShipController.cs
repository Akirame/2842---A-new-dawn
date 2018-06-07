using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviourSingleton<ShipController>
{
    public GameObject bullet;
    public int bulletPosX;
    public int bulletPosY;    
    public float bulletSpacing;
    public float speed;

    private GameObject bulletGroup;    

    private void Start()
    {        
        bulletGroup = new GameObject("Bullets");                
    }
    private void Update()
    {
        transform.position += new Vector3(0, CameraController.Get().GetSpeed(), 0);

        Shoot();

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.position += new Vector3(horizontal * speed * Time.deltaTime, vertical * speed * Time.deltaTime, 0);
    }
    
    private void Shoot()
    {
        Vector3 bulletStartPos = new Vector3(transform.position.x + bulletPosX, transform.position.y + bulletPosY, 0);

        if (Input.GetKeyDown(KeyCode.Space))
            for (int i = 0; i < GameManager.Get().GetRange(); i++)
            {
                Instantiate(bullet, bulletStartPos, Quaternion.identity, bulletGroup.transform);
                if (GameManager.Get().GetRange() > 1)
                {
                    Vector3 bulletRangePos = new Vector3(i * bulletSpacing, 0);
                    Instantiate(bullet, (bulletStartPos + bulletRangePos), Quaternion.identity, bulletGroup.transform);
                    Instantiate(bullet, (bulletStartPos - bulletRangePos), Quaternion.identity, bulletGroup.transform);
                }
            }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameManager.Get().ReduceEnergy();  
        }
    }
}
