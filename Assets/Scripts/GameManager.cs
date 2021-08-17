using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float ballSpeed = 2.0f;
    public int highscore;

    //Highscore table
    public string player1;
    public string player2;
    public string player3;
    public string player4;
    public string player5;

    public int highscorePlayer1;
    public int highscorePlayer2;
    public int highscorePlayer3;
    public int highscorePlayer4;
    public int highscorePlayer5;

    public bool gameActive;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        Load();
    }

    void ResetHighscores()
    {
        player1 = "Player";
        player2 = "Player";
        player3 = "Player";
        player4 = "Player";
        player5 = "Player";

        highscorePlayer1 = 0;
        highscorePlayer2 = 0;
        highscorePlayer3 = 0;
        highscorePlayer4 = 0;
        highscorePlayer5 = 0;
        Save();
    }

    [System.Serializable]
    class SaveData
    {
        public string player1;
        public string player2;
        public string player3;
        public string player4;
        public string player5;

        public int highscorePlayer1;
        public int highscorePlayer2;
        public int highscorePlayer3;
        public int highscorePlayer4;
        public int highscorePlayer5;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.player1 = player1;
        data.player2 = player2;
        data.player3 = player3;
        data.player4 = player4;
        data.player5 = player5;

        data.highscorePlayer1 = highscorePlayer1;
        data.highscorePlayer2 = highscorePlayer2;
        data.highscorePlayer3 = highscorePlayer3;
        data.highscorePlayer4 = highscorePlayer4;
        data.highscorePlayer5 = highscorePlayer5;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            player1 = data.player1;
            player2 = data.player2;
            player3 = data.player3;
            player4 = data.player4;
            player5 = data.player5;

            highscorePlayer1 = data.highscorePlayer1;
            highscorePlayer2 = data.highscorePlayer2;
            highscorePlayer3 = data.highscorePlayer3;
            highscorePlayer4 = data.highscorePlayer4;
            highscorePlayer5 = data.highscorePlayer5;
        }
    }
}
