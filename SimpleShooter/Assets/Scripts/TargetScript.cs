using TMPro;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public TextMeshPro text; // text to display the number of bullets hitting the target.
    private int bulletCounter; // variable to store the number of bullets hitting the target.
    void Update()
    {
        text.text = bulletCounter + "/" + GameManager.Instance.totalShotsFired;
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            // increment when a bullet hits.
            bulletCounter++;
        }
    }
}
