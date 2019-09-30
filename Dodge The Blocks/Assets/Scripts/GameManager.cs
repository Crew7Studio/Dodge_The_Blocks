using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    [SerializeField] private float _reloadDelay;
    [SerializeField] private float _timeSlowness;

    private void OnEnable()
    {
        if(_instance == null) { _instance = this; }
    }



    public void GameOver()
    {
        StartCoroutine(Ending());
    }



    private IEnumerator Ending()
    {
        Time.timeScale = 1 / _timeSlowness;
        Time.fixedDeltaTime /= _timeSlowness;

        yield return new WaitForSeconds(_reloadDelay / _timeSlowness);

        Time.timeScale = 1;
        Time.fixedDeltaTime *= _timeSlowness;

        ResetLevel();
    }


    private void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
