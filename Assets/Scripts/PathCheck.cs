﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCheck : MonoBehaviour
{
    [HideInInspector] public List<Collider> enemyList = new List<Collider>();
    void Update()
    {
        for(var i = enemyList.Count - 1; i > -1; i--)
        {
            if (enemyList[i] == null)
            enemyList.RemoveAt(i);
        }
    }
    public void OnTriggerEnter(Collider enemy)
    {
        Collider enemyCol = enemy.GetComponent<Collider>();
        if(enemy.gameObject.tag == "Enemy")
        {
            if(!enemyList.Contains(enemy))
            {
                enemyList.Add(enemyCol);
            }
        }
    }
    public void OnTriggerExit(Collider enemy)
    {
        Collider enemyCol = enemy.GetComponent<Collider>();
        if(enemy.gameObject.tag == "Enemy")
        {
            if(enemyList.Contains(enemy))
            {
                enemyList.Remove(enemyCol);
            }
        }
    }
    
}
