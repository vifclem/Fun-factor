
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
            Debug.Log("ha");
        }

        Invoke("Delay", 0.1f);
    }
}
