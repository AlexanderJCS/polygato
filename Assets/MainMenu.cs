
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TMP_Text difficultytext; 
    
    public enum Difficulty { NORMAL, AUTOPLAY, FREESTYLE }
    Difficulty currentDifficulty = Difficulty.NORMAL;

    public void ToggleDifficulty()
    {
        if(difficultytext == null) 
        {
            Debug.LogError("Difficulty Text is not assigned in the Inspector!");
            return;
        }

        switch (currentDifficulty)
        {
            case Difficulty.NORMAL:
                currentDifficulty = Difficulty.AUTOPLAY;
                difficultytext.text = "‹ AUTOPLAY ›";
                //GameModeMode.gameMode = GameMode.AUTOPLAY;
                break;
            case Difficulty.AUTOPLAY:
                currentDifficulty = Difficulty.FREESTYLE;
                difficultytext.text = "‹ FREESTYLE ›";

                //GameModeMode.gameMode = GameMode.FREESTYLE;
                break;
            case Difficulty.FREESTYLE:
                currentDifficulty = Difficulty.NORMAL;
                difficultytext.text = "‹ NORMAL ›";

                //GameModeMode.gameMode = GameMode.NORMAL;
                break;
        }
    }

    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}