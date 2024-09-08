using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject pausePanel;
    private SpriteRenderer _compSpriteRenderer;
    private bool isPaused = false;
    public Text timeText;
    public Text healthText;
    public Text scoreText; 
    public float passedTime;
    private PlayerControl playerControl;

    public static event Action OnGameLost; 
    public static event Action OnGameWon;
    void Awake()
    {
        _compSpriteRenderer = player.GetComponent<SpriteRenderer>();
        playerControl = player.GetComponent<PlayerControl>();
    }
    void OnEnable()
    {
        PlayerControl.OnPlayerDamaged += UpdateHealth;
        PlayerControl.OnPlayerScore += UpdateScore;
        GameController.OnGameLost += GameOver;
        GameController.OnGameWon += GameWon;
    }
    void OnDisable()
    {
        PlayerControl.OnPlayerDamaged -= UpdateHealth;
        PlayerControl.OnPlayerScore -= UpdateScore;
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
    private void UpdateScore(int newScore)
    {
        scoreText.text = "Puntaje: " + newScore;
    }
    private void UpdateHealth(int currentHealth)
    {
        healthText.text = "Salud: " + currentHealth;
        if (currentHealth <= 0)
        {
            OnGameLost?.Invoke();
        }
    }
    void Update()
    {
        if (!isPaused)
        {
            passedTime += Time.deltaTime;
            int seconds = Mathf.FloorToInt(passedTime);
            timeText.text = "Tiempo: " + seconds;
            if (passedTime >= 28)
            {
                OnGameWon?.Invoke();
            }
        }
    }
    private void GameWon()
    {
        PlayerPrefs.SetString("GameResult", "Ganaste");
        SceneManager.LoadScene("EndScreen");
    }
    private void GameOver()
    {
        PlayerPrefs.SetString("GameResult", "Game Over");
        SceneManager.LoadScene("EndScreen");
    }
}
