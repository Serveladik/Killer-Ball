using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMechanic : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform ballSpawn;
    public float scaleTime = 10f;
    public Vector3 minScale = new Vector3();
    private GameObject ballClone;
    public LineRenderer shootLine;
    public float forcePower;
    
    //public float minScaleSize;
    
    void Start()
    {
        shootLine.enabled = false;
    }
    void Update()
    {
        Shoot();

    }

    void Shoot()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(transform.localScale.magnitude>=minScale.magnitude)
            {
                ballClone = Instantiate(ballPrefab,ballSpawn.transform.position,Quaternion.identity) as GameObject;
            }
        }
        if(Input.GetMouseButton(0))
        {
            if(transform.localScale.magnitude>minScale.magnitude)
            {
                shootLine.enabled = true;
                transform.localScale-=Vector3.one * scaleTime/40 * Time.deltaTime;
                ballClone.transform.localScale+=Vector3.one * scaleTime/40 * Time.deltaTime;

                shootLine.startWidth = ballClone.transform.localScale.magnitude/1.5f;
                shootLine.endWidth = ballClone.transform.localScale.magnitude/1.5f;
            }
            
        }
        if(Input.GetMouseButtonUp(0))
        {
            shootLine.enabled = false;
            Rigidbody rb = ballClone.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.left*forcePower*40,ForceMode.Acceleration);
            return;
        }

    }



}
