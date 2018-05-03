using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerHealth>().TakeDamage(100);
    }


}
