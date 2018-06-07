using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    
    public GameObject bullet;
    public int bulletPosX;
    public int bulletPosY;
    public int bulletRange;
    public float bulletSpacing;
    public float speed;

    private GameObject bulletGroup;

    private void Start()
    {
        bulletRange = 1;
        bulletGroup = new GameObject();
        bulletGroup.name = "Bullets";
    }
    private void Update()
    {
        transform.position += new Vector3(0, CameraController.Get().GetSpeed(), 0);
        Vector3 bulletStartPos = new Vector3(transform.position.x + bulletPosX, transform.position.y + bulletPosY, 0);        
        if (Input.GetKeyDown(KeyCode.Space))
            for (int i = 0; i < bulletRange; i++)
            {
                Instantiate(bullet, bulletStartPos, Quaternion.identity, bulletGroup.transform);
                if (bulletRange > 1)
                {
                    Vector3 bulletRangePos = new Vector3(i * bulletSpacing, 0);
                    Instantiate(bullet, (bulletStartPos + bulletRangePos), Quaternion.identity, bulletGroup.transform);
                    Instantiate(bullet, (bulletStartPos - bulletRangePos), Quaternion.identity, bulletGroup.transform);
                }
            }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.position += new Vector3(horizontal * speed * Time.deltaTime, vertical * speed * Time.deltaTime, 0);
    }
}
