using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dungNKS : StateMachineBehaviour
{

   
    public int soMin = 0;
    public int soMax = 3;
    public int so;
    Vector2 vitriPlayer;
    float khoangcach;
    public float tocdo;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
        so = Random.Range(soMin, soMax);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Debug.Log(khoangcach);
        // vi tri Player
        // vi tri enemy
        // khi het thoi gian thi doi Hoat Canh dua tren khoang cach
        Vector3 diemden = new Vector3(player.instance.transform.position.x, animator.transform.position.y, animator.transform.position.z);

       

        vitriPlayer = player.instance.transform.position;

        khoangcach = Vector2.Distance(vitriPlayer, animator.transform.position);

      


        // Debug.Log(khoangcach);
            if (khoangcach <= 3)
            {

                if (so == 0)
                {
                    animator.SetTrigger("chieu1");

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
            else if (khoangcach > 3)
            {
               
                    if (so == 0)
                    {
                        animator.SetTrigger("duoi");

                    }
                    else 
                    {
                        animator.SetTrigger("duoi");
                    }
                
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
