﻿using UnityEngine;
using System.Collections;

public class DripSpawnScript : MonoBehaviour {

	public float DripRate = 1;
	public GameObject DripPrefab;
	float cooldown;
	// Use this for initialization
	void Start () {
		cooldown = DripRate;
	}
	
	// Update is called once per frame
	void Update () {
		cooldown -= Time.deltaTime;
		if (cooldown <= 0) {
			Instantiate(DripPrefab,this.transform.position,Quaternion.identity);
			cooldown = DripRate;
		}
	}
}
