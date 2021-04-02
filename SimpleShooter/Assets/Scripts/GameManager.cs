using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header("Bullet Controls")]
    public float bulletSpeed = 2500f; // default speed of the bullet.
    [Range(5f,30f)]
    public int noOfBulletsInOneShot = 10; // range defined for the total number of bullets fired in a single shot.
    public float bulletSpreadAngle = 0.01f; // default deviation angle of the bullet.

    public int totalShotsFired; // variable to store the total number of bullets fired.
    
    [Header("General Controls")]
    public bool explosiveBullet; // explosive bullet behaviour controller.
    public bool bigBullet; // big bullet behaviour controller.
    public bool redBullet; // red bullet behaviour controller.

    

    private void Awake()
    {
        // to make it singleton
        if(Instance != null)
            Destroy(this.gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        // to make the mouse cursor visible to access the settings from the left.
        Cursor.visible = true;
    }
}
