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
            _enemyPrefab.GetComponent<BoxCollider2D>().isTrigger = false;
            //StartCoroutine(timer());
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

    //IEnumerator timer()
    //{
    //    yield return new WaitForSeconds(0.5f);
    //    _enemyPrefab.GetComponent<BoxCollider2D>().isTrigger = true;
    //}

    #endregion

    #region Private & Protected

    private GameObject[] _enemies;

    #endregion
}
