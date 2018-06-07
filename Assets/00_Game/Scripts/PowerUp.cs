using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Powers{
    HEAL,
    RANGE
}
public class PowerUp : MonoBehaviour {

    private Powers pow;    
    public GameObject HealSprite;
    public GameObject RangeSprite;
    float timer;
	void Start ()
    {               
        pow = (Powers)Random.Range(0,2);
        switch (pow)
        {
            case Powers.HEAL:
                HealSprite.SetActive(true);                                
                break;
            case Powers.RANGE:
                RangeSprite.SetActive(true);                
                break;
        }
        timer = 0;
    }
    private void Update()
    {
        if (timer > 10)
            Destroy(this.gameObject);
        else
            timer += Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (pow)
            {
                case Powers.HEAL:
                    GameManager.Get().AddEnergy();
                    break;
                case Powers.RANGE:
                    GameManager.Get().AddRange();
                    break;
            }
            Destroy(this.gameObject);
        }        
    }
}
