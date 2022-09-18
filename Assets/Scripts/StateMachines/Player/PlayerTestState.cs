using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestState : PlayerBaseState
{
    public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine)  //because we are inheriting from abstract class we need constructor again
    {
    }

    public override void Enter()
    {
        
    }
    public override void Tick(float deltaTime)
    {
        Vector3 movement = new Vector3();
        movement.x = stateMachine.InputReader.MovementValue.x;
        movement.y = 0;
        movement.z = stateMachine.InputReader.MovementValue.y;

        stateMachine.transform.Translate(movement * deltaTime); //in fast framerate character will move fast, and in low he will move slow, so we multiply by deltaTime
        Debug.Log(stateMachine.InputReader.MovementValue);
    }
    public override void Exit()
    {

    }

    private void OnJump()
    {
        stateMachine.SwitchState(new PlayerTestState(stateMachine));
    }
    
}
