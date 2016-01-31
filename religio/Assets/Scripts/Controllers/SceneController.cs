using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SceneController : MonoBehaviour {

	public int dayScene;

	public void ShowNight() {
		//TODO switch the scene view
	}

	public void ShowDay() { 
		//TODO switch the scene view
		Debug.Log("Showing Scene " + dayScene);
		SceneManager.LoadScene(dayScene);
	}
}
