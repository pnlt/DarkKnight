using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header("Number of Life")]
    [SerializeField] private float numLife;
    [SerializeField] private GameObject enemy;
    [SerializeField] private AudioSource deathSoundEffect;
    // [SerializeField] private GameObject text;
    [SerializeField] private GameObject gameOverText;

    private Animator animator;
    // private Button button;
    private Rigidbody2D rb;
    public bool isDie = false;
    // private GameOver gameOverScript;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        // gameOverScript = FindObjectOfType<GameOver>();

        

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
            GetComponent<CapsuleCollider2D>().enabled = false;
            
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
        // gameOverScript.ShowGameOver();


    }
    public bool getDie() {
      return isDie;
    }

    public void setDie(bool isDead) {
       isDie = isDead;
    }
    public void RestartLevel()
    {
        isDie = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    



    // public void setGameOver() {
    //     text.SetActive(true);
    // }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Weapon")
        {
            numLife -= FindObjectOfType<EnemyAttack>().getDamage();
            animator.SetTrigger("hurt");

        }
        if (collision.tag == "deadzone") {
            RestartLevel();
        }
    } 

    private IEnumerator Death()
    {
        animator.SetTrigger("die");
        yield return new WaitForSeconds(1);
        gameOverText.SetActive(true);
        // Destroy(gameObject);
    } 
}
