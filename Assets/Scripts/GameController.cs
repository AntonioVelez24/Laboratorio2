using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject pausePanel;
    private SpriteRenderer _compSpriteRenderer;
    private bool isPaused = false;
    public Text timeText;
    public Text healthText;
    public float passedTime;
    private PlayerControl playerControl;
    void Awake()
    {
        _compSpriteRenderer = player.GetComponent<SpriteRenderer>();
        playerControl = player.GetComponent<PlayerControl>();
    }
    public void ColorRed()
    {
        ChangeColor(Color.red);
    }
    public void ColorBlue()
    {
        ChangeColor(Color.blue);
    }
    public void ColorGreen()
    {
        ChangeColor(Color.green);
    }
    private void ChangeColor(Color newColor)
    {
        _compSpriteRenderer.color = newColor;
    }
    public void Pause()
    {
        if (isPaused == false)
        {
            isPaused = true;
            Time.timeScale = 0f;
            pausePanel.SetActive(true);            
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
        }  
    }
    // Update is called once per frame
    void Update()
    {
        if (!isPaused)
        {
            passedTime += Time.deltaTime;
            int seconds = Mathf.FloorToInt(passedTime);
            timeText.text = "Tiempo: " + seconds;
            if (passedTime >= 30)
            {
                PlayerPrefs.SetString("GameResult", "GANASTE");
                SceneManager.LoadScene("EndScreen");
            }
        }
        healthText.text = "Salud: " + playerControl.health;
        if (playerControl.health <= 0)
        {
            PlayerPrefs.SetString("GameResult", "Game Over");
            SceneManager.LoadScene("EndScreen"); 
        }        
    }
}
