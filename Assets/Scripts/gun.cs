using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour {


	public float damage = 15f;
	public float distance = 150f;


    public Camera fpscam;
    public Animation gunAnim;
	// Use this for initialization
	void Start () {
        gunAnim = GetComponent<Animation>();
        fpscam = GetComponentInParent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
            gunAnim.Play();
			RaycastHit hit;
			if (Physics.Raycast (fpscam.transform.position, fpscam.transform.forward, out hit, distance)) {
                if (hit.transform.CompareTag("Player")){
                    return;
                }
                else
                {
                    Debug.Log(hit.transform.name);
                }
			}
		}
	}
}
