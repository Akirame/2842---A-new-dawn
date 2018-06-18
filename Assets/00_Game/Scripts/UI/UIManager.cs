using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviourSingleton<UIManager>
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
        CheckEnergy();
    }

    private void DrawBombText()
    {
        bombText.text = ("x" + GameManager.Get().GetBombCant());
    }
    private void CheckEnergy()
    {
        if (energy != GameManager.Get().GetEnergy())
        {
            energy = GameManager.Get().GetEnergy();
            energySlider.value = energy / 100;            
        }
        
    }
    private void DrawScoreText()
    {
        scoreText.text = GameManager.Get().GetScore().ToString("0000000");
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
