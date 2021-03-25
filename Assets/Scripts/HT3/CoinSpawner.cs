using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _coinPositions;
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private Transform _parentObject;
    private void Start()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        foreach (Transform coinPosition in _coinPositions)
        {
            GameObject coin = Instantiate(_coinPrefab, coinPosition);
            coin.transform.localPosition = new Vector2(0, 0);
            coin.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
            
    }
}
