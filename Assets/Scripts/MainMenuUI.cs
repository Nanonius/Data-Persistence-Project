using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuUI : MonoBehaviour
{
    //Main Menu
    public GameObject startElements;
    public GameObject difficulties;

    // Start is called before the first frame update
    void Start()
    {
        startElements.SetActive(true);
        difficulties.SetActive(false);
    }

    public void ShowDifficulties()
    {
        startElements.SetActive(false);
        difficulties.SetActive(true);
    }

    public void StartEasy()
    {
        GameManager.Instance.ballSpeed = 2.0f;
        SceneManager.LoadScene(1);
    }

    public void StartMedium()
    {
        GameManager.Instance.ballSpeed = 3.0f;
        SceneManager.LoadScene(1);
    }

    public void StartHard()
    {
        GameManager.Instance.ballSpeed = 4.0f;
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        GameManager.Instance.Save();
        //Save function
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
    }

}
