using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    public GameObject bullet;
    public int bulletPostX;
    public int bulletPosY;
    public float speed;
    public Camera cam;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(bullet, new Vector3(transform.position.x + bulletPostX, transform.position.y + bulletPosY, 0),Quaternion.identity);
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.position += new Vector3(horizontal * speed * Time.deltaTime, vertical * speed * Time.deltaTime, 0);
    }
}
