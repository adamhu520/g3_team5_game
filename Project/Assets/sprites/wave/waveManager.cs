using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private LivingEntity playerEntity;
    [SerializeField] private Transform[] LivingEntity ;

    public wave[] waves;
    private wave _currentWave;
    private int _currentWaveIndex;


    private int _enemyRemainingAliveCount;
    private float _upgrade;

    private void Start()
    {
        if (spawnPoints.Length ==0)
        {
            Debug.LogError(message: "Can't find enemy spawn point, please check!");
            return;
        }

        if (playerEntity == null)
        {
            Debug.LogError(message: "Can't find player, please check!");
            return;
        }

        playerEntity.OnDeath += OnPlayerDeath;

        StartCoroutine(routine: NextWaveCoroutine());
    }

    private IEnumerator NextWaveCoroutine()
    {
        _currentWaveIndex++;
        if (_currentWaveIndex -1 < waves.Length)
        {
            _currentWave = waves[_currentWaveIndex - 1];
            _enemyRemainingAliveCount = _currentWave.count;

            for (int i = 0; i < _currentWave.count; i++)
            {
                int spawnIndex = Random.Range(0,spawnPoints.Length);
                Beetle beetle = Instantiate(_currentWave.beetle, spawnPoints[spawnIndex].position, Quaternion.identity);
                beetle.target = playerEntity.transform;
                beetle.Setup(playerEntity.transform, _upgrade);
                beetle.OnDeath += OnEnemyDeath;
                yield return new WaitForSeconds(_currentWave.timeBetweenSpawn);
            }
        }
        else
        {
            _currentWave = null;

            //ÄÑ¶ÈÌáÉý
            _upgrade += 0.1f;
            StartCoroutine(routine: NextWaveCoroutine());
        }
    }

    private void OnEnemyDeath() 
    {
        _enemyRemainingAliveCount--;
        if (_enemyRemainingAliveCount == 0)
        {
            StartCoroutine(routine: NextWaveCoroutine());
        }
    }

    private void OnPlayerDeath()
    {
        StopCoroutine(routine: NextWaveCoroutine());
        Debug.Log(message: "Game Over!!!");
    }
}
