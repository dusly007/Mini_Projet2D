using UnityEngine;

public class CollecteBatterie : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D autre)
    {
        if (!autre.CompareTag("Player"))
            return;

        GestionJeu.Instance.AjouterBatterie();

        Destroy(gameObject);
    }
}