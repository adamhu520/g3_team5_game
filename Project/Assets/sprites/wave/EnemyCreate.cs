using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyCreate : MonoBehaviour
{
    public static EnemyCreate instance;
    public List<int> waveNum = new List<int>();
    public List<GameObject> enemyPrefab = new List<GameObject>();
    public List<Transform> refreshPosition = new List<Transform>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void CreatWaveEnemy(int index)
    {
        if(index!=3)
        {
           for(int i =0;i<waveNum[index-1];i++)
            {
                Instantiate(enemyPrefab[index - 1]).transform.position = refreshPosition[Random.Range(0, refreshPosition.Count)].position;
            }
        }else
        {
            int y = Random.Range(0, waveNum[2]);
            for (int i = 0; i < waveNum[2]-y; i++)
            {
                Instantiate(enemyPrefab[0]).transform.position = refreshPosition[Random.Range(0, refreshPosition.Count)].position;
            }
            for (int i = 0; i <y; i++)
            {
                Instantiate(enemyPrefab[1]).transform.position = refreshPosition[Random.Range(0, refreshPosition.Count)].position;
            }
        }
    }
}
