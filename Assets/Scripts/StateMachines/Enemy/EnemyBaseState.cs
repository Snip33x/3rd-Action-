using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState : State //thaks to abstract, we don't have to inherit enter,exit and tick method, they will be implemented in class inheriting from this one
{
    protected EnemyStateMachine stateMachine;  //protected - only classes inheriting can acces this statemachine
    public EnemyBaseState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    protected void Move(float deltaTime)
    {
        Move(Vector3.zero, deltaTime);
    }
    protected void Move(Vector3 motion, float deltaTime)
    {
        stateMachine.Controller.Move((motion + stateMachine.ForceReceiver.Movement) * deltaTime);
    }

    protected bool IsInChaseRange()
    {
        //float distance = Vector3.Magnitude(stateMachine.Player.transform.position - stateMachine.transform.position);
        //if (distance < stateMachine.PlayerChasingRange)
        //{
        //    return true;
        //}
        //return false;

        float playerDistanceSqr = (stateMachine.Player.transform.position - stateMachine.transform.position).sqrMagnitude;
        
        return playerDistanceSqr <= stateMachine.PlayerChasingRange * stateMachine.PlayerChasingRange;
    }
}
