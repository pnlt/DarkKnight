using UnityEngine;
using System.Collections.Generic;

public class setCheckPoint : MonoBehaviour
{
  [SerializeField] private Transform[] checkPoints;
    private List<double> distanceList = new List<double>();
    private Health playerHealth;

  


  private void Update() {
    if(playerHealth.getDie()){
      transform.position = CalDistance(transform, checkPoints).position;

    }
    

  }
  private Transform CalDistance(Transform playerPosition, Transform[] checkPointsList) {
   Transform playerChecksPoint = checkPointsList[0]; 
   double distance = Vector3.Distance(playerPosition.position, checkPointsList[0].position);
   if (distanceList == null) {
    for(var i = 0; i < checkPointsList.Length; i++)
    {
     if(distance <= Vector3.Distance(playerPosition.position, checkPointsList[i].position)) {
      playerChecksPoint = checkPointsList[i];

     } 
    }

   }


return playerChecksPoint;
  }
}
