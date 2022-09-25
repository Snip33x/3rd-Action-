using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{
    private List<Target> targets = new List<Target>();

    public Target CurrentTarget { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        Target target = other.GetComponent<Target>();
        
        if (target == null) { return; }
       
        targets.Add(target);
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent<Target>(out Target target)) { return; }  //same thing as below but written in two lines
           
        targets.Remove(target);
    

        //Target target = other.GetComponent<Target>();

        //if (target == null) { return; }

        //targets.Remove(target);

    }

    public bool SelectTarget()
    {
        if(targets.Count == 0) { return false; }

        CurrentTarget = targets[0];

        return true;
    }

    public void Cancel()
    {
        CurrentTarget = null;
    }
}