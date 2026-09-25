using UnityEngine;
 
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class MouvementRobot : MonoBehaviour
{
    [SerializeField] private float vitesse = 5f;
 
    private Rigidbody2D corps;
    private Vector2 direction;
    private Animator animator;
 
    private void Awake()
    {
        corps = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
 
    private void Update()
    {
        // reconstruire la lecture des commandes et la direction normalisée.

        if (!commandesActives)
        {
            animator.SetInteger("DirectionAnim", 0);
            return;
        }
 
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
 
 
        direction = new Vector2(horizontal, vertical).normalized;

          if (horizontal > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (horizontal < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        if (direction.sqrMagnitude < 0.01f)
        {
            // À l'arrêt (Idle)
            animator.SetInteger("DirectionAnim", 0);
        }
        else
        {
            // On regarde quelle direction est la plus forte (verticale ou horizontale)
            if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x))
            {
                if (direction.y > 0)
                {
                    animator.SetInteger("DirectionAnim", 2); // Vers le HAUT
                }
                else
                {
                    animator.SetInteger("DirectionAnim", 3); // Vers le BAS
                }
            }
            else
            {
                animator.SetInteger("DirectionAnim", 1); // Vers la GAUCHE / DROITE
            }
        }
       
    }
 
    private void FixedUpdate()
    {
        // déplacer le robot en tenant compte du temps physique.
 
        corps.MovePosition(corps.position + direction * vitesse * Time.fixedDeltaTime);
 
    }

    private bool commandesActives = true;

    public void DesactiverCommandes()
    {
        commandesActives = false;
        direction = Vector2.zero;
        corps.linearVelocity = Vector2.zero;
    }

    public void ActiverCommandes()
    {
        commandesActives = true;
    }
    
    /*
     * BANQUE DE LIGNES — GROUPE B
     * Les lignes ne sont pas dans le bon ordre.
     *
     *
     *
     *
     *
     */
}
 