using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject bulletImpact; // particle system for the bullet impact.
    public GameObject bulletImpactBigBullet; // particle system for big bullet impact.
    public GameObject explosionParticle; // particle system for bullet explosion.
    public Material redBullet; // material to make the bullet red.

    public void Start()
    {
        Destroy(this.gameObject,3); // to free up memory if the bullet doesnt hit anywhere.
        
        // to make red bullet behaviour.
        if (GameManager.Instance.redBullet)
            GetComponent<MeshRenderer>().material = redBullet;
        
        // to make the exploding bullet behaviour.
        if(GameManager.Instance.explosiveBullet)
            Invoke("ExplodeBullet",1f);
        
        // to make the big bullet behaviour.
        if(GameManager.Instance.bigBullet)
            this.transform.localScale = new Vector3(0.2f,0.2f,0.2f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            if(GameManager.Instance.bigBullet)
            {
                Destroy(Instantiate(bulletImpactBigBullet, transform.position, Quaternion.identity), 2f); // spawn the big bullet particle system.
            }
            else
            {
                Destroy(Instantiate(bulletImpact, transform.position, Quaternion.identity), 2f); // spawn the normal bullet particle system.
            }
        }

        if(!other.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.gameObject); // to make the bullet destroy on collision but not when colliding with eachother.
        }
    }

    private void ExplodeBullet()
    {
        Destroy((Instantiate(explosionParticle,this.transform.position,Quaternion.identity)),1); // spawn the bullet explosion particle system.
        Destroy(this.gameObject);
    }
}
