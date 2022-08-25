using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{

    private State currentState;

    private void Update()
    {
        currentState?.Tick(Time.deltaTime); // ? is a short way of - if currentState != null   (? - is a null condition operator)
    }

    public void SwitchState(State newState)
    {
            currentState?.Exit();
            currentState = newState;
            currentState?.Enter();
    }
}
