using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : Interacable {


    private void OnTriggerEnter(Collider other)
    {
        other.GetComponentInChildren<gun>().AddAmmo(15);
        Interact();
    }


    public override void Interact()
    {

        base.Interact();
    }
}
