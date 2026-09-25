using UnityEngine;

public class PortailSortie : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D autre)
    {
        if (!autre.CompareTag("Player"))
            return;

        GestionJeu.Instance.DeclencherVictoire();
    }
}