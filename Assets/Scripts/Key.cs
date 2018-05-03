using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interacable {

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponentInChildren<KeyCount>().AddKey();
        Interact();
    }


    public override void Interact()
    {

        base.Interact();
    }
}
