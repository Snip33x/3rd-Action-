using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    [SerializeField] private CinemachineTargetGroup cineTargetGroup;

    private Camera mainCamera;

    private List<Target> targets = new List<Target>();

    public Target CurrentTarget { get; private set; }

    private void Start()
    {
        mainCamera = Camera.main;
    }

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

        Target closestTarget = null;
        float closestTargetDistance = Mathf.Infinity;

        foreach (Target target in targets)
        {
            Vector2 viewPos = mainCamera.WorldToViewportPoint(target.transform.position);

            if (!target.GetComponentInChildren<Renderer>().isVisible) // if the target is out of the screen
            {
                continue;
            }

            Vector2 toCenter = viewPos - new Vector2(0.5f, 0.5f);  //how far is target from the center of the screen
            if(toCenter.sqrMagnitude < closestTargetDistance) //sqrMagnitude tells you how big Vector2 is // sqr is easier for computer to do
            {
                closestTarget = target;
                closestTargetDistance = toCenter.sqrMagnitude;
            }

        }

        if(closestTarget == null) { return false; } //we wont enter the targeting state becasue we don't have a target

        CurrentTarget = closestTarget;
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
