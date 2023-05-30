using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllManager : MonoBehaviour {

	public GameObject CoinPreFab;
	private int _coinCount = 0;
	public Text countInformation;
	public List<Coin> coinList;

	void Start() {
		coinList = new List<Coin>();
		countInformation.text = _coinCount.ToString();
		for(int i = 0; i < 15; i++) {
			GameObject newCoin = Instantiate(CoinPreFab, new Vector3(Random.Range(-15f, 15f), 0.5f, Random.Range(-15f, 15f)), Quaternion.Euler(90f, Random.Range(-180f, 180f), -90f));
			newCoin.name = $"Coin {i}";
			coinList.Add(newCoin.GetComponent<Coin>());
		}
	}
	void Update() {
		countInformation.text = _coinCount.ToString();
	}

	public void RemoveCoin(Coin coin) {
		coinList.Remove(coin);
		Destroy(coin.gameObject);
	}
	public Coin GetClosest(Vector3 point) {
		float minDistance = Mathf.Infinity;
		Coin closestCoin = null;
		for(int i = 0; i < coinList.Count; i++) {
			float distance = Vector3.Distance(point, coinList[i].transform.position);
			if(distance < minDistance) {
				minDistance = distance;
				closestCoin = coinList[i];
			}
		}
		return closestCoin;
	}


	public void IncrementCoinCount() {
		_coinCount++;
	}
}
