using UnityEngine;

public class DebugUi : MonoBehaviour {

	/// <summary>
	/// Launches a fake version of winning.
	/// </summary>
	public void FakeWin() {
		EventManager.ShipFixed();
	}
}
