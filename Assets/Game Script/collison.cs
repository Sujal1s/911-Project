using Unity.VisualScripting;
using UnityEngine;

public class PlaneCollision : MonoBehaviour
    
{
    public GameObject Plane;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.gameObject)
        {
            Destroy(collision.gameObject); // Destroy the tower
            
        }
    }
}