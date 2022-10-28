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
}
