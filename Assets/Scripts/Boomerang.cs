using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour {
    private bool isAttack;
    private GameObject player;
    private GameObject boomerang;
    private Transform boomerangGraph;
    private Vector3 frontOfPlayer;
	// Use this for initialization
	void Start () {
        isAttack = false;

        player = GameObject.Find("FPSController");
        boomerang = GameObject.Find("Boomerang");
        boomerang.GetComponent<MeshRenderer>().enabled = false;

        boomerangGraph = gameObject.transform.GetChild(0);

        frontOfPlayer = new Vector3(player.transform.position.x,player.transform.position.y + 1, player.transform.position.z) + player.transform.forward * 10f;
        StartCoroutine(Launch());
    }
	
	// Update is called once per frame
	void Update () {
		if (isAttack)
        {
            transform.position = Vector3.MoveTowards(transform.position, frontOfPlayer, Time.deltaTime * 2f);
        }
        if (!isAttack)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z), Time.deltaTime * 2f);
        }
        if (!isAttack && Vector3.Distance(player.transform.position, transform.position) < 1f)
        {
            boomerang.GetComponent<MeshRenderer>().enabled = true;
            Destroy(this.gameObject);
        }
	}

    IEnumerator Launch()
    {
        isAttack = true;
        yield return new WaitForSeconds(1.5f);
        isAttack = false;
    }
}
