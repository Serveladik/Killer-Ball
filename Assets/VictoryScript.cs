using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScript : MonoBehaviour
{
    public PathCheck pathChecker;
    public GameObject ballHP;
    public BallMechanic ballMinScale;
    public LineRenderer shootLine;

    public Animator winLoseAnim;
    public Animator ballAnim;
    //public Animator loseAnim;

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
        StartCoroutine("timeOut");
    }
    IEnumerator timeOut()
    {
        if(pathChecker.enemyList.Count>=1 && ballHP.transform.localScale.x<=0.15f)
        {
            if(shootLine.enabled==false)
            {
                yield return new WaitForSecondsRealtime(3f);
                if(pathChecker.enemyList.Count>=1 && ballHP.transform.localScale.x<=0.15f)
                {
                    Lose();
                }
            }
        }
    }
    void Win()
    {
        winLoseAnim.SetBool("Win",true);
        ballAnim.SetBool("WinBall",true);
    }
    void Lose()
    {
        winLoseAnim.SetBool("Lost",true);
    }
}
