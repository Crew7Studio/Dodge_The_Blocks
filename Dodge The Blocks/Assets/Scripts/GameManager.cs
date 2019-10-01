using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    [SerializeField] private float _reloadDelay;
    [SerializeField] private float _timeSlowness;
    [SerializeField] private Text _inGameWaveCoutner;
    [SerializeField] private Text _waveCounter;
    [SerializeField] private GameObject _gameOverScreen;

    public bool isGameOver;

    private EnemySpawner _enemySpawner;


    private void OnEnable()
    {
        if(_instance == null) { _instance = this; }
        Time.timeScale = 1f;
        isGameOver = false;
    }



    private void Start()
    {
        _enemySpawner = EnemySpawner.Instance;
    }



    private void Update()
    {
        _inGameWaveCoutner.text = _enemySpawner._waveCounter.ToString();
    }



    public void GameOver()
    {
        isGameOver = true;
        StartCoroutine(Ending());
    }



    private IEnumerator Ending()
    {
        Time.timeScale = 1 / _timeSlowness;
        Time.fixedDeltaTime /= _timeSlowness;

        yield return new WaitForSeconds(_reloadDelay / _timeSlowness);

        Time.timeScale = 1;
        Time.fixedDeltaTime *= _timeSlowness;
        Destroy(FindObjectOfType<PlayerController>().gameObject, .5f);

        _gameOverScreen.SetActive(true);
        StartCoroutine(ResetLevel());
    }


    private IEnumerator ResetLevel()
    {
        int tempCounter = 0;

        while (tempCounter < _enemySpawner._waveCounter)
        {
            _waveCounter.text = tempCounter.ToString();
            tempCounter++;
            yield return new WaitForSeconds(.05f);
        }

    }
}
