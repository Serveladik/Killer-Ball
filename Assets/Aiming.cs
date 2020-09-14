using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    private Vector3 lastTouchPos;
    public LineRenderer shootLine;
    public LayerMask hitMask;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        Aim();
    }
    void Aim()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 50f, hitMask)) 
        {
			lastTouchPos = new Vector3(hit.point.x, 0.01f, hit.point.z);
			shootLine.SetPosition(1, lastTouchPos);
        }
    }
}
