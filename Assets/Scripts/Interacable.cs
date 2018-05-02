using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacable : MonoBehaviour {
    public virtual void Interact()
    {
        Destroy(gameObject);
    }
}
