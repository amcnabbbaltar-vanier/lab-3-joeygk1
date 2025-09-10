using UnityEngine;

public class GunComponent : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletMaxImpulse = 10.0f; // Max impulse when fully charged
    public float maxChargeTime = 3.0f;     // Max time allowed to charge

    private float chargeTime = 0.0f;       // How long the button has been held
    private bool isCharging = false;

    void Update()
    {
        // Start charging when fire button is pressed down
        if (Input.GetButtonDown("Fire1"))
        {
            chargeTime = 0.0f;
            isCharging = true;
        }

        // While holding the fire button, keep increasing chargeTime
        if (Input.GetButton("Fire1") && isCharging)
        {
            chargeTime += Time.deltaTime;
            chargeTime = Mathf.Clamp(chargeTime, 0, maxChargeTime);
        }

        // When fire button is released, shoot with calculated impulse
        if (Input.GetButtonUp("Fire1") && isCharging)
        {
            ShootBullet();
            isCharging = false;
        }
    }

    void ShootBullet()
{
    if (bulletPrefab == null)
    {
        Debug.LogError("Bullet prefab is not assigned!");
        return;
    }

    GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    
    Rigidbody rb = bullet.GetComponent<Rigidbody>();
    if (rb == null)
    {
        Debug.LogError("Bullet prefab is missing a Rigidbody component!");
        return;
    }

    float bulletImpulse = (chargeTime / maxChargeTime) * bulletMaxImpulse;
    rb.AddForce(bulletSpawnPoint.forward * bulletImpulse, ForceMode.Impulse);
}

}
