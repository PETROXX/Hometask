using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private SpawnTypes SpawnType;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _spawnPointsHandler;
    [SerializeField] private List<Transform> _spawnPoints;
    private float _cooldown = 2.0f;
    private int _spawnIndex = 0;


    private void Start()
    {
        _spawnPoints = _spawnPointsHandler.GetComponentsInChildren<Transform>().ToList();
        _spawnPoints.Remove(_spawnPointsHandler);
        switch(SpawnType)
        {
            case SpawnTypes.InfiniteRandom:
                StartCoroutine(InfiniteRandomSpawn());
                break;
            case SpawnTypes.InfiniteSequential:
                StartCoroutine(InfiniteSequentialSpawn());
                break;
            case SpawnTypes.LimitedSequential:
                StartCoroutine(LimitedSequentialSpawn());
                break;
        }

    }

    IEnumerator LimitedSequentialSpawn()
    {
        Instantiate(_enemyPrefab, _spawnPoints[_spawnIndex].position, Quaternion.identity);
        _spawnIndex++;
        if(_spawnIndex <= _spawnPoints.Count - 1)
        {
            yield return new WaitForSeconds(_cooldown);
            StartCoroutine(LimitedSequentialSpawn());
        }
    }

    IEnumerator InfiniteRandomSpawn()
    {
        Instantiate(_enemyPrefab, _spawnPoints[Random.Range(0, _spawnPoints.Count)].position, Quaternion.identity);
        yield return new WaitForSeconds(_cooldown);
        StartCoroutine(InfiniteRandomSpawn());
    }

    IEnumerator InfiniteSequentialSpawn()
    {
        Instantiate(_enemyPrefab, _spawnPoints[_spawnIndex].position, Quaternion.identity);
        _spawnIndex++;
        if (_spawnIndex > _spawnPoints.Count - 1) _spawnIndex = 0;
        yield return new WaitForSeconds(_cooldown);
        StartCoroutine(InfiniteSequentialSpawn());
    }

    enum SpawnTypes
    {
        InfiniteRandom,
        InfiniteSequential,
        LimitedSequential
    }
}
