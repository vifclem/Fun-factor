
using UnityEngine;
using TMPro;

public class CubeExplosion : MonoBehaviour
{
    public GameObject explosion;

    public static CubeExplosion instance;


    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        
    }

    void Explosion()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        

    }
    void Delay()
    {
        
        Destroy(gameObject);
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ground")
        {
            Explosion();
            PointDisplay.instance.AddPoints();
            PointDisplay.instance.PointCount();
            PointDisplay.instance.FinalDisplay();
            Debug.Log("ha");
            
        }

       
        Invoke("Delay", 0.1f);
       
    }


   




}
