using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
   
    public Text bombText;
    public Text scoreText;
    public Slider energySlider;

    private float energy;
    private int bombCant;
    private int score;

    private void Start()
    {
        energy = GameManager.Get().GetEnergy();
        bombCant = GameManager.Get().GetBombCant();                
        score = GameManager.Get().GetScore();

        DrawBombText();
        DrawScoreText();
    }
    private void Update()
    {
        CheckBomb();
        CheckScore();
        DrawEnergy();
    }

    private void DrawBombText()
    {
        bombText.text = ("x" + GameManager.Get().GetBombCant());
    }
    private void DrawEnergy()
    {
        if (energy != GameManager.Get().GetEnergy())
        {
            energySlider.value = energy / 100;
            energy = GameManager.Get().GetEnergy();
        }
    }
    private void DrawScoreText()
    {
        int scoreAux = GameManager.Get().GetScore();
        if (scoreAux <= 0)
            scoreText.text = ("000000" + GameManager.Get().GetScore());
        else if (scoreAux > 0 && scoreAux < 1000)
            scoreText.text = ("0000" + GameManager.Get().GetScore());
        else if (scoreAux >= 1000 && scoreAux < 10000)
            scoreText.text = ("000" + GameManager.Get().GetScore());
    }
    /// <summary>
    /// Si la cantidad de bombas cambió, actualiza el texto.
    /// </summary>
    private void CheckBomb()
    {
        if (bombCant != GameManager.Get().GetBombCant())
        {
            DrawBombText();
            bombCant = GameManager.Get().GetBombCant();
        }
    }
    /// <summary>
    /// Si el score cambió, actualiza el texto.
    /// </summary>
    private void CheckScore()
    {
        if (score != GameManager.Get().GetScore())
        {
            DrawScoreText();
            score = GameManager.Get().GetScore();
        }
    }
}
