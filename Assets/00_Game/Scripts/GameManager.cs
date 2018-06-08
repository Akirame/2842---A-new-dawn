using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    private int score;
    private int shootRange;
    private float energy;
    private int bombCant;

    private void Start()
    {
        score = 0;
        shootRange = 1;
        energy = 100;
        bombCant = 2;
    }

    private void Update()
    {
        if (GameOver())
            Debug.Log("end");
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
            energy += 25;
        else
            AddScore(100);
    }
    public void ReduceEnergy()
    {
        energy -= 25;
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

    public bool GameOver()
    {
        if (energy < 0)
        {
            return true;
        }
        return false;
   }
}
