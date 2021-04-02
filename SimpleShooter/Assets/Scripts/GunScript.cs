using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Transform muzzlePosition; // position for the bullet to spawn.
    public ParticleSystem muzzleFlash; // particle system for the bullet fire.
    public GameObject bulletPrefab; // prefab of the bullet to be spawned.

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        muzzleFlash.Play();
        
        GameManager.Instance.totalShotsFired += GameManager.Instance.noOfBulletsInOneShot; // calculate total number of bullets fired.
        
        // to make the bullets deviate according to the no of bullets fired in one shot.
        float TotalSpread = GameManager.Instance.bulletSpreadAngle / GameManager.Instance.noOfBulletsInOneShot; 
        
        for (int i = 0; i < GameManager.Instance.noOfBulletsInOneShot; i++)
        {
            // Calculate angle of this bullet
            float spreadA = TotalSpread * (i + 1);
            float spreadB = GameManager.Instance.bulletSpreadAngle / 2.0f;
            float spread = spreadB - spreadA + TotalSpread / 2;
            float angle = Camera.main.transform.eulerAngles.y;
 
            // Create rotation of bullet
            Quaternion rotation = Quaternion.Euler(new Vector3(0, spread + angle, 0));
 
            // Create bullet
            Vector3 dir = transform.forward + new Vector3(Random.Range(-GameManager.Instance.bulletSpreadAngle,GameManager.Instance.bulletSpreadAngle), Random.Range(-GameManager.Instance.bulletSpreadAngle,GameManager.Instance.bulletSpreadAngle), 0);
            GameObject bullet = Instantiate(bulletPrefab, muzzlePosition.position, muzzlePosition.rotation);
            
            // move the bullet
            bullet.GetComponent<Rigidbody>().AddForce(dir * GameManager.Instance.bulletSpeed);
        }
    }
}
