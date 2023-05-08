using UnityEngine;

public class FallDamage : MonoBehaviour
{
    private Health playerHealth;
    private SafeGroundSaver safeGroundSaver; 

    private void Start()
    {
        safeGroundSaver = GameObject.FindGameObjectWithTag("Player").GetComponent<SafeGroundSaver>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player"))
        {
if ( playerHealth.getDie()) {
  
            safeGroundSaver.WarpPlayerToSafeGround();
}

            

        }
        
    }

}
