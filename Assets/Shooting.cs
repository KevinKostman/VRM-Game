using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectile;
    public Transform weaponPos; 
    [SerializeField] private float cooldownTime = 0.8f;
    private bool canShoot = true;
    private bool isFlashing = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // Pobieranie kierunku strzału - możesz dostosować to do jakiegoś swojego skryptu obracania kamerą
        Vector3 shootDirection = Camera.main.transform.forward;
        Quaternion shootRotation = Quaternion.LookRotation(shootDirection);

        if (projectile != null && weaponPos != null)
        {
            GameObject bullet = Instantiate(projectile, weaponPos.position, shootRotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = shootDirection * 30f; 
            }
        }
    }

    IEnumerator CooldownTimer()
    {
        canShoot = false;
        yield return new WaitForSeconds(cooldownTime);
        canShoot = true;
    }
    
}