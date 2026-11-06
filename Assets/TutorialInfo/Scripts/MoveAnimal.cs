using UnityEngine;

public class MoveAnimal : MonoBehaviour
{
    public float speed = 10.0f; // Velocidad base

    void Start()
    {
        speed = Random.Range(5.0f, 15.0f);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}