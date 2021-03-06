﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager gm;
	public GameObject player;

	private enum gameStates {Playing, BeatLevel, GameOver};
	private gameStates gameState = gameStates.Playing;

	public bool levelBeaten = false;
	public GameObject beatLevelCanvas;
	public AudioSource backgroundMusic;
	public AudioClip beatLevelSFX;

	void Start () {
		if (gm == null) 
			gm = gameObject.GetComponent<GameManager>();

		if (player == null)
			player = GameObject.FindWithTag("Player");

		beatLevelCanvas.SetActive (false);
	}

	void Update () {
		switch (gameState)
		{
			case gameStates.Playing:
				if (levelBeaten) {
					// update gameState
					gameState = gameStates.BeatLevel;

					// hide the player so game doesn't continue playing
					player.SetActive(false);

					// switch which GUI is showing			
					beatLevelCanvas.SetActive (true);
				}
				break;
			case gameStates.BeatLevel:
				backgroundMusic.volume -= 0.01f;
				if (backgroundMusic.volume<=0.0f) {
					AudioSource.PlayClipAtPoint (beatLevelSFX,gameObject.transform.position);
					
					gameState = gameStates.GameOver;
				}
				break;
			case gameStates.GameOver:
				// nothing
				break;
		}
	}

	public void beatLevel() {
		levelBeaten = true;
	}
}
