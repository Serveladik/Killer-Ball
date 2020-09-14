using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemiesOnce : MonoBehaviour
{
    public SphereCollider collider;
    
    // Start is called before the first frame update
   public void OnTriggerStay(Collider enemy)
   {
       if(enemy.gameObject.tag =="Enemy")
       {
           Destroy(enemy.gameObject);
           //gameObject.SetActive(false);
       }
   }
}
