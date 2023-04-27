using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalExplosion : MonoBehaviour
{

    public GameObject explosion;
    public Transform[] exploPos;
    public static FinalExplosion instance;
    

 

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void FinaleExplosion()
    {
        for (int i = 0 ; i < exploPos.Length; i++)
        {
            Instantiate(explosion, exploPos[i].position, Quaternion.identity);
        }
        
    }
}
