using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instancer : MonoBehaviour {

    public GameObject toInstance;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BoundWall")
        {
            toInstance.transform.parent = this.transform.parent;
            toInstance.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
