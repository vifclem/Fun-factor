
using UnityEngine;

public class CubeExplosion : MonoBehaviour
{
    public GameObject explosion;


   
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void Explosion()
    {


        

    }
    void Delay()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ground")
        {
            //Instantiate(gameObject);
            Debug.Log("ha");
        }
    }
}
