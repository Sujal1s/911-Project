using UnityEngine;

namespace Game_Script
{
    public class Fligh11Path : MonoBehaviour
    {
        public GameObject bulletPrefab;       // Bullet prefab to instantiate
        public Transform bulletSpawnPoint;    // The point on the player's gun where the bullet will be fired from
        [SerializeField] float bulletSpeed = 10f;

        void Update()
        {
            UserInput();
            CheckIfOutOfScreen();
        }

        void UserInput()
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
            if (bulletPrefab == null || bulletSpawnPoint == null)
            {
                Debug.LogError("Bullet prefab or spawn point is not assigned.");
                return;
            }

            GameObject bulletInstance = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            if (bulletInstance == null)
            {
                Debug.LogError("Failed to instantiate bullet.");
                return;
            }

            Rigidbody2D bulletRb = bulletInstance.GetComponent<Rigidbody2D>();
            if (bulletRb != null)
            {
                // Apply velocity to the bullet to make it move in the direction the gun is facing
                bulletRb.velocity = bulletSpawnPoint.up * bulletSpeed;
            }
            else
            {
                Debug.LogError("Rigidbody2D component is missing on the bullet prefab.");
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("on trigger called");
            if (collision.gameObject.CompareTag("Tower"))  // Check if the collided object has the "Tower" tag
            {
                Debug.Log("Enemy dead");
                Destroy(collision.gameObject);   // Destroy the enemy
                Destroy(gameObject);             // Destroy the bullet (instantiated bullet object)
            }
        }

        void CheckIfOutOfScreen()
        {
            if (Camera.main != null)
            {
                Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
                bool isOutOfScreen = screenPoint.x < 0 || screenPoint.x > 1 || screenPoint.y < 0 || screenPoint.y > 1;

                if (isOutOfScreen)
                {
                    Destroy(gameObject);  // Destroy the object when it goes out of the screen
                }
            }
        }
    }
}