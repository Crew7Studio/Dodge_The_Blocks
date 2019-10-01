using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private string _mainMenu = "Main_Menu";

    private void Update()
    {
        // if gameover screen is active no need to show pausemenu, since we slow time it lags.
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) && !GameManager.Instance.isGameOver)
        {
            Toggle();
        }
    }

    private void Toggle()
    {
        _pauseMenu.SetActive(!_pauseMenu.activeSelf);

        if (_pauseMenu.activeSelf)
        {
            Time.timeScale = 0f;
        }else if (!_pauseMenu.activeSelf)
        {
            Time.timeScale = 1f;
        }
    }

    public void Continue()
    {
        Toggle();
    }

    public void MainMenu()
    {
        Toggle();
        SceneManager.LoadScene(_mainMenu);
    }
}
