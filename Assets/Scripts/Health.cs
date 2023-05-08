using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header("Number of Life")]
    [SerializeField] private float numLife;
    [SerializeField] private GameObject enemy;
    [SerializeField] private AudioSource deathSoundEffect;

    private Animator animator;
    private Rigidbody2D rb;
    public bool isDie;

    private void Awake()
    {
      isDie = false;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        

        if (enemy != null)
            enemy = (GameObject)FindObjectOfType(typeof(GameObject));
       
    }

    private void Update()
    {
        if (numLife == 0)
        {
            StartCoroutine(Death());

            if (enemy.GetComponentInChildren<EnemyAttack>() != null)
            enemy.GetComponentInChildren<EnemyAttack>().enabled = false;


            GetComponent<playerMovement>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<BoxCollider2D>().enabled = false;
            
        }
    } 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
      isDie = true;
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        StartCoroutine(Death());

    }
    public bool getDie() {
      return isDie ;
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isDie = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Weapon")
        {
            numLife -= FindObjectOfType<EnemyAttack>().getDamage();
            animator.SetTrigger("hurt");

        }
    } 

    private IEnumerator Death()
    {
        animator.SetTrigger("die");
        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    } 
}
