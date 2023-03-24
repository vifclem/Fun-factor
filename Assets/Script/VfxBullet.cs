
using UnityEngine;

public class VfxBullet : MonoBehaviour
{
    
    [Header("Assingable")]
    public Rigidbody rb;
    public GameObject explosion;
    public LayerMask Enemies;

    
    [Space]
    [Header("Stats")]
    [Range(0f, 1f)]
    public float bounciness;
    public bool useGravity;

    
    [Space]
    [Header("Damages")]
    public float explosionRange;
    public float explosionForce;

    
    [Space]
    [Header("LifeTime")]
    public int maxCollisions;
    public float maxLifetime;
    public bool explodeOnTouch = true;

    int collisions;
    PhysicMaterial physics_mat;

    private void Start()
    {
        Setup();
    }

    private void Update()
    {
        //Quand la bullet explose
        if (collisions > maxCollisions) Explode();

        //Count down de la vie de la bullet
        maxLifetime -= Time.deltaTime;
        if (maxLifetime <= 0) Explode();
    }

    private void Explode()
    {
        //Instantiate explosion
        if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);

        //Check des ennemies
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange, Enemies);
        for (int i = 0; i < enemies.Length; i++)
        {
            //Add explosion force (if enemy has a rigidbody)
            if (enemies[i].GetComponent<Rigidbody>())
                enemies[i].GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRange);
        }

        Invoke("Delay", 0.05f);
    }
    private void Delay()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Don't count collisions with other bullets
        if (collision.collider.CompareTag("Bullet")) return;

        //Count up collisions
        collisions++;

        //Explode if bullet hits an enemy directly and explodeOnTouch is activated
        if (collision.collider.CompareTag("Enemy") && explodeOnTouch) Explode();
    }

    private void Setup()
    {
        //Create a new Physic material
        physics_mat = new PhysicMaterial();
        physics_mat.bounciness = bounciness;
        physics_mat.frictionCombine = PhysicMaterialCombine.Minimum;
        physics_mat.bounceCombine = PhysicMaterialCombine.Maximum;
        //Assign material to collider
        GetComponent<SphereCollider>().material = physics_mat;

        
        rb.useGravity = useGravity;
    }

  
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }
}
