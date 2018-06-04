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
        Vector3 bulletStartPos = new Vector3(transform.position.x + bulletPostX, transform.position.y + bulletPosY, 0);

        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(bullet, bulletStartPos ,Quaternion.identity);
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.position += new Vector3(horizontal * speed * Time.deltaTime, vertical * speed * Time.deltaTime, 0);                    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BoundWall")
            Debug.Log("HOLA");
    }
}
