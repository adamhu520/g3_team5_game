using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    //[SerializeField] private Transform[] LivingEntity playerEntity;

    public static float timeBetweenWaves = 3.0f;
    public static int waveNumber;
    public static event System.Action OnNewWave;
    public wave[] waves;
    [SerializeField] private wave _currentWave;
    [SerializeField]private int _currentWaveIndex;
    private bool _isWaveValid = true;


    private int _enemyRemainingAliveCount;
    private float _upgrade;

    private void Start()
    {
       /* if (spawnPoints.Length ==0)
        {
            Debug.LogError(message: "Can't find enemy spawn point, please check!");
            return;
        }*/
        
        StartCoroutine(routine: NextWaveCoroutine());
    }

    private IEnumerator NextWaveCoroutine()
    {
        _currentWaveIndex++;

        if (_isWaveValid)
        {
            waveNumber++;
            OnNewWave?.Invoke();
        }
        yield return new WaitForSeconds(timeBetweenWaves);
        
        if (_currentWaveIndex -1 < waves.Length)
        {
            _currentWave = waves[_currentWaveIndex - 1];
            _enemyRemainingAliveCount = _currentWave.count;

            for (int i = 0; i < _currentWave.count; i++)
            {
                int spawnIndex = Random.Range(0,4);
                Beetle beetle = Instantiate(_currentWave.beetle, spawnPoints[spawnIndex].position, Quaternion.identity);
                //beetle.Setup(playerEntity.transform, _upgrade);
                beetle.OnDeath += OnEnemyDeath;
                yield return new WaitForSeconds(_currentWave.timeBetweenSpawn);
            }
            _isWaveValid = true;
        }
        else
        {
            _currentWaveIndex = 0;
            _isWaveValid = false;

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
        Debug.Log(message:"Game Over");
    }
}
