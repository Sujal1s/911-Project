using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pausemenu : MonoBehaviour
{
    public Button restartButton;

    void Start()
    {
        restartButton.onClick.AddListener(OnRestartButtonClick);
    }

    public void OnRestartButtonClick()
    {
        Debug.Log("Restart button clicked. Redirecting to game scene.");
        SceneManager.LoadScene("game");  // Replace "game" with the name of your game scene
    }
}