using UnityEngine;
using UnityEngine.UI;

public class ErrorMessage : MonoBehaviour {

	[SerializeField]
	Text text = null;

	[SerializeField]
	Image image = null;
		
	Image background = null;

	Vector3 initialPosition;

	float initialFadeRate = 0.05f;
	float lateFadeRate = 0.1f;

	float currentAlpha = 1.0f;

	private void Start() {
		background = GetComponent<Image>();
		initialPosition = transform.position;
	}

	private void LateUpdate() {
		if (currentAlpha >= 0.9f) {
			currentAlpha -= currentAlpha * initialFadeRate * Time.deltaTime;
			SetAlpha(currentAlpha);
		}else if (currentAlpha >= 0) {
			currentAlpha -= currentAlpha * lateFadeRate;
			SetAlpha(currentAlpha);
		}
	}

	public void SetText(string errorText) {
		text.text = errorText;
	}

	public void SetAlpha(float val) {
		currentAlpha = val;
		Color newColor = text.color;
		newColor.a = val;
		text.color = newColor;

		newColor = image.color;
		newColor.a = val;
		image.color = newColor;

		//newColor = background.color;
		//newColor.a = val;
		//background.color = newColor;
	}

	public void ResetPosition() {		
		transform.position = initialPosition;
	}

	public void ShiftUp(float yOffset) {
		Vector3 currentPos = transform.localPosition;
		transform.localPosition = new Vector3(currentPos.x, currentPos.y + yOffset, currentPos.z);
	}
}
