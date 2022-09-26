using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    [SerializeField] private CinemachineTargetGroup cineTargetGroup;

    private List<Target> targets = new List<Target>();

    public Target CurrentTarget { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        Target target = other.GetComponent<Target>();
        
        if (target == null) { return; }
       
        targets.Add(target);
        target.OnDestroyed += RemoveTarget;
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent<Target>(out Target target)) { return; }  //same thing as below but written in two lines

        RemoveTarget(target);


        //Target target = other.GetComponent<Target>();

        //if (target == null) { return; }

        //targets.Remove(target);   

    }

    public bool SelectTarget()
    {
        if(targets.Count == 0) { return false; }

        CurrentTarget = targets[0];
        cineTargetGroup.AddMember(CurrentTarget.transform, 1f, 2f);

        return true;
    }

    public void Cancel()
    {
        if(CurrentTarget == null) { return; }

        cineTargetGroup.RemoveMember(CurrentTarget.transform);
        CurrentTarget = null;
    }

    private void RemoveTarget(Target target)  // probably this parameter is needed because we have Action<Target> inside Target
    {
        if (CurrentTarget == target)
        {
            cineTargetGroup.RemoveMember(CurrentTarget.transform);
            CurrentTarget = null;
        }

        target.OnDestroyed -= RemoveTarget;
        targets.Remove(target);
    }
}
