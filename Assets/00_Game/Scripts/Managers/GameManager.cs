using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    private int score;
    private int shootRange;
    private int bombCant;
    private float energy;
    private bool playing;
    private bool deathOn;

    private void Start()
    {
        score = 0;
        shootRange = 1;
        energy = 100;
        bombCant = 2;

        deathOn = false;
        playing = false;
    }

    private void Update()
    {
        if (GameOver() && !deathOn)
            StartCoroutine(playerDeath());
    }


    public int GetRange()
    {
        return shootRange;
    }
    public void AddRange()
    {
        if (shootRange < 4)
            shootRange++;
        else
            AddScore(100);
    }

    public void AddScore(int _score)
    {
        score += _score;
    }
    public int GetScore()
    {
        return score;
    }

    public void AddEnergy()
    {
        if (energy < 100)
            energy += 20;
        else
            AddScore(100);
    }
    public void ReduceEnergy()
    {
        energy -= 20;
        shootRange = 1;
    }
    public float GetEnergy()
    {
        return energy;
    }

    public bool BombOK()
    {
        if (bombCant > 0)
        {
            bombCant--;
            return true;
        }
        else
            return false;
    }
    public int GetBombCant()
    {
        return bombCant;
    }

    public bool Playing()
    {
        if (LoaderManager.Get().OnLevel())
        {
            return true;
        }
        else
            return false;
    }
    public bool GameOver()
    {
        if (energy <= 0)
        {
            return true;
        }
        return false;
    }
    public void ChangeLevel()
    {
        energy = 100;
        bombCant = 2;
        shootRange = 1;
        ShipController.Get().ResetPos();
        CameraController.Get().ResetPos();
    }

    IEnumerator playerDeath()
    {
        deathOn = true;
        ShipController.Get().OnDeath();
        CameraController.Get().Deactivate();
        yield return new WaitForSeconds(5);        
        LoaderManager.Get().LoadScene("MainMenu");
        yield return null;
        ShipController.Get().Revive();
        CameraController.Get().Activate();
        ChangeLevel();
        deathOn = false;
    }
}
