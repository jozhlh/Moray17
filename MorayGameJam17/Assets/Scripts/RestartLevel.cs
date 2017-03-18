using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour {

	/// <summary>
	/// Reloads the currently active level.
	/// </summary>
	public void Restart() {
		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
	}
}
