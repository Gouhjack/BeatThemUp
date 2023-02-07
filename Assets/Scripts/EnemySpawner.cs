using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    #region Expose

    [SerializeField]
    private EnemyPool _pool;

    [Header("Spawn Enemies")]
    [SerializeField]
    private float _spawnDelay;
    [SerializeField]
    private float _nextSpawnTime;
    [SerializeField]
    [Range(0.5f, 5)]
    private float _spawnerRadius;

    [Header("Valeurs pour dessiner le gizmo")]
    [SerializeField]
    Color _gizmoColor;
    [SerializeField]
    bool _drawGizmo;

    #endregion

    #region Unity Lyfecycle
    void Start()
    {
        
    }

    void Update()
    {
        if (Time.timeSinceLevelLoad > _nextSpawnTime)
        {
            GameObject newEnemy = SpawnEnemy();

            _nextSpawnTime= Time.timeSinceLevelLoad + _spawnDelay;
        }
    }

    private void OnDrawGizmos()
    {
        if (_drawGizmo)
        {
            Gizmos.color = _gizmoColor;
            Gizmos.DrawWireSphere(transform.position, _spawnerRadius);
        }
    }
    #endregion

    #region Methods

    private GameObject SpawnEnemy()
    {
        Vector2 position = Random.insideUnitCircle * _spawnerRadius + (Vector2)transform.position;
        GameObject enemy = _pool.GetEnemy();
        if (enemy != null)
        {
            enemy.SetActive(true);
            enemy.transform.position = position;
        }
        return enemy;
    }

    #endregion

    #region Private & Protected

    #endregion
}
