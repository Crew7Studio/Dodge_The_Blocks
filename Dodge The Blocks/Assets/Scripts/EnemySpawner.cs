using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    private static EnemySpawner _instance;
    public static EnemySpawner Instance { get { return _instance; } }

    [SerializeField] private Transform _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnRate;

    public int _waveThreshold = 10;           // When wave count is greater than this increase gravity of enemy
    public int _waveCounter;

    private void OnEnable()
    {
        if(_instance == null) { _instance = this; }
    }

    void Start()
    {
        _waveCounter = 0;
        StartCoroutine(SpawnWave());
    }

   
    private IEnumerator SpawnWave()
    {
        _waveCounter++;

        float randSpace = Random.Range(0, _spawnPoints.Length);
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            if(i != randSpace)
            {
                Instantiate(_enemyPrefab, _spawnPoints[i].position, Quaternion.identity);
            }
        }

        yield return new WaitForSeconds(_spawnRate);
        StartCoroutine(SpawnWave());

    }
}
