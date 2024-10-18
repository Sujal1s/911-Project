using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class collison : MonoBehaviour
{
    public Text scoreText;
    private static int score = 0;  // Use static to retain score across instances

    void Start()
    {
        UpdateScoreText();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        if (gameObject.CompareTag("Plane") && collision.gameObject.CompareTag("Tower"))  // Check if the collided object has the "Tower" tag
        {
            Debug.Log("Tower destroyed");
            score += 5;
            UpdateScoreText();
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}