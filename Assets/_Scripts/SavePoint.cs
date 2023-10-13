using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public bool destroyOnTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){ 
            collision.GetComponent<RespawnPlayer>().UpdateSpawnPoint(transform.position);
            if (destroyOnTrigger)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
