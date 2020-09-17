using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brush : Interactible
{
    private TrailRenderer trail;

    private void Awake()
    {
        trail = GetComponentInChildren<TrailRenderer>();
        trail.emitting = false;
    }

    public override void Interact()
    {
        trail.emitting = !trail.emitting;
    }
}
