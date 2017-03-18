using UnityEngine;

public class SoundManager : MonoBehaviour {

	private uint bankID;
	private uint initBankID;
	[SerializeField]
	private string soundbankName = "Soundbank1";

	// Use this for initialization
	void Start() {
		Initialise();
		PlayEvent("PickUp", gameObject);
	}

	private void Initialise() {
		// Import Initialisation Soundbank
		AkSoundEngine.LoadBank("Init", AkSoundEngine.AK_DEFAULT_POOL_ID, out initBankID);
		// Import Soundbank
		AkSoundEngine.LoadBank(soundbankName, AkSoundEngine.AK_DEFAULT_POOL_ID, out bankID);
	}

	// Play Event
	public void PlayEvent(string eventName, GameObject go) {
		AkSoundEngine.PostEvent(eventName, go);
	}

	// Stop Event
	public void StopEvent(string eventName, int fadeOut, GameObject go) {
		uint eventID;
		eventID = AkSoundEngine.GetIDFromString(eventName);
		AkSoundEngine.ExecuteActionOnEvent(eventID, AkActionOnEventType.AkActionOnEventType_Stop, go, fadeOut, AkCurveInterpolation.AkCurveInterpolation_Sine);
	}

	// Stop All Events
	public void StopAllEvents() {
		AkSoundEngine.StopAll();
	}

	// Switch States
	public void SetSwitch(GameObject player, string switchName, string switchState) {
		AkSoundEngine.SetSwitch(switchName, switchState, player);
	}

	// Set RTPCs
	public void SetRTPC(GameObject player, string rtpcName, float rtpcValue) {
		AkSoundEngine.SetRTPCValue(rtpcName, rtpcValue);
	}
}
