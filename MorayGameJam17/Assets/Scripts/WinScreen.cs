using UnityEngine;

public class WinScreen : MonoBehaviour {

	[SerializeField]
	RoomManager roomManager = null;

	[SerializeField]
	GameObject winScreen = null;

	[SerializeField]
	GameObject hud = null;

	private void Start() {
		winScreen.SetActive(false);
		Time.timeScale = 1;
	}

	private void OnEnable() {
		EventManager.OnPossibleGameCompletion += OnPossibleFixedShip;
	}

	private void OnDisable() {
		EventManager.OnPossibleGameCompletion -= OnPossibleFixedShip;
	}

	private void OnPossibleFixedShip() {
		if (roomManager.IsShipFixed()) {
			// Start lerp towards Beacon.
			// Disable win screen and pause game.
			Time.timeScale = 0;
			winScreen.SetActive(true);
			hud.SetActive(false);
		}
	}
}
