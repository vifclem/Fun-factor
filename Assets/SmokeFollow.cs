using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SmokeFollow : MonoBehaviour
{

    


    
    // Update is called once per frame
    void Update()
    {
       transform.position = Shooting.instance.attackPoint.transform.position;
    }
}
