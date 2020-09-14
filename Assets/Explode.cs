using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public SphereCollider explode;
    public GameObject explodePrefab;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider enemy)
    {
       if(enemy.gameObject.tag =="Enemy")
       {
            explodePrefab = Instantiate(explodePrefab, transform.position, Quaternion.identity, null);
            explodePrefab.transform.localScale = transform.localScale;
           //explode.enabled=true;
           //explodePrefab.SetActive(false);
           Destroy(this.gameObject);
       }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
