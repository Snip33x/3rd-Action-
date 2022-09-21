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
        Vector3 movement = CalculateMovement();

        stateMachine.Controller.Move(movement * stateMachine.FreeLookMovementSpeed * deltaTime); //in fast framerate character will move fast, and in low he will move slow, so we multiply by deltaTime

        if(stateMachine.InputReader.MovementValue == Vector2.zero) 
        {
            stateMachine.Animator.SetFloat("FreeLookSpeed", 0, 0.1f, deltaTime);  //refering to parameters in Animator
            return; 
        }

        stateMachine.Animator.SetFloat("FreeLookSpeed", 1, 0.1f, deltaTime);
        stateMachine.transform.rotation = Quaternion.LookRotation(movement);
    }
    public override void Exit()
    {

    }

    private Vector3 CalculateMovement()
    {
        Vector3 moveForward = stateMachine.MainCameraTransform.forward;
        Vector3 moveRight = stateMachine.MainCameraTransform.right;

        moveForward.y = 0;
        moveRight.y = 0;

        moveRight.Normalize();
        moveRight.Normalize();


        return moveForward * stateMachine.InputReader.MovementValue.y +
            moveRight * stateMachine.InputReader.MovementValue.x;
    }
}
