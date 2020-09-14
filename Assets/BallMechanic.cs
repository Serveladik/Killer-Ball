using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMechanic : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform ballSpawn;
    public float scaleTime = 10f;
    public Vector3 minScale = new Vector3();
    public GameObject ballClone;
    //public float minScaleSize;
    

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
                transform.localScale-=Vector3.one * scaleTime/40 * Time.deltaTime;
                ballClone.transform.localScale+=Vector3.one * scaleTime/40 * Time.deltaTime;
            }
            else
            {
                return;
            }
        }

    }



}
