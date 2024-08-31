using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }
    public void GameExit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
