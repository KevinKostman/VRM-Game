using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject bulletPrefab;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }   
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, Camera.main.transform.position, Camera.main.transform.rotation);
        bullet.transform.position += Camera.main.transform.forward * 1f; // Adjust bullet position to be in front of the camera
        bullet.transform.forward = Camera.main.transform.forward; // Set bullet direction to camera forward
        // send the bullet forward
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(Camera.main.transform.forward * 1000f); // Adjust the force as needed
        bulletRb.AddForce(Vector3.up * 100f); // Add some upward force to the bullet
        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2f);
        // Check for hit
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            if (hit.collider.tag == "Enemy")
            {
                Debug.Log("Hit: " + hit.collider.name);
                // Add your shooting logic here (e.g., apply damage to the hit object)
            } else{
            Debug.Log("Miss: " + hit.collider.name);
            }
        }
    }
}
