using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nutacban3 : StateMachineBehaviour
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
    Vector2 diemve;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Rigidbody>().useGravity = true;
        time = Random.Range(timeMin, timemax);
        so = Random.Range(soMin, soMax);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        khoangcach = Vector2.Distance(vitriPlayer, animator.transform.position);
        time -= Time.deltaTime;
        
            if (time <= 0)
            {

                if (khoangcach <= 3)
                {

                    if (so == 0)
                    {
                        animator.SetTrigger("chem");

                    }
                    else if (so == 1)
                    {
                        animator.SetTrigger("da");
                    }
                    else if (so == 2)
                    {
                        animator.SetTrigger("da");

                    }
                }
                else
                {
                    if (so == 0)
                    {
                        animator.SetTrigger("dung");

                    }
                    else
                    {
                        animator.SetTrigger("duoi");
                    }
                }


            }
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

