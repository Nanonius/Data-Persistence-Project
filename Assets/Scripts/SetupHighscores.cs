using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SetupHighscores : MonoBehaviour
{
    //Highscore table
    public TextMeshProUGUI player1;
    public TextMeshProUGUI player2;
    public TextMeshProUGUI player3;
    public TextMeshProUGUI player4;
    public TextMeshProUGUI player5;

    public TextMeshProUGUI highscorePlayer1;
    public TextMeshProUGUI highscorePlayer2;
    public TextMeshProUGUI highscorePlayer3;
    public TextMeshProUGUI highscorePlayer4;
    public TextMeshProUGUI highscorePlayer5;

    // Start is called before the first frame update
    void Start()
    {
        player1.text = GameManager.Instance.player1;
        player2.text = GameManager.Instance.player2;
        player3.text = GameManager.Instance.player3;
        player4.text = GameManager.Instance.player4;
        player5.text = GameManager.Instance.player5;

        highscorePlayer1.text = GameManager.Instance.highscorePlayer1.ToString();
        highscorePlayer2.text = GameManager.Instance.highscorePlayer2.ToString();
        highscorePlayer3.text = GameManager.Instance.highscorePlayer3.ToString();
        highscorePlayer4.text = GameManager.Instance.highscorePlayer4.ToString();
        highscorePlayer5.text = GameManager.Instance.highscorePlayer5.ToString();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
