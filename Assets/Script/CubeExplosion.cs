
using UnityEngine;
using TMPro;

public class CubeExplosion : MonoBehaviour
{
    public GameObject explosion;

    public static CubeExplosion instance;
    public int cubeLeft;
    
    public Vector3 cubePos;

    private void Awake()
    {
        instance = this;
        cubeLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
        
    }

    void Update()
    {
        Debug.Log(cubeLeft);
        cubePos = transform.position;
    }

    void Explosion()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        

    }
    void Delay()
    {
        
        Destroy(gameObject);
        
    }


    public void CubePosition0(Vector3 position)
    {
        cubePos = position;
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

       
        //Invoke("Delay", 0.1f);
       
    }


   




}
