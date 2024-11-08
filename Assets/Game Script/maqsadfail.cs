using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseOnTowerHit : MonoBehaviour
{
    void Update()
    {
        CheckIfTowerHitsBottomEdge();
    }

    void CheckIfTowerHitsBottomEdge()
    {
        if (Camera.main != null)
        {
            Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
            if (screenPoint.y < 0)
            {
                Debug.Log("Tower hit the bottom edge of the screen. Redirecting to UI scene.");
                SceneManager.LoadScene("Pause menu");  // Replace "UIScene" with the name of your UI scene
            }
        }
    }
}