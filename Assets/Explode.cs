using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    [HideInInspector]
    public Vector3 lastTouchPos;
    public LayerMask hitMask;
    public float forcePower;
    public Aiming aiming;
    public SphereCollider explode;
    public GameObject explodePrefab;
    bool shoted = false;
    public GameObject aimBox;
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
    void Start()
    {
        shoted = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

        //aimBox.transform.position = aiming.lastTouchPos;

        if(Input.GetMouseButtonUp(0))
        {
            if(shoted==false)
            {
                if (Physics.Raycast(ray, out hit, 60f, hitMask)) 
                {
                    Rigidbody rb = gameObject.GetComponent<Rigidbody>();
                    lastTouchPos = new Vector3(hit.point.x, 0.01f, hit.point.z);
                    rb.AddForce(lastTouchPos*forcePower*20,ForceMode.Force);

                    shoted = true;
                }
            }
        }
    }
}
