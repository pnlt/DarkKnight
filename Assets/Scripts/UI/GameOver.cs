using UnityEngine;

public class GameOver : MonoBehaviour
{
    // [SerializeField] private GameObject text;
 
    [SerializeField] private Health playerHealth;
    // private bool dieStatus;
    // private void Start() {
        
    // }

    // private void Update() {
    //     dieStatus = playerHealth.getDie();
    //     if (dieStatus) {
    //         text.SetActive(true);
    //     }
        
    // }
    //    public void ShowGameOver(){
    //     text.SetActive(true);
    //    }
    public void RestartLevel()
{
  playerHealth.RestartLevel();
}


}
