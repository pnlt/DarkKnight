using UnityEngine;
using System.Collections.Generic;

public class setCheckPoint : MonoBehaviour
{
  [SerializeField] private Transform[] checkPoints;
    private List<double> distanceList = new List<double>();
  [SerializeField]  private Health playerHealth;

  private void Awake() {
    //playerHealth = new Health();
 } 


  private void Update() {
    if(playerHealth.getDie()){
      Instantiate(gameObject, CalDistance(transform, checkPoints).position, Quaternion.identity);
      //Debug.Log("PN nhu cc");
      playerHealth.setDie(false);
    }

    //Debug.Log(playerHealth.getDie());
    

  }
  private Transform CalDistance(Transform playerPosition, Transform[] checkPointsList) {
   Transform playerChecksPoint = checkPointsList[0]; 
   double distance = Vector3.Distance(playerPosition.position, checkPointsList[0].position);
   if (distanceList == null) {
    for(var i = 0; i < checkPointsList.Length; i++)
    {
     if(distance >= Vector3.Distance(playerPosition.position, checkPointsList[i].position)) {
      playerChecksPoint = checkPointsList[i];

     } 
    }

   }


return playerChecksPoint;
  }
}
