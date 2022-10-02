using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingState : PlayerBaseState
{
    private Attack attack;

    public PlayerAttackingState(PlayerStateMachine stateMachine, int AttackId) : base(stateMachine)
    {
        attack = stateMachine.Attacks[AttackId];
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(attack.AnimationName, .1f); //instead of Play animation we want to smoothi it with transition
    }
    public override void Tick(float deltaTime)
    {

    }

    public override void Exit()
    {

    }

}
