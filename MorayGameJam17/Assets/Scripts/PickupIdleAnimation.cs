using UnityEngine;

using LittleLot;
/// <summary>
/// PickUp Idle Animation script, gives nice rotation and scaling animation.
/// Allows the pausing and restarting of the pickups animation. 
/// Reseting its height when resumed.
/// </summary>
public class PickupIdleAnimation : IdleAnimation {
		
	private float initialHeight_ = 0.0f;

	/// <summary>
	/// Store initial start and end points, and ensures tag is correctly set.
	/// </summary>
	protected new void Start() {
		base.Start();
		initialHeight_ = transform.position.y;
	}
	
	/// <summary>
	/// Resets the height of the object and restarts the animation.
	/// </summary>
	public new void ResumeAnimation() {
		base.ResumeAnimation();
		
		Vector3 newPosition = transform.position;
		// reset the height of the object to its initial height.
		transform.position = new Vector3(newPosition.x, initialHeight_, newPosition.z);
		// Update move to and from
		pingPongMoveTo_ = pingPongTarget.position;
		pingPongMoveFrom_ = transform.position;
	}

}
