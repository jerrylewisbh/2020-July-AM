using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : Interactible
{
   private Light light;

   private void Awake()
   {
      light = GetComponentInChildren<Light>();
      light.enabled = false;
   }

   public override void Interact()
   {
      light.enabled = !light.enabled;
   }
}
