using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	public Transform playerTransform;
	public Rigidbody playerRigidbody;

	List<Vector3> VelocitiesList = new List<Vector3>();

	void Start() {
		for(int i = 0; i < 10; ++i) {
			VelocitiesList.Add(Vector3.zero);
		}
	}

	private void FixedUpdate() {
		VelocitiesList.Add(playerRigidbody.velocity);
		VelocitiesList.RemoveAt(0);
	}

	void Update() {
		Vector3 summ = Vector3.zero;

		for(int i = 0; i < VelocitiesList.Count; ++i) {
			summ += VelocitiesList[i];
		}

		transform.position = playerTransform.position;
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(summ), Time.deltaTime * 10f);
	}
}
