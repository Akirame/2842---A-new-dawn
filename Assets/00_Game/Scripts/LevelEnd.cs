using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Scenes
{        
    LEVEL2,
    FINAL
}

public class LevelEnd : MonoBehaviour {

    public Scenes scene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BoundWall")
        {
            GameManager.Get().ChangeLevel();
            switch (scene)
            {
                case Scenes.LEVEL2:
                    LoaderManager.Get().LoadScene("Level2");
                    break;
                case Scenes.FINAL:
                    LoaderManager.Get().LoadScene("FinalScreen");
                    break;
            }
        }
    }
}
