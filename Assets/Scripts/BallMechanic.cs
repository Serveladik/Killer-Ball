using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMechanic : MonoBehaviour
{
    [HideInInspector] public Vector3 lastTouchPos;
    [HideInInspector] public bool end = false;
    private GameObject ballClone;
    public LayerMask hitMask;
    public GameObject ballPrefab;
    public Transform ballSpawn;
    public float scaleTime = 10f;
    public Vector3 minScale = new Vector3();
    public LineRenderer shootLine;
    public LineRenderer pathLine;
    public BoxCollider pathLineCollider;
    public float forcePower;
    public Aiming aiming;
    public GameObject aimBox;
    
    
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
            if(!end)
            {
                if(transform.localScale.magnitude>=minScale.magnitude)
                {
                    ballClone = Instantiate(ballPrefab,ballSpawn.transform.position,Quaternion.identity) as GameObject;
                }
            }
        }
        if(Input.GetMouseButton(0))
        {
            if(transform.localScale.magnitude>minScale.magnitude)
            {
                if(!end)
                {
                    shootLine.enabled = true;
                    transform.localScale-=Vector3.one * scaleTime/40 * Time.deltaTime;
                    ballClone.transform.localScale+=Vector3.one * scaleTime/40 * Time.deltaTime;
        
                    shootLine.startWidth = ballClone.transform.localScale.magnitude/1.75f;
                    shootLine.endWidth = ballClone.transform.localScale.magnitude/1.75f;
    
                    pathLine.startWidth = transform.localScale.magnitude/1.75f;
                    pathLine.endWidth = transform.localScale.magnitude/1.75f;
    
                    pathLineCollider.size = new Vector3(pathLineCollider.size.x,transform.localScale.magnitude/1.75f,pathLineCollider.size.z);
                }
            }  
        }
        if(Input.GetMouseButtonUp(0))
        {
            shootLine.enabled = false;
            return;
        }
    }
}
