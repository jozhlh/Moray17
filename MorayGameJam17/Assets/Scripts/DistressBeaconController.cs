using System.Collections;

using UnityEngine;

public class DistressBeaconController : MonoBehaviour {
	ParticleSystem particleBeam = null;

	float waitForWinDelay = 3.0f;

	private void Start() {
		particleBeam = GetComponent<ParticleSystem>();

	}
	private void OnEnable() {
		EventManager.OnCameraInPosition += OnCameraInPosition;
	}

	private void OnDisable() {
		EventManager.OnCameraInPosition -= OnCameraInPosition;
	}

	/// <summary>
	/// Displays the win screen when the game is completed, and hides the HUD.
	/// </summary>
	private void OnCameraInPosition() {
		particleBeam.Play();
		EventManager.OnCameraInPosition -= OnCameraInPosition;
		StartCoroutine(PlayBeamAnimation());
		SoundManager.StopAllEvents();
        SoundManager.PlayEvent("Sonar_Beam", gameObject);
    }


	private IEnumerator PlayBeamAnimation() {
		// start beam animation
		yield return new WaitForSeconds(waitForWinDelay);
		EventManager.GameCompleted();
	}
}
