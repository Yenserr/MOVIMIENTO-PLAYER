using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 

    public int lives = 3;
    public int score = 0;

    void Awake()
    {
        Instance = this; 
        Debug.Log("Vidas: " + lives + " | Puntuación: " + score);
    }

    public void AddScore(int value)
    {
        score += value;
        Debug.Log("Score = " + score);
    }

    public void AddLives(int value)
    {
        lives += value;
        Debug.Log("Lives = " + lives);

        if (lives <= 0)
        {
            Debug.Log("Game Over");
            Time.timeScale = 0;
        }
    }
}