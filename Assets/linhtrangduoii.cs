using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linhtrangduoii : StateMachineBehaviour
{
    public float timeMin;
    public float timemax;
    public float time;
    public int soMin = 0;
    public int soMax = 2;
    public int so;
    Vector2 vitriPlayer;
    float khoangcach;
    public float tocdo;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        time = Random.Range(timeMin, timemax);
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

        //animator.transform. position = Vector2.MoveTowards(animator.transform. position, diemden, 3 * Time.deltaTime);
        //animator.GetComponent<Rigidbody>().velocity = new Vector3(diemden.x * tocdo * Time.deltaTime , animator.GetComponent<Rigidbody>().velocity.y);

        vitriPlayer = player.instance.transform.position;

        khoangcach = Vector2.Distance(vitriPlayer, animator.transform.position);

        time -= Time.deltaTime;


        // Debug.Log(khoangcach);
        if (khoangcach <= 3)
        {

            if (so == 0)
            {
                animator.SetTrigger("danh");

            }
            else if (so == 1)
            {
                animator.SetTrigger("danh");
            }
        }
        else if (khoangcach > 3)
        {
            if (time <= 0)
            {
                if (so == 0)
                {
                    animator.SetTrigger("dung");

                }
                else if (so == 1)
                {
                    animator.SetTrigger("duoi");
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
}
