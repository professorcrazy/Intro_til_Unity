using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public int point = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreManager.instance.UpdateScore(point);
        Destroy(this.gameObject);
    }
}
