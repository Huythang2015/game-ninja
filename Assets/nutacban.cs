using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class khac : MonoBehaviour
{
    public void ban()
    {

    }

}
public class nutacban : StateMachineBehaviour
{
    public float timeMin;
    public float timemax;
    public float time;
    public int soMin = 0;
    public int soMax = 3;
    public int so;
    Vector2 vitriPlayer;
    float khoangcach;
    public float docao;
    Vector2 diemden;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time = Random.Range(timeMin, timemax);
        so = Random.Range(soMin, soMax);
        animator.GetComponent<Rigidbody>().useGravity = false;
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        // vi tri Player
        // vi tri enemy
        // khi het thoi gian thi doi Hoat Canh dua tren khoang cach

        vitriPlayer = player.instance.transform.position;
        khoangcach = Vector2.Distance(vitriPlayer, animator.transform.position);
        time -= Time.deltaTime;
        if (time <= 0)
        {
            animator.SetTrigger("ban3"); 
        }
        


        
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
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
