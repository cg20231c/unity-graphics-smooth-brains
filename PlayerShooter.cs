using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float shootCooldown = 0.5f;  // Cooldown time in seconds
    private bool canShoot = true;  // Initially, the player can shoot

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && canShoot){
            Shoot();
        }
    }

    void Shoot() {
        // Create a new bullet instance.
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Get the rigidbody component of the bullet and set its velocity to move it forward.
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = firePoint.forward * bulletSpeed;

        // Destroy the bullet after a certain time (e.g., 2 seconds).
        Destroy(bullet, 2.0f);

        // Set canShoot to false to start the cooldown
        canShoot = false;
        StartCoroutine(ShootingCooldown());
    }

    IEnumerator ShootingCooldown(){
        // Wait for the specified cooldown time
        yield return new WaitForSeconds(shootCooldown);

        // Allow shooting again
        canShoot = true;
    }
}
