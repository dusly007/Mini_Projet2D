using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Asteroide : MonoBehaviour
{
    [SerializeField] private float vitesse = 4f;
    [SerializeField] private float rotation = 100f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = Vector2.down * vitesse;
        rb.MoveRotation(rb.rotation + rotation * Time.fixedDeltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}