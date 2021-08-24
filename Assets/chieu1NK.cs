using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chieu1NK : StateMachineBehaviour
{
    Rigidbody rigi;
    int so;
    Vector3 vitriPlayer;
    float khoangcach;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rigi = animator.GetComponent<Rigidbody>(); //  rigi cua nukiem 
        rigi.isKinematic = true;
        so = Random.Range(0, 3);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        vitriPlayer = player.instance.transform.position;

        khoangcach = Vector2.Distance(vitriPlayer, animator.transform.position);
        if (khoangcach <= 2)
        {
            if (so == 0)
            {
                animator.SetTrigger("dung");
            }
            else if (so == 1)
            {
                animator.SetTrigger("chieu2");
            }
            else
            {
                animator.SetTrigger("chieu3");
            }
        }
        else
        {
            animator.SetTrigger("duoi");
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rigi.isKinematic = false;
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
