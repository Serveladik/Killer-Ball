using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemiesOnce : MonoBehaviour
{
    public SphereCollider collider;
    
   public void OnTriggerStay(Collider enemy)
   {
       if(enemy.gameObject.tag =="Enemy")
       {
           Destroy(enemy.gameObject);
       }
   }
}
