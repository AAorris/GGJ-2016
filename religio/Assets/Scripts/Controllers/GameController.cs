using System;
using UnityEngine;

[System.Serializable]
public class GameController : MonoBehaviour {

	public PrefabList prefabs;
	public GameState state;
	public DayController dayController;
	public SceneController sceneController; 

	public int dayLengthSeconds = 30;

	float dayStart;
	bool isDay = false;

	GameController() {
	}

	public void Start() {
	}

	public void Update() {

		if (!isDay) {
			StartNextDay ();
		}

		if(Time.time > dayStart + dayLengthSeconds) {
			EndDay ();
		}
	}

	public void StartNextDay() {

		//generate the decisions based on the current game state
		DecisionSet decisions = GenerateDecisionSet ();
		dayController.Populate (decisions);

		//hide the map view / change to day
		sceneController.ShowDay ();

		isDay = true;
		dayStart = Time.time;
	}

	public void EndDay() {

		//TODO update the game state based on the decision set actions
		dayController.decisionSet.Destroy ();
		sceneController.ShowNight ();
		isDay = false;
	}

	DecisionSet GenerateDecisionSet() {
		DecisionSet set = new DecisionSet ();
		//TODO newspapers
		foreach(NewspaperDecision decision in prefabs.paperDecisions) {
			GameObject paper = Instantiate (prefabs.newspaper);
			paper.GetComponent<NewspaperDecision>().Copy(decision);
			set.newspapers.Add (paper);
		}

		//TODO docets
		//TODO memos
		return set;
	}
}
