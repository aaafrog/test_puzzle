using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] GameObject ScoreCounter;

    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        RefreshScore();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ScoreCalculation(int connect_Count)
    {
        if (connect_Count < 3) {

            score = score + (100 * (connect_Count + 1));

        }
        else if (connect_Count < 4)
        {
            score = score + (110 * (connect_Count + 1));
        }
        else if (connect_Count >= 4)
        {
            score = score + (130 * (connect_Count + 1));
        }


        RefreshScore();
    }

    void RefreshScore()
    {
        ScoreCounter.GetComponent<Text>().text = score.ToString();
    }
}
