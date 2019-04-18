using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class death_scene : MonoBehaviour
{
	public void LoadByIndex ()
	{
		SceneManager.LoadScene(sceneBuildIndex: 2);
	}

}