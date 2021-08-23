using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chem2 : StateMachineBehaviour

{
    bool set = true;
    int tocdokhichem;
    public float tocdobandau;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        tocdobandau = player.instance.tocdobandau;
        if (animator.GetBool("nhay") == false)
        {

            player.instance.tocdo = tocdokhichem;
        }

        animator.SetBool("chem1", false);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKeyDown(KeyCode.X) && set == true)
        {
            //animator.SetBool("chem1", false);
            //animator.SetBool("chay", false);
            //set = false;
        }

        if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.Z))
        {
            animator.SetBool("chem1", false);
            set = false;
        }
        if ( player.instance.tocdo != 0)
        {
            player.instance.tocdo = 0;
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.instance.tocdo = tocdobandau;
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
