using UnityEngine;

public class RotationObjet : MonoBehaviour
{
    [SerializeField] private float vitesseRotation = 180f; // Degrés par seconde

    private void Update()
    {
        // Fait tourner l'objet sur l'axe Z (idéal pour la 2D)
        transform.Rotate(0f, 0f, vitesseRotation * Time.deltaTime);
    }
}