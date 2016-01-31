using UnityEngine;
using System;

[System.Serializable]
public class GameState : MonoBehaviour {

	[System.NonSerialized]
	public Organization player;

	[System.NonSerialized]
	public int followers = 0;

	public City[] cities;
	//public List<Organization> corporations;

	public void Start() {
		player = gameObject.AddComponent<Organization>();
	}

	//returns change in followers
	public int RecalculateFollowers() {
		int newAmount = 0;
		foreach(City city in cities) {
			int alignment = city.Alignment (player);
			int population = (int)((alignment + 100) * 0.05f * city.population);
			newAmount += population;
		}
		int delta = followers - newAmount;
		followers = newAmount;
		return delta;
	}
}
