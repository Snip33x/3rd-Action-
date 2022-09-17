using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestState : PlayerBaseState
{
    private float timer;
    public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine)  //because we are inheriting from abstract class we need constructor again
    {
    }

    public override void Enter()
    {
        stateMachine.InputReader.JumpEvent += OnJump;
        Debug.Log("Enter");
    }
    public override void Tick(float deltaTime)
    {
        timer += deltaTime;
        Debug.Log(timer);

    }
    public override void Exit()
    {
        stateMachine.InputReader.JumpEvent -= OnJump;
        Debug.Log("Exit");
    }

    private void OnJump()
    {
        stateMachine.SwitchState(new PlayerTestState(stateMachine));
    }
    
}
