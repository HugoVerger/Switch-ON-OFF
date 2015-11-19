using UnityEngine;
using System.Collections;


public class LoadLevel : MonoBehaviour {
	
	public string LevelToLoad;
	
	public void loadLevel() {
		//Load the level from LevelToLoad
		Application.LoadLevel(LevelToLoad);
	}
}
