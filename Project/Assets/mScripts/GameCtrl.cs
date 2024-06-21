using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : MonoBehaviour
{

    public static GameCtrl Instance;
    private void Awake()
    {
        Instance = this;
    }

    public int EnemyCount;

    public GameObject winPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyCount<=0)
        {
            winPanel.SetActive(true);
        }
    }


    public void UPdateEnmyCount()
    {
        EnemyCount--;
    }
}
