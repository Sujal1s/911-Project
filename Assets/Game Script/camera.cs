using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 5f;
    

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        
    }
}