using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class SniperGrabbable : XRGrabInteractable
{
    [SerializeField] private ScopeCalculation scope;

    protected List<XRBaseInteractor> activeHands = new List<XRBaseInteractor>();

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        XRBaseInteractor curInteractor = args.interactorObject as XRBaseInteractor;
        if (curInteractor != null && curInteractor.allowSelect && !activeHands.Contains(curInteractor))
        {
            activeHands.Add(curInteractor);
            CheckHands();
        }
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        XRBaseInteractor curInteractor = args.interactorObject as XRBaseInteractor;
        if (curInteractor != null && activeHands.Contains(curInteractor))
        {
            activeHands.Remove(curInteractor);
            CheckHands();
        }
    }

    private void CheckHands()
    {
        scope.ActivateCamera(activeHands.Count >= 2);
    }
}
