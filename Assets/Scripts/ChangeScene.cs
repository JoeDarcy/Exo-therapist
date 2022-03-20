using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
	[SerializeField] private int sceneToLoad = 0;

	// Change scene
	public void LoadScene()
	{
		SceneManager.LoadScene(sceneToLoad);
	}
}
