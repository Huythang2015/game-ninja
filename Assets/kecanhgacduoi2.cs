using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kecanhgacduoi2 : StateMachineBehaviour
{
    public float timeMin;
    public float timemax;
    public float time;
    public int soMin = 0;
    public int soMax = 2;
    public int so;
    Vector2 vitriPlayer;
    float khoangcach;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time = Random.Range(timeMin, timemax);
        so = Random.Range(soMin, soMax);
        animator.applyRootMotion = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log(khoangcach);
        // vi tri Player
        // vi tri enemy
        // khi het thoi gian thi doi Hoat Canh dua tren khoang cach
        Vector3 diemden = new Vector3(player.instance.transform.localPosition.x, animator.transform.localPosition.y, animator.transform.localPosition. z);
        Debug.Log(animator.transform.localPosition);
        animator.transform.localPosition = Vector2.MoveTowards(animator.transform.localPosition, diemden, 3 * Time.deltaTime);

        vitriPlayer = player.instance.transform.localPosition;

        khoangcach = Vector2.Distance(vitriPlayer, animator.transform.localPosition) ;

        time -= Time.deltaTime;


         Debug.Log(khoangcach);
        if (khoangcach <= 1.5f)
        {

            if (so == 0)
            {
                animator.SetTrigger("chem");

            }
            else if (so == 1)
            {
                animator.SetTrigger("dung");
            }
        }
        else if (khoangcach > 3)
        {
            if (time <= 0)
            {
                if (so == 0)
                {
                    animator.SetTrigger("duoi");

                }
                else if (so == 1)
                {
                    animator.SetTrigger("dung");
                }
            }
        }
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.applyRootMotion = true;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
