using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletPrefab;       // Bullet prefab to instantiate
    public Transform bulletSpawnPoint;    // The point on the player's gun where the bullet will be fired from
    [SerializeField] float bulletSpeed = 10f;

    void Update()
    {
        userInput();
        
        if (transform.position.y>5f  )
        {
            Destroy(this.gameObject);
        }
    }

    void userInput()
    {
        bool mouseClick = Input.GetMouseButtonDown(0);
        if (mouseClick)  // Left mouse button clicked
        {
            Debug.Log("Mouse Clicked");
            FireBullet();
        }
    }   

    void FireBullet()
    {
        GameObject bulletInstance = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        Rigidbody2D bulletRb = bulletInstance.GetComponent<Rigidbody2D>();

        // Apply velocity to the bullet to make it move in the direction the gun is facing
        bulletRb.velocity = bulletSpawnPoint.up * bulletSpeed;

       

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("on trigger called");
        if (collision.gameObject.Equals("Enemy"))  // Check if the collided object has the "Enemy" tag
        {
            Debug.Log("Enemy dead");
            Destroy(collision.gameObject);   // Destroy the enemy
            Destroy(gameObject);             // Destroy the bullet (instantiated bullet object)
        }
    }
}