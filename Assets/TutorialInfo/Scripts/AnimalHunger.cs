using UnityEngine;
using UnityEngine.UI;

public class AnimalHunger : MonoBehaviour
{
    [Header("Hunger UI")]
    public Slider hungerSlider;

    // Offset para que la barra flote sobre la cabeza del animal
    public Vector3 sliderOffset = new Vector3(0, 2f, 0);

    [Header("Feeding")]
    public int amountToBeFed = 3;

    // Fuerza del empujón hacia atrás al recibir comida
    public float knockbackForce = 5f;

    private int currentFedAmount = 0;
    private Rigidbody rb;
    private Canvas sliderCanvas;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (hungerSlider != null)
        {
            hungerSlider.maxValue = amountToBeFed;
            hungerSlider.value = 0;

            // Obtener el Canvas padre del slider
            sliderCanvas = hungerSlider.GetComponentInParent<Canvas>();

            // Ocultar la barra al inicio (el animal aún no ha sido alimentado)
            if (sliderCanvas != null)
                sliderCanvas.gameObject.SetActive(false);
            else
                hungerSlider.gameObject.SetActive(false);
        }
    }

    void LateUpdate()
    {
        // Mantener la barra sobre la cabeza del animal, mirando a la cámara
        if (hungerSlider != null && hungerSlider.gameObject.activeInHierarchy)
        {
            Transform uiTransform = sliderCanvas != null
                ? sliderCanvas.transform
                : hungerSlider.transform;

            uiTransform.position = transform.position + sliderOffset;

            if (Camera.main != null)
                uiTransform.rotation = Quaternion.LookRotation(
                    uiTransform.position - Camera.main.transform.position
                );
        }
    }

    /// <summary>
    /// Llamado por DetectCollisions cuando la comida toca al animal.
    /// </summary>
    /// <param name="amount">Cuánta hambre se satisface.</param>
    /// <param name="foodPosition">Posición de la comida, para calcular la dirección del empujón.</param>
    public void FeedAnimal(int amount, Vector3 foodPosition)
    {
        currentFedAmount += amount;

        // Mostrar la barra en cuanto recibe su primera comida
        if (hungerSlider != null)
        {
            if (sliderCanvas != null)
                sliderCanvas.gameObject.SetActive(true);
            else
                hungerSlider.gameObject.SetActive(true);

            hungerSlider.value = currentFedAmount;
        }

        // Empujón: dirección contraria a la comida (que viene del jugador)
        ApplyKnockback(foodPosition);

        if (currentFedAmount >= amountToBeFed)
        {
            Destroy(gameObject, 0.1f);
        }
    }

    private void ApplyKnockback(Vector3 originPosition)
    {
        if (rb == null) return;

        // Dirección desde la comida/jugador hacia el animal
        Vector3 direction = (transform.position - originPosition).normalized;

        // Ignorar componente vertical para que no vuele
        direction.y = 0;

        rb.AddForce(direction * knockbackForce, ForceMode.Impulse);
    }
}
