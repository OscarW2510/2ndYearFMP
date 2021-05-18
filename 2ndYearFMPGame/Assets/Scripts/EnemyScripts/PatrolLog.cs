using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolLog : Log
{

    public Transform[] path;
    public int currentPoint;
    public Transform currentGoal;
    public float roundingDistance;

    public override void CheckDistance()
    {
        Debug.Log("CHecking distance");
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            Debug.Log("Chasing player");
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                Debug.Log("Going to player");
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                changeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
                //ChangeState(EnemyState.walk);
                anim.SetBool("wakeUp", true);
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            Debug.Log("Player to far");
            if(Vector3.Distance(transform.position, path[currentPoint].position) > roundingDistance)
            {
                Debug.Log("Moving to path");
                Vector3 temp = Vector3.MoveTowards(transform.position, path[currentPoint].position, moveSpeed * Time.deltaTime);
                changeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
                anim.SetBool("wakeUp", true);
            }
            else
            {
                Debug.Log("changing path");
                ChangeGoal();
            }
            
        }
    }

    private void ChangeGoal()
    {
        if(currentPoint == path.Length - 1)
        {
            currentPoint = 0;
            currentGoal = path[0];
        }
        else
        {
            currentPoint++;
            currentGoal = path[currentPoint];
        }
    }
}
