using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput; // 1. Nueva entrada vertical
    public float speed = 10.0f;
    public float xRange = 10.0f;
    public float zRange = 10.0f; // 2. Nuevo rango para el eje Z
    public GameObject projectilePrefab;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical"); // Captura W/S o Flechas

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 spawnOffset = new Vector3(0, 1.0f, 1.0f);
            Vector3 spawnPosition = transform.position + spawnOffset;
            Instantiate(projectilePrefab, spawnPosition, projectilePrefab.transform.rotation);
        }
    }
}