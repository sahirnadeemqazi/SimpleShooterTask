using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Bullet Control Slider References")]
    public Slider bulletCountSlider; // slider for total number of bullets fired in a single shot.
    public Slider bulletSpeedSlider; // slider to control the speed of the bullet.
    public Slider bulletAngleSlider; // slider to control the deviation angle of the bullet.

    [Header("Bullet Control Toggle References")]
    public Toggle explosionBulletToggle; // checkbox to enable the exploding bullet behaviour;
    public Toggle bigBulletToggle; // checkbox to enable the big bullet behaviour.
    public Toggle redBulletToggle; // checkbox to enable the red bullet behaviour.

    public void OnBulletExplosionValueChanged()
    {
        GameManager.Instance.explosiveBullet = explosionBulletToggle.isOn;
    }

    public void OnBigBulletValueChanged()
    {
        GameManager.Instance.bigBullet = bigBulletToggle.isOn;
    }

    public void OnRedBulletValueChanged()
    {
        GameManager.Instance.redBullet = redBulletToggle.isOn;
    }

    public void BulletCountSliderValueChange()
    {
        GameManager.Instance.noOfBulletsInOneShot = Mathf.FloorToInt(bulletCountSlider.value);
    }

    public void BulletSpeedSliderValueChange()
    {
        GameManager.Instance.bulletSpeed = Mathf.FloorToInt(bulletSpeedSlider.value);
    }

    public void BulletAngleSliderValueChange()
    {
        GameManager.Instance.bulletSpreadAngle = bulletAngleSlider.value;
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }

    public void BackToHomeButton()
    {
        GameManager.Instance.totalShotsFired = 0;
        SceneManager.LoadScene(0);
    }


}

