using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerxoay : StateMachineBehaviour
{
    public float tocdodi;
    public float tocdoxoay;
    float y;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.applyRootMotion = true;
   

        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        y = player.instance.transform.localEulerAngles .y;
        
        if (y ==  0)
        {
            player.instance.tocdo = 0;
            animator.transform.eulerAngles = new Vector3(0f, -90, 0f) ;
            //animator.transform.position += new Vector3(1, 0, 0.5f) * tocdodi * Time.deltaTime;    
            
        }
        else  { 
            animator.SetBool("relen", false);
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
       
        //animator.applyRootMotion = true;
        //player.instance.transform.localRotation = Quaternion.Euler(player.instance.transform.localRotation.x, -90f, player.instance.transform.localRotation.z);
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
