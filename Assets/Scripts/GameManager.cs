using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI textMeshProUGUI;
    public TextMeshProUGUI textMeshProUGUI_2;
    public TextMeshProUGUI gameOverUGUI;
    public Button restartButton;
    public GameObject titleScreen;
    public GameObject pauseScreen;

    public bool isGameActive;
    private float spawnRate = 1.0f;
    private int score;
    public int lives = 3;
    public bool isPause = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseGame();
        }
    }

    void TogglePauseGame()
    {
        if(!isPause)
        {
            isPause = true;
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
        }
        else
        {
            isPause = false;
            Time.timeScale = 1.0f;
            pauseScreen.SetActive(false);
        }
    }

    IEnumerator spawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            
        }
    }

    public void updateScore(int score)
    {
        this.score += score;
        textMeshProUGUI.text = "Score: " + this.score;
    }

    public void setLives()
    {
        textMeshProUGUI_2.text = "Lives: " + this.lives;
    }

    public void updateLives()
    {
        if(this.lives != 0)
        {
            this.lives -= 1;
            textMeshProUGUI_2.text = "Lives: " + this.lives;
        }
        
    }

    public void gameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverUGUI.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        spawnRate /= difficulty;
        StartCoroutine(spawnTarget());
        updateScore(0);
        setLives();
        titleScreen.SetActive(false);
    }
}
