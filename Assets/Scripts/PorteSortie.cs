using UnityEngine;

public class PorteSortie : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D autre)
    {
        // TODO : ignorer tout objet qui n'est pas le joueur.

        // TODO : annoncer la réussite et faire disparaître le joueur.
        if (!autre.CompareTag("Player")){
            return;
        }
        Destroy(autre.gameObject);
        Debug.Log("MISSION RÉUSSIE !");
    }

    /*
     * BANQUE DE LIGNES — GROUPE B
     * Replacez les lignes, puis ajoutez les accolades manquantes.
     *
     * if (!autre.CompareTag("Player"))
     * Debug.Log("MISSION RÉUSSIE !");
     * return;
     * Destroy(autre.gameObject);
     */
}
