using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private TextMeshProUGUI levelText;

    [SerializeField]
    private GameObject gameOverPanel;

    [SerializeField]
    private int score = 0;

    [SerializeField]
    private int level = 1;

    public bool isGameOver = false;


    // Awake is called before Start
    private void Awake() {
        if(instance == null) {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore() {
        score += 1;
        scoreText.text = "Score " + score;

        if(score % 10 == 0) {
            PoopSpawner spawner = FindObjectOfType<PoopSpawner>();
            if(spawner != null) {
                bool isIncreased = spawner.IncreaseSpeed();
                if(isIncreased) {
                    level += 1;
                    levelText.text = "Level " + level;
                }
            }
        }
    }

    public void GameOver() {
        if(isGameOver) {
            return;
        }

        isGameOver = true;
        FindObjectOfType<PoopSpawner>().StopSpawning();
        gameOverPanel.SetActive(true);
    }

    public void Restart() {
        SceneManager.LoadScene("GameScene");
    }
}
