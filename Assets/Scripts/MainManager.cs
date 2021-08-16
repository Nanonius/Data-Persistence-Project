using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public GameObject GameOverText;
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;

    public GameObject newHighscore;
    public GameObject menuButton;
    public TextMeshProUGUI enteredName;

    // Start is called before the first frame update
    void Start()
    {
        menuButton.SetActive(false);
        newHighscore.SetActive(false);
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameManager.Instance.gameActive = true;
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * GameManager.Instance.ballSpeed, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    public void GameOver()
    {
        menuButton.SetActive(true);
        m_GameOver = true;
        GameManager.Instance.gameActive = false;
        if (m_Points > GameManager.Instance.highscorePlayer5)
        {
            GameManager.Instance.highscore = m_Points;
            newHighscore.SetActive(true);
        }
        else
        {
            GameOverText.SetActive(true);
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PostHighscore()
    {
        if (GameManager.Instance.highscore > GameManager.Instance.highscorePlayer1)
        {
            GameManager.Instance.player1 = enteredName.text;
            GameManager.Instance.highscorePlayer1 = GameManager.Instance.highscore;
        }
        else if (GameManager.Instance.highscore > GameManager.Instance.highscorePlayer2)
        {
            GameManager.Instance.player2 = enteredName.text;
            GameManager.Instance.highscorePlayer2 = GameManager.Instance.highscore;
        }
        else if (GameManager.Instance.highscore > GameManager.Instance.highscorePlayer3)
        {
            GameManager.Instance.player3 = enteredName.text;
            GameManager.Instance.highscorePlayer3 = GameManager.Instance.highscore;
        }
        else if (GameManager.Instance.highscore > GameManager.Instance.highscorePlayer4)
        {
            GameManager.Instance.player4 = enteredName.text;
            GameManager.Instance.highscorePlayer4 = GameManager.Instance.highscore;
        }
        else if (GameManager.Instance.highscore > GameManager.Instance.highscorePlayer5)
        {
            GameManager.Instance.player5 = enteredName.text;
            GameManager.Instance.highscorePlayer5 = GameManager.Instance.highscore;
        }
        SceneManager.LoadScene(2);
    }
}
