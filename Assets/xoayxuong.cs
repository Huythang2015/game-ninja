using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xoayxuong : StateMachineBehaviour
{
    public float tocdoplayer;
    public float tocdo;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    float y;

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        y = player.instance.transform.localEulerAngles.y;
        if (y != 0)
        {
            player.instance.tocdo = 0;

            y = 0;
            player.instance.transform.localEulerAngles = new Vector3(0f, y, 0f);

        }
        else
        {
            animator.SetBool("rexuong", false);
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (diemxoayduoi.instance.trong == false)
        {
            player.instance.tocdo = player.instance.tocdobandau;
        }
        else
        {
            player.instance.tocdo = player.instance.tocdobandau;
        }
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
