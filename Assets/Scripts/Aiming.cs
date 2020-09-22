using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    [HideInInspector] private Vector3 lastTouchPos;
    //public Vector3 aimSpot;
    public LineRenderer shootLine;
    public LayerMask hitMask;
    
    

    // Update is called once per frame
    void Update()
    {
        Aim();
    }
    void Aim()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 60f, hitMask)) 
        {
            //aimSpot = new Vector3(hit.point.x, hit.point.y, hit.point.z);
			lastTouchPos = new Vector3(hit.point.x, 0.01f, hit.point.z);
			shootLine.SetPosition(1, lastTouchPos);
        }
    }
}
