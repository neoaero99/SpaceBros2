﻿using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
	public int damage;
	float animDone = 0.45f;
	private float timer;
	public bool triggerHit = false;

	// Explosion SFX
	public AudioClip X_Explode;

	void Start () {
		damage = UnityEngine.Random.Range(8, 12);
		// Play explosion SFX
		CameraRunner.gAudio.PlayOneShot( X_Explode );
	}

	// Update is called once per frame
	void Update () {
		animDone -= Time.deltaTime;

		if (animDone <= 0) {
			Destroy (this.gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D coll) {
		Player is_player = coll.GetComponent<Player>();

		if (is_player != null && !triggerHit) {
			triggerHit = true;
			is_player.GetHurt(damage);
		}
		//Add similar condition for enemy
	}
}
