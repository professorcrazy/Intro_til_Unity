using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    TMP_Text text;
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        text = GetComponent<TMP_Text>();
        UpdateScore(0);
    }

    public void UpdateScore (int point)
    {
        score += point;
        text.text = score.ToString();
    }

}
