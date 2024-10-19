using UnityEngine;

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
                Debug.Log("Tower hit the bottom edge of the screen. Pausing game.");
                Time.timeScale = 0;  // Pause the game
            }
        }
    }
}