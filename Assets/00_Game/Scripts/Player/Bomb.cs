using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float time = 5;
    public AnimationCurve ac;
    public AudioClip bombSound;

    private SpriteRenderer rend;
    private float timer = 0;
    private bool isRunning = false;
    private Color tmp;

    private void Awake()
    {
        AudioSource.PlayClipAtPoint(bombSound, CameraController.Get().transform.position, 1);
    }

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        tmp = rend.color;
        tmp.a = 0f;
        rend.color = tmp;
    }

    private void Update()
    {
        transform.position = CameraController.Get().GetPosition();
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        if(!isRunning)
        StartCoroutine(Fade(ac, time));
    }

    IEnumerator Fade(AnimationCurve ac, float time)
    {
        isRunning = true;
        while (timer <= time)
        {          
            tmp.a = Mathf.Lerp(0f, 0.5f, ac.Evaluate(timer / time));
            rend.color = tmp;
            timer += Time.deltaTime;
            yield return null;
        }
        EndAnim();
    }
    private void EndAnim()
    {
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
            Destroy(collision.gameObject);
    }
}
