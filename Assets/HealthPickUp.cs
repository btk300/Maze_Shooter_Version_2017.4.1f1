using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : Interacable {

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerHealth>().IncreaseHealth(30);
        Interact();
    }

    public override void Interact()
    {
        base.Interact();
    }
}
