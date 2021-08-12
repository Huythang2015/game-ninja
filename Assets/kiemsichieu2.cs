using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kiemsichieu2 : StateMachineBehaviour
{
    public int so;
    public int somin;
    public int somax;

    public float time;
    public float timeMin;
    public float timeMax;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Rigidbody>().isKinematic = true; // de animator dc chuan
        so = Random.Range(somin, somax);
        time = Random.Range(timeMin, timeMax);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }

        if (time <= 0)
        {
            if (so == 0)
            {
                animator.SetTrigger("chieu1");
            }
            else if (so == 1)
            {
                animator.SetTrigger("dung");
            }
            else if (so == 2)
            {
                animator.SetTrigger("chieu3");
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Rigidbody>().isKinematic = false;
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
