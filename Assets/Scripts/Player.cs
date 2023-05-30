using UnityEngine;

public class Player : MonoBehaviour {

	public GameControllManager gameControllManager;

	private void OnTriggerEnter(Collider other) {
		if(other.gameObject.GetComponent<Coin>()) {
			gameControllManager.RemoveCoin(other.GetComponent<Coin>());
			gameControllManager.IncrementCoinCount();
		}
	}
	void Start() {

	}
	void Update() {

	}
}
