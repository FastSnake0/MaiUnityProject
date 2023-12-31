using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrolState : AIBaseState
{
    public int waypointIndex;
    public float waitTimer = 0f;
    public override void Enter()
    {

    }
    public override void Perform()
    {
        PatrolLogic();
        if (enemy.CanSeePlayer())
        {
            //Debug.Log(enemy.CanSeePlayer());
            stateMachine.ChangeState(new AIAttackState());
        }
    }
    
    public override void Exit()
    {

    }
    public void PatrolLogic()
    {
        //Debug.Log(enemy.Agent.remainingDistance);
        if (enemy.Agent.remainingDistance >= 0.2f) return;
        waitTimer += Time.deltaTime;
        if (waitTimer <= 2f)
        {
            enemy.Agent.speed = 0;
            return;
        }
        enemy.Agent.speed = enemy.walkSpeed;
        if (waypointIndex < enemy.path.waypoints.Count - 1)
        {
            waypointIndex++;
        }
        else
        {
            waypointIndex = 0;
        }
        enemy.Agent.SetDestination(enemy.path.waypoints[waypointIndex].position);
        waitTimer = 0f;
    }
}
