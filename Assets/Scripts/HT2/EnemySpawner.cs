using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _spawnPointsHandler;
    [SerializeField] private List<Transform> _spawnPoints;
    private float _cooldown = 2.0f;
    private int _spawnIndex = 0;


    private void Start()
    {
        _spawnPoints = _spawnPointsHandler.GetComponentsInChildren<Transform>().ToList();
        _spawnPoints.Remove(_spawnPointsHandler);
        StartCoroutine(InstantiateEnemy());
    }

    IEnumerator InstantiateEnemy()
    {
        Instantiate(_enemyPrefab, _spawnPoints[_spawnIndex].position, Quaternion.identity);
        _spawnIndex++;
        if(_spawnIndex <= _spawnPoints.Count - 1)
        {
            yield return new WaitForSeconds(_cooldown);
            StartCoroutine(InstantiateEnemy());
        }
    }
}
