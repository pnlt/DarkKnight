using UnityEngine;

public class knightAttack : MonoBehaviour
{
    [Header("player attack's parameters")]
    [SerializeField] private float attackCoolDown;
    [SerializeField] private GameObject enemy;

    [Header("Attack area")]
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private BoxCollider2D boxCollider;

    private Animator animator;
   

    private float attackTimer;

    private void Awake()
    {
        animator = GetComponent<Animator>(); 
        boxCollider = GetComponent<BoxCollider2D>();

        if (enemy != null)
            enemy = (GameObject) FindObjectOfType(typeof(GameObject));
    }


    private void Update()
    {
       attackTimer += Time.deltaTime;
       attack();      
    }

    private void attack()
    {
        if (attackTimer >= attackCoolDown && Input.GetKeyDown(KeyCode.J))
        {
             animator.SetTrigger("killEnemy");
        }
    }

    private bool isAttackArea()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * Mathf.Sign(transform.localScale.x) * colliderDistance, 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, .1f, enemyMask);

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * colliderDistance * Mathf.Sign(transform.localScale.x), 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
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
