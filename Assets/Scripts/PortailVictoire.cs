using UnityEngine;

public class PortailVictoire : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D autre)
    {
        if (!autre.CompareTag("Player"))
            return;

        if (!GestionJeu.Instance.ObjectifAtteint)
            return;

        GestionJeu.Instance.DeclencherVictoire();
    }
}