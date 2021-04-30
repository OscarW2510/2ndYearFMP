using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoomArea : MonoBehaviour
{
    public List<Enemy> roomEnemies;
    public GameObject[] roomEntrances;
    public bool entered = false;
    public bool cleared = false;
    public int enemyCount;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Player" && entered == false)
        {
            foreach(var entrance in roomEntrances)
            {
                entrance.SetActive(true);
            }
            entered = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        foreach (var entrance in roomEntrances)
        {
            entrance.SetActive(false);
        }
        enemyCount = roomEnemies.Count;
        foreach (var enemy in roomEnemies)
        {
            enemy.OnDeath += DecreaseCount;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyCount <= 0 && cleared == false)
        {
            foreach (var entrance in roomEntrances)
            {
                entrance.SetActive(false);
            }
            cleared = true;
        }
    }

    void DecreaseCount()
    {
        enemyCount--;
    }
}
