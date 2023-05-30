using UnityEngine;

public class Pointer : MonoBehaviour {

	public GameControllManager gameControllManager;
	public GameObject ArrowPreFab;
	public GameObject Player;
	private GameObject Arrow;
	private Coin closestCoin;
	private void Start() {
		Arrow = Instantiate(ArrowPreFab);
	}
	void Update() {
		closestCoin = gameControllManager.GetClosest(transform.position);
		if(closestCoin != null) {
			Vector3 target = closestCoin.transform.position - Player.transform.position;
			float distance = target.magnitude;
			Vector3 direction = target / distance;
			Arrow.transform.position = new Vector3(transform.position.x, 1.1f, transform.position.z);
			Arrow.transform.localRotation = Quaternion.LookRotation(direction);
		} else {
			Destroy(Arrow);
		}
	}
}
