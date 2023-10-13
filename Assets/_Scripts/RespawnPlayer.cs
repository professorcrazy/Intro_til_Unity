using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnPlayer : MonoBehaviour
{
    public Vector3 spawnPoint;
    public int restartAfterDeaths = 3;
    int currentDeaths = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = transform.position;
        currentDeaths = restartAfterDeaths;
    }

    public void Respawn()
    {
        currentDeaths--;
        if (currentDeaths == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else { 
            transform.position = spawnPoint;
        }
    }

    public void UpdateSpawnPoint(Vector3 pos)
    {
        spawnPoint = pos;
    }


}
