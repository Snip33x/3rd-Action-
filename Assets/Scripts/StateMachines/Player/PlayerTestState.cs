using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestState : PlayerBaseState
{
    private float timer = 5f;
    public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine)  //because we are inheriting from abstract class we need constructor again
    {
    }

    public override void Enter()
    {
        Debug.Log("Enter");
    }
    public override void Tick(float deltaTime)
    {
        timer -= deltaTime;
        Debug.Log(timer);

        if (timer <= 0f)
        {
            stateMachine.SwitchState(new PlayerTestState(stateMachine));
        }
    }
    public override void Exit()
    {
        Debug.Log("Exit");
    }

    
}
