using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointDisplay : MonoBehaviour
{
    public static PointDisplay instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreInTime;
    public TextMeshProUGUI mainDisplay;
    public TextMeshProUGUI mainDisplay2;
    public GameObject save;
    public GameObject load;
    public bool pActive = false;

    //public GameObject explosion;
    //public Transform explo1;



    int score = 0;
    static int scoreIn = 0;
    int finalScore = 22;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text =  "POINTS : " + score.ToString();
        scoreInTime.text = " + " + scoreIn.ToString();
        mainDisplay.text = " TU AS FAIT : " + finalScore.ToString() + " POINTS !!";
        mainDisplay2.text = "Tu est vraiment trop fort";
        mainDisplay.enabled = false;
        mainDisplay2.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pActive = true;
            save.SetActive(true);
            load.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.P) && !pActive)
        {
           
            save.SetActive(false);
            load.SetActive(false);
        }

    }

    public void AddPoints()
    {
        
        for (int i = 0; i < 1; i++)
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

    public void FinalDisplay()
    {
        if(scoreIn == 22)
        {
            Debug.Log("ahahah");
            mainDisplay.enabled = true;
            
            FinalExplosion.instance.FinaleExplosion();


        }
    }
}
