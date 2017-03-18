using UnityEngine;

public class WinScreen : MonoBehaviour {

	[SerializeField]
	GameObject winScreen = null;

	[SerializeField]
	GameObject hud = null;

	private void Start() {
		winScreen.SetActive(false);
	}

	private void OnEnable() {
		EventManager.OnGameCompletion += OnGameCompletion;
	}

	private void OnDisable() {
		EventManager.OnGameCompletion -= OnGameCompletion;
	}

	/// <summary>
	/// Displays the win screen when the game is completed, and hides the HUD.
	/// </summary>
	private void OnGameCompletion() {
		winScreen.SetActive(true);
		hud.SetActive(false);
	}
}
