using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _tutor;
    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1f;
        Application.targetFrameRate = 60;
    }


    public void TutorialOff()
    {
        _tutor.SetActive(false);
    }

    public void GameLose()
    {
        Time.timeScale = 0f;
        _losePanel.SetActive(true);
    }

    public void GameWin()
    {
        _winPanel.SetActive(true);
        Invoke(nameof(RestartLevel),1f);
    }
    

    public void RestartLevel()
    {
        _winPanel.SetActive(false);
        _losePanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}