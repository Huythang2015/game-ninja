using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kecanhgacdung0 : StateMachineBehaviour
{
    public float timeMin;
    public float timemax;
    Rigidbody rigi;
    public float tocdo;
    float time;
     //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time  = Random.Range(timeMin, timemax);
        rigi = animator.transform.GetComponent<Rigidbody>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.transform.position.x < player.instance.transform.position.x + 1 && animator.transform.position.x > player.instance.transform.position.x - 1
            )
        {
            animator.SetTrigger("chem");
        }
        
        time -= Time.deltaTime;
        if (time < 0 )
        {
            animator.SetTrigger("lui");
        }
      
        if (animator.transform.localScale.x < 0)
        {
            rigi.velocity = new Vector2(tocdo * Time.deltaTime, rigi.velocity.y);
        }
        else if (animator.transform.localScale.x > 0)
        {
            rigi.velocity = new Vector2(tocdo * -1 * Time.deltaTime, rigi.velocity.y);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
