using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCount : MonoBehaviour {

    private int Keys;
    public Animator DoorAnim;
    public Text keyText;
    public Text DoorText;

    private void Start()
    {
        Keys = 0;
        keyText.text = "Keys: " + Keys + "/2";
    }

    public void AddKey()
    {
        Keys++;
        keyText.text = "Keys: " + Keys + "/2";
        if (Keys == 2)
        {
            DoorText.color = Color.green;
            DoorText.text = "The door is open";
            DoorAnim.SetTrigger("DoorATrigger");
        }
    }
}
