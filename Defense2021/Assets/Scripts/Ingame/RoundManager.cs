using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{

    public GameObject Ourteam;
    public GameObject Enemy;
    public GameObject EnemyKing;
    public bool Enemykingenable = false;
    bool EnemykingSet = false;
    public float row = 5f;
    bool enableSpawn = true;
    public int EnemyCount = 0;
    public int RemainEnemyCount = 0;
    DateManager datemanager;
    bool EndRound = true;

    void SpawnEnemy()
    {
        for (int i = 0; i < 3; i++)
        {
            if (enableSpawn)
            {
                row -= 100f;
                //GameObject enemy = (GameObject)Instantiate(Enemy, new Vector3(500f, 0f, row), Quaternion.identity);
                GameObject enemy = (GameObject)Instantiate(Enemy, new Vector3(500f, 0f, row), Quaternion.Euler(0, -90f, 0));
                EnemyCount += 1;
                RemainEnemyCount += 1;
            }
        }
        row = 5f;

    }
    void SpawnEnemyKing()
    {
        
            GameObject enemyking = (GameObject)Instantiate(EnemyKing, new Vector3(300f, 0f, -200f), Quaternion.Euler(0, -90f, 0));
            
        
    }
    // Start is called before the first frame update
    void Start()
    {
        datemanager = GameObject.Find("Date Manager").GetComponent<DateManager>();
        InvokeRepeating("SpawnEnemy", 1, 3);

    }

    // Update is called once per frame
    void Update()
    {
        if ((EnemyCount > 10 && Enemykingenable == false) && EnemykingSet == false )
        {
            CancelInvoke("SpawnEnemy");
            SpawnEnemyKing();
            EnemykingSet = true;
            EndRound = true;
        }
        else if (Enemykingenable == true && EnemykingSet == true)
        {
            EnemykingSet = false;
        }

        if (EndRound == true && RemainEnemyCount == 0)
        {
            datemanager.date += 1;
        }
       

    }
}