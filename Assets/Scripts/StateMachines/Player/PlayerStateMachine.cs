using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public InputReader InputReader { get; private set; }  //property won't show up in editor, so we use Serialized field but modificated with field:
    [field: SerializeField] public CharacterController Controller { get; private set; }  //property won't show up in editor, so we use Serialized field but modificated with field:
    [field: SerializeField] public float FreeLookMovementSpeed { get; private set; }
    // Start is called before the first frame update
    private void Start()
    {
        SwitchState(new PlayerTestState(this));
    }

}
