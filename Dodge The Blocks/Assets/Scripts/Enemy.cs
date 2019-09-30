using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float _gravityScaleThreshold = 20f;
    [SerializeField] private float _initialGravityScale = .5f;

    private EnemySpawner _enemySpawner;
    private Rigidbody2D _rbd;

    private void Awake()
    {
        _enemySpawner = EnemySpawner.Instance;
        _rbd = GetComponent<Rigidbody2D>();
        _rbd.gravityScale = _initialGravityScale;       // resetting gravity
    }

    private void Start()
    {
        // If current is greater than a threshold then increase the gravity i.e speed of falling
        if(_enemySpawner._waveCounter > _enemySpawner._waveThreshold)
        {
           _rbd.gravityScale += Time.timeSinceLevelLoad / _gravityScaleThreshold;
        }
    }

}
