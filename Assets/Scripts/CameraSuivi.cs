using UnityEngine;

public class CameraSuivi : MonoBehaviour
{
    [SerializeField] private Transform cible;

    [SerializeField] private float lissage = 5f;

    [SerializeField] private Vector3 decalage = new Vector3(0, 0, -10);

    private void LateUpdate()
    {
        if (cible == null) return;

        Vector3 positionVoulue = cible.position + decalage;

        transform.position = Vector3.Lerp(
            transform.position,
            positionVoulue,
            lissage * Time.deltaTime
        );
    }
}