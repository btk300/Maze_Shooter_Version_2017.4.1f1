using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameWin : MonoBehaviour {
    public GameEngine gameEngine;
    private void OnTriggerEnter(Collider other)
    {
        gameEngine.GameWin();
    }
}
