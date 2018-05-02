﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gun : MonoBehaviour {


	public float damage = 15f;
	public float distance = 150f;
    public int gunAmmo = 15;
    public int maxAmmo = 15;
    public AudioSource gunSound;
    public AudioSource gunReloadSound;
    public Text ammoCountText;

    private Color originalTextColor;
    private Camera fpscam;
    private Animation gunAnim;
	// Use this for initialization
	void Start () {
        gunAnim = GetComponent<Animation>();
        fpscam = GetComponentInParent<Camera>();
        DisplayAmmoCount();
        originalTextColor = ammoCountText.color;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (maxAmmo == 0)
            {
                return;
            }
            Reload();
        }
		if (Input.GetButtonDown ("Fire1")) {
            if (gunAmmo == 0 && maxAmmo == 0)
            {
                return;
            }
            if(gunAmmo == 0)
            {
                Reload();
            }
            else
            {
                Shoot();
                if(gunAmmo == 0)
                {
                    ammoCountText.color = Color.red;
                }
            }
                      
		}
	}

    void DisplayAmmoCount()
    {
        ammoCountText.text = "Ammo: " + gunAmmo + "/" + maxAmmo;
    }


    void Shoot()
    {
        int layerMask = 1 << 9;
        layerMask = ~layerMask;
        if (!gunSound.isPlaying && !gunAnim.isPlaying)
        {
            gunSound.Play();
            gunAnim.Play();
            gunAmmo -= 1;
            RaycastHit hit;
            if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, distance, layerMask))
            {
                //damage the thingy
            }
        }
        DisplayAmmoCount();
    }

    void Reload()
    {
        maxAmmo -= (15-gunAmmo);
        gunAmmo = 15;
        gunReloadSound.Play();
        ammoCountText.color = originalTextColor;
        DisplayAmmoCount();
    }
}
