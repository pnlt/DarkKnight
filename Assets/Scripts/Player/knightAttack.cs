using UnityEngine;
using UnityEngine.UI;

public class knightAttack : MonoBehaviour
{
    [Header("player attack's parameters")]
    [SerializeField] private float attackCoolDown;
    [SerializeField] private GameObject enemy;

    [Header("Attack area")]
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private CapsuleCollider2D capsuleCollider;
    [SerializeField] private Button Attack;
    [SerializeField] private LayerMask UILayer;

    private Animator animator;
   

    private float attackTimer;

    private void Awake()
    {
        animator = GetComponent<Animator>(); 
        capsuleCollider = GetComponent<CapsuleCollider2D>();

        if (enemy != null)
            enemy = (GameObject) FindObjectOfType(typeof(GameObject));
    }


    private void Update()
    {
       attackTimer += Time.deltaTime;
       SetUpAttack();  
    }

    private void SetUpAttack()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                Vector2 position = Camera.main.ScreenToWorldPoint(touch.position);
                RaycastHit2D[] hits = Physics2D.RaycastAll(position, Vector2.right * .05f, .1f, UILayer);

                foreach (var coll in hits)
                {
                    if (coll.collider.name == Attack.name && attackTimer >= attackCoolDown && touch.phase == TouchPhase.Began)
                    {
                        attackTimer = 0;
                        animator.SetTrigger("killEnemy");
                    }
                }
                
            }
        }
    }


    private bool isAttackArea()
    {
        RaycastHit2D hit = Physics2D.BoxCast(capsuleCollider.bounds.center + transform.right * range * Mathf.Sign(transform.localScale.x) * colliderDistance, 
            new Vector3(capsuleCollider.bounds.size.x * range, capsuleCollider.bounds.size.y, capsuleCollider.bounds.size.z), 0, Vector2.left, .1f, enemyMask);

        return hit.collider != null;
    }

   

    private void kill()
    {
        if (isAttackArea())
        {
            if (FindObjectOfType<DeathOfEnemy>() != null)
            FindObjectOfType<DeathOfEnemy>().death();
        }
    }
}
