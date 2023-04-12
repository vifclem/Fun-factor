using UnityEngine;
using TMPro;
public class Shooting : MonoBehaviour
{
   
    [Space]
    [Header("Bullet infos")]
    public GameObject bullet;
    public float shootForce, upwardForce;

    [Space]
    [Header("AudioSource")]
    public AudioSource reloadAudioSource;

    [Space]
    [Header("Gun infos")]
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    //public bool allowButtonHold;

    int bulletsLeft, bulletsShot;

    [Space]
    [Header("Shooting bools")]
    bool shooting, readyToShoot, reloading;

    [Space]
    [Header("Reference")]
    public Camera fpsCam;
    public Transform attackPoint;

    [Space]
    [Header("ShootVfx")]
    public GameObject ShootVFX;

    [Space]
    [Header("Display")]
    public TextMeshPro display;
   

    [Space]
    [Header("ShootingAnim")]
    public Animator animator;
    public bool IsShooting = false;

    [Space]
    [Header("Debug")]
    public bool allowInvoke = true;

    public static Shooting instance;

    private void Awake()
    {
        instance = this;
        bulletsLeft = magazineSize;
        readyToShoot = true;
        

    }

    private void Update()
    {
        MyInput();
        
        if(display != null)
        {
            display.SetText(bulletsLeft / bulletsPerTap + " / " + magazineSize / bulletsPerTap);
        }

    }
    private void MyInput()
    {
       shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //Jouer l'anim recoil
        if (Input.GetKey(KeyCode.Mouse0))
        {
            IsShooting = true;
        }
        
        //Reloading 
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();
        //Reload automatically when trying to shoot without ammo
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0) Reload();

        //Shooting
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = 0;

            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;
        
        if (IsShooting)
        {
            animator.SetTrigger("Shooting");
        }

       
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); 
        RaycastHit hit;

        //check if ray hits something
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75); 

        
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        //Calculer le spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate la nouvelle direction avec le spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0); 

        
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity); 
        currentBullet.transform.forward = directionWithSpread.normalized;

      
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        
       if (ShootVFX != null)
         Instantiate(ShootVFX, attackPoint.position, Quaternion.identity);
     
        bulletsLeft--;
        bulletsShot++;

        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }
        if (bulletsShot < bulletsPerTap && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
        
    }

   
   
    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }
    
    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
        reloadAudioSource.Play();
    }
    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
