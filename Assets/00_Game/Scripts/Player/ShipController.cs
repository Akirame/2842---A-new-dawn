using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviourSingleton<ShipController>
{
    public GameObject bullet;
    public GameObject bomb;
    public int bulletPosX;
    public int bulletPosY;    
    public float bulletSpacing;
    public float speed;
    public float timerBomb = 3;    


    private Animator animator;
    private AudioSource shootSound;

    private void Start()
    {
        shootSound = GetComponent<AudioSource>();        
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        transform.position += new Vector3(0, CameraController.Get().GetSpeed(), 0);

        Shoot();
        float horizontal = Input.GetAxis("Horizontal");
        animator.SetFloat("dir", horizontal);
        float vertical = Input.GetAxis("Vertical");

        transform.position += new Vector3(horizontal * speed * Time.deltaTime, vertical * speed * Time.deltaTime, 0);
    }
    
    private void Shoot()
    {
        
        Vector3 bulletStartPos = new Vector3(transform.position.x + bulletPosX, transform.position.y + bulletPosY, 0);

        if (Input.GetKeyDown(KeyCode.J))
        {
            shootSound.PlayOneShot(shootSound.clip,0.50f);            
            for (int i = 0; i < GameManager.Get().GetRange(); i++)
            {                
                Instantiate(bullet, bulletStartPos, Quaternion.identity, BulletGroup.Get().transform);
                if (GameManager.Get().GetRange() > 1)
                {
                    Vector3 bulletRangePos = new Vector3(i * bulletSpacing, 0);
                    Instantiate(bullet, (bulletStartPos + bulletRangePos), Quaternion.identity, BulletGroup.Get().transform);
                    Instantiate(bullet, (bulletStartPos - bulletRangePos), Quaternion.identity, BulletGroup.Get().transform);
                }
            }            
        }
        if (Input.GetKeyDown(KeyCode.Space) && GameManager.Get().BombOK())
        {
            Instantiate(bomb, this.transform.position, Quaternion.identity);            
        }
    }
    public void EndShoot()
    {
        animator.SetBool("shooting", false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameManager.Get().ReduceEnergy();  
        }
    }
}
