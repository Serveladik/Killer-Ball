using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScript : MonoBehaviour
{
    public BallMechanic ballEnd;
    public PathCheck pathChecker;
    public GameObject ballHP;
    public BallMechanic ballMinScale;
    public LineRenderer shootLine;

    public Animator winAnim;
    public Animator loseAnim;
    public Animator ballAnim;
    public Animator panel;

    void Start()
    {
        winAnim.SetBool("Win", false);
        panel.SetBool("Panel", false);
        ballAnim.SetBool("WinBall", false);
    }

    void Update()
    {
        if (pathChecker.enemyList.Count == 0)
        {
            Win();
        }
        StartCoroutine("timeOut");
    }
    IEnumerator timeOut()
    {
        if (pathChecker.enemyList.Count >= 1 && ballHP.transform.localScale.x <= 0.15f)
        {
            if (shootLine.enabled == false)
            {
                yield return new WaitForSecondsRealtime(3f);
                if (pathChecker.enemyList.Count >= 1 && ballHP.transform.localScale.x <= 0.15f)
                {
                    Lose();
                }
            }
        }
    }
    void Win()
    {
        ballEnd.end = true;
        winAnim.SetBool("Win", true);
        panel.SetBool("Panel", true);
        ballAnim.SetBool("WinBall", true);
    }
    void Lose()
    {
        ballEnd.end = true;
        panel.SetBool("Panel", true);
        loseAnim.SetBool("Lost", true);
    }
}
