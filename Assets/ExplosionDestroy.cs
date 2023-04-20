using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDestroy : MonoBehaviour
{
    public GameObject cubeExplosionUI;
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        Display();
        Destroy(gameObject, 1.5f);
    }



    public void Display()
    {
        Instantiate(cubeExplosionUI, cam.transform.position, Quaternion.identity);
    }
}
