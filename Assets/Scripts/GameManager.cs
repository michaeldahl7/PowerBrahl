using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {
	protected GameManager () {}

	public const int loadScene = 2;
	public const int startScene = 1;
	public const int arenaScene = 0;
	public Character arcaneyCharacterPrefab;
	public Character adventureyCharacterPrefab;
	public Character nobleyCharacterPrefab;
	public Character dazzleyCharacerPrefab;
	public EventManagerIntArg eventManager;

	public void loadLevel(int sceneNumber){
		SceneManager.LoadSceneAsync(sceneNumber);
	}
}


