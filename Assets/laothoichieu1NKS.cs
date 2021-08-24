using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laothoichieu1NKS : StateMachineBehaviour
{
    public Rigidbody rigi;
    public Transform vitriplayer;
    Vector3 huong;
    public float tocdo;
    nukiemsi nukiemsi;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        vitriplayer = GameObject.Find("nhanvat").transform; // tranfrom cua player
        rigi = animator.GetComponent<Rigidbody>(); //  rigi cua nukiem
        nukiemsi = animator.GetComponent<nukiemsi>();
        huong = (vitriplayer.position - rigi.position).normalized * tocdo;// huong lao toi
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        animator.transform.Translate(huong); // lao toi
        if (rigi.position.y < vitriplayer.position.y + 1) // lao den noi thi 
        {
            animator.SetTrigger("ketthucchieu1"); // sang ket thuc chieu 1
            Debug.Log("ketthuc");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        nukiemsi.stopchieu1();
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
