using UnityEngine;

public class PlayerMove : MonoBehaviour {

	private Rigidbody _rigidbody;
	public Transform CameraCenter;
	public float torqueValue;

	void Start() {
		_rigidbody = GetComponent<Rigidbody>();

	}
	void FixedUpdate() {
		_rigidbody.AddTorque(Input.GetAxis("Vertical") * CameraCenter.right * torqueValue);
		_rigidbody.AddTorque(-Input.GetAxis("Horizontal") * CameraCenter.forward * torqueValue);
	}
}
