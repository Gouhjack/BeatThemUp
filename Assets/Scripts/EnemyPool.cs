using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    #region Expose

    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private int _maxEnemy;

    #endregion

    #region Unity Lyfecycle
    private void Awake()
    {
        _enemies = new GameObject[_maxEnemy];
        for (int i = 0; i < _maxEnemy; i++)
        {
            _enemies[i] = Instantiate(_enemyPrefab, transform);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    #endregion

    #region Methods

    public GameObject GetEnemy()
    {
        for (int i = 0; i < _maxEnemy; i++)
        {
            if (!_enemies[i].activeInHierarchy)
            {
                return _enemies[i];
            }
        }
        return null;
    }
    #endregion

    #region Private & Protected

    private GameObject[] _enemies;

    #endregion
}
