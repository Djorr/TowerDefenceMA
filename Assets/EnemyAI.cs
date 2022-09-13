using System;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
   public float enemySpeed = 10f;

   private Transform target;
   private int wavePointIndex = 0;

   void Start()
   {
      target = Waypoints.wayPoints[0];
   }

   void Update()
   {
      Vector3 direction = target.position - transform.position;
      transform.Translate(direction.normalized * enemySpeed * Time.deltaTime, Space.World);

      if (Vector3.Distance(transform.position, target.position) <= 0.2f)
      {
         GetNextWaypoint();
      }
   }

   void GetNextWaypoint()
   {
      if (wavePointIndex >= Waypoints.wayPoints.Length - 1)
      {
         Destroy(gameObject);
         return;
      }
         
      wavePointIndex++;
      target = Waypoints.wayPoints[wavePointIndex];
   }
}
