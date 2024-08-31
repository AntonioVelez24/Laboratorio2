using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreenController : MonoBehaviour
{
    public Text resultText;

    // Start is called before the first frame update
    void Start()
    {
        string gameResult = PlayerPrefs.GetString("GameResult");
        resultText.text = gameResult;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
