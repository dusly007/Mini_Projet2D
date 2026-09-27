using UnityEngine;
using UnityEngine.SceneManagement;

public class PortailNiveauSuivant : MonoBehaviour
{
    [SerializeField] private string nomScene = "Niveau2";

    private void OnTriggerEnter2D(Collider2D autre)
    {
        if (!autre.CompareTag("Player"))
            return;

        // Empêche l'accès si les batteries ne sont pas toutes collectées
        if (!GestionJeu.Instance.ObjectifAtteint)
            return;

        SceneManager.LoadScene(nomScene);
    }
}