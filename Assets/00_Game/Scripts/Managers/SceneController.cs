using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scenes{
    MENU,
    LEVEL1,
    LEVEL2,
    END
}
public class SceneController : MonoBehaviour
{
    public Scenes scene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BoundWall")
        {
            switch (scene)
            {
                case Scenes.LEVEL1:
                    UnityEngine.SceneManagement.SceneManager.LoadScene(1);
                    break;
                case Scenes.LEVEL2:
                    UnityEngine.SceneManagement.SceneManager.LoadScene(3);
                    break;
            }
        }
    }
}
