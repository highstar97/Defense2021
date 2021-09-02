using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{

    public GameObject Ourteam;
    public GameObject Enemy;
    public float row = 5f;
    bool enableSpawn = true;
    public int EnemyCount = 0;
    public int RemainEnemyCount = 0;
    DateManager datemanager;
    bool EndRound = true;

    void SpawnEnemy()
    { 
    for (int i = 0; i< 3; i++)
         {
             if (enableSpawn)
             {
                row -= 10f;
                GameObject enemy = (GameObject)Instantiate(Enemy, new Vector3(500f, 0f, row), Quaternion.identity);
                EnemyCount += 1;
                RemainEnemyCount += 1;
            }
         }
       

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
        if (EnemyCount > 30)
        {
            CancelInvoke("SpawnEnemy");
            EndRound = true;
        }
        if (EndRound==true && RemainEnemyCount == 0)
        {
            datemanager.date += 1;
        }
       
    }
}
