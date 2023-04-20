using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointDisplay : MonoBehaviour
{
    public static PointDisplay instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreInTime;
    int score = 0;
    int scoreIn = 0;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text =  "POINTS : " + score.ToString();
        scoreInTime.text = " + " + scoreIn.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints()
    {
        
        for (int i = 0; i < 2; i++)
        {
            score += score + 1 * 2;
        }
        scoreText.text = "POINTS: " + score.ToString();
        

    }

    public void PointCount()
    {
        scoreIn += 1;
        scoreInTime.text = " + " + scoreIn.ToString();
    }
}
