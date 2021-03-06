using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class chem : StateMachineBehaviour
{
    int tocdokhichem;
    public float tocdobandau;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tocdobandau = player.instance.tocdo;
        if (animator.GetBool("nhay") == false)
        {
            
            player.instance.tocdo = tocdokhichem;
        }

        animator.SetBool("chem1", false);
        animator.SetBool("chem", false);
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       if (Input.GetKeyDown(KeyCode.X) || CrossPlatformInputManager.GetButtonUp("danh"))
        {
            animator.SetBool("chem1", true);
            animator.SetBool("chay", false);
        }
       
       if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.Z))
        {
            animator.SetBool("chem1", false);
            
        }
      
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.instance.tocdo = tocdobandau;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
  

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
