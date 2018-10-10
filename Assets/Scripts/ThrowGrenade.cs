using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour {
    [SerializeField]
    private float speed;
    private Rigidbody rb;
    private Vector3 force;
    [SerializeField]
    private GameObject grenade;
    [SerializeField] private GameObject player;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.V)) SpawnGrenade();
    }
    void SpawnGrenade()
    {
        GameObject gren = Instantiate(grenade, player.transform.position, player.transform.rotation);
        gren.GetComponent<Rigidbody>().AddForce(player.transform.forward * speed, ForceMode.VelocityChange);
    }
}
