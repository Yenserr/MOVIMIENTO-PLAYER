using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            AnimalHunger hungerScript = other.GetComponent<AnimalHunger>();
            
            if (hungerScript != null)
            {
                hungerScript.FeedAnimal(1, transform.position); // Pasa posición para el empujón
                Destroy(gameObject); // Destruye la comida
            }
            else
            {
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
        }
        else if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddLives(-1);
            Destroy(gameObject); // Destruye el animal
        }
    }
}