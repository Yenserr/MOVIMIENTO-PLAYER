using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;

    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound) 
        {
            if (gameObject.CompareTag("Animal"))
            {
                GameManager.Instance.AddLives(-1);
            }
            
            Destroy(gameObject);
        }
    }
}