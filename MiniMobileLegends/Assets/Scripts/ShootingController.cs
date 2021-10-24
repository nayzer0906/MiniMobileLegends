using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject bullet;
    
    [HideInInspector] public bool canShoot;
    
    [SerializeField] private float cooldown = 5;
    [SerializeField] private float bulletSpeed = 2;
    [SerializeField] private Transform bulletSpawnPos;
    
    private float cooldownTimer;

    private void Update()
    {
        if (canShoot)
            Shoot();
    }

    private void Shoot()
    {
        cooldownTimer -= Time.deltaTime;

        if(cooldownTimer > 0) 
            return;

        cooldownTimer = cooldown;
     
        GameObject currentBullet = Instantiate(bullet, bulletSpawnPos.position, bulletSpawnPos.rotation, transform);
        Rigidbody bulletRigidbody = currentBullet.GetComponent<Rigidbody>();
        bulletRigidbody.AddForce(bulletRigidbody.transform.forward * bulletSpeed);
    }
}
