using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenuController : MonoBehaviour {

    public GameObject imageStart;
    public GameObject imageExit;
    public AudioClip audioMove;
    public AudioClip audioSelect;
    public Camera cam;

    private bool onStart;

    private void Start()
    {
        imageStart.SetActive(true);
        imageExit.SetActive(false);
        onStart = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && onStart)
        {
            AudioSource.PlayClipAtPoint(audioMove, cam.transform.position, 0.70f);
            imageStart.SetActive(false);
            imageExit.SetActive(true);
            onStart = false;
        }
        else if (Input.GetKeyDown(KeyCode.W) && !onStart)
        {
            AudioSource.PlayClipAtPoint(audioMove, cam.transform.position, 1f);
            imageStart.SetActive(true);
            imageExit.SetActive(false);
            onStart = true;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (onStart)
            {
                StartCoroutine(ChangeScene("Level1"));
            }
            else
            {
                Application.Quit();
            }
        }
    }
        IEnumerator ChangeScene(string sceneName)
        {
            AudioSource.PlayClipAtPoint(audioSelect, cam.transform.position, 1f);
            yield return new WaitForSeconds(2);
            LoaderManager.Get().LoadScene(sceneName);
        }
}
