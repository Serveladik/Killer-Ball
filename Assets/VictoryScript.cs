using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScript : MonoBehaviour
{
    public PathCheck pathChecker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pathChecker.enemyList.Count==0)
        {
            Win();
        }
    }
    void Win()
    {
        Debug.Log("Win");
    }
    void Lose()
    {

    }
}
