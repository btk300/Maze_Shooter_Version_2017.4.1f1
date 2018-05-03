using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gun : MonoBehaviour {


	public int damage = 15;
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
        DisplayAmmoCount();
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

    public void AddAmmo(int amount)
    {
        maxAmmo += amount;
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
                if (hit.collider.gameObject.CompareTag("Enemie")){
                    hit.collider.GetComponent<EnemieHealth>().TakeDamage(damage);
                }
            }
        }
    }

    void Reload()
    {
        if (maxAmmo >= (15 - gunAmmo))
        {
            maxAmmo -= (15 - gunAmmo);
            gunAmmo = 15;
        }
        else
        {
            gunAmmo += maxAmmo;
            maxAmmo = 0;
        }
        gunReloadSound.Play();
        ammoCountText.color = originalTextColor;
    }
}
