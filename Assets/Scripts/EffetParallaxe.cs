using UnityEngine;

public class EffetParallaxe : MonoBehaviour
{
    [Header("Caméra")]
    [SerializeField] private Transform cameraCible;

    [Header("Suivi de la caméra")]
    [SerializeField, Range(0f, 1f)] private float suiviHorizontal = 0.85f;
    [SerializeField, Range(0f, 1f)] private float suiviVertical = 0.90f;

    [Header("Déplacement automatique très lent")]
    [SerializeField] private Vector2 vitesseAutomatique = new(0.01f, 0f);

    private Vector3 positionInitiale;
    private Vector3 positionCameraInitiale;
    private Vector2 decalageAutomatique;

    private void Start()
    {
        // Mémoriser la position initiale de cette couche.
        positionInitiale = transform.position;

        // Trouver automatiquement la caméra si elle n'est pas assignée.
        if (cameraCible == null && Camera.main != null)
            cameraCible = Camera.main.transform;

        // Mémoriser la position initiale de la caméra.
        if (cameraCible != null)
            positionCameraInitiale = cameraCible.position;
    }

    private void LateUpdate()
    {
        // Arrêter la méthode si aucune caméra n'est disponible.
        if (cameraCible == null)
            return;

        // Calculer le déplacement de la caméra.
        Vector3 mouvementCamera = cameraCible.position - positionCameraInitiale;

        // Mettre à jour le déplacement automatique.
        decalageAutomatique += vitesseAutomatique * Time.deltaTime;

        // Calculer et appliquer la nouvelle position de la couche.
        transform.position = new Vector3(
            positionInitiale.x + mouvementCamera.x * suiviHorizontal + decalageAutomatique.x,
            positionInitiale.y + mouvementCamera.y * suiviVertical + decalageAutomatique.y,
            positionInitiale.z
        );
    }
}