using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    #region Expose

    [Header("Enemies")]
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private int _maxEnemy;

    [Header("Spawn Enemies Parameters")]
    [SerializeField]
    private float _spawnDelay;
    [SerializeField]
    private float _nextSpawnTime;
    [SerializeField]
    [Range(0.5f, 5)]
    private float _spawnerRadius;
    [SerializeField]
    private Transform[] _pointToSpawn;

    #endregion

    #region Unity Lyfecycle

    private void Awake()
    {
        _enemies = new GameObject[_maxEnemy];
        for (int i = 0; i < _maxEnemy; i++)
        {
            int randSpawPoint = Random.Range(0, _pointToSpawn.Length);
            _enemies[i] = Instantiate(_enemyPrefab, _pointToSpawn[randSpawPoint]);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad > _nextSpawnTime)
        {
            GameObject newEnemy = SpawnEnemy();

            _nextSpawnTime = Time.timeSinceLevelLoad + _spawnDelay;
        }
    }

    #endregion

    #region Methods

    private GameObject SpawnEnemy()
    {
        Vector2 position = Random.insideUnitCircle * _spawnerRadius + (Vector2)transform.position;
        GameObject enemy = _enemyPrefab;
        if (enemy != null)
        {
            enemy.SetActive(true);
            enemy.transform.position = position;
        }
        return enemy;
    }

    #endregion

    #region Private & Protected

    private GameObject[] _enemies;

    #endregion
}
