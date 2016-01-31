using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

public class DocketDecisionDefinition : DecisionDefinition {
	public Organization org;
	public char personType;
	public string name;
}

public class DocketDecision : Decision {

	public GameObject dialogPrefab;
	public GameObject characterPrefab;
	public Button accept;

	GameObject dialog;
	GameObject character;


	new public DocketDecisionDefinition definition {
		get {
			return (DocketDecisionDefinition)base.definition;
		}
	}

	public void Start() {
		accept.onClick.AddListener (() => acceptClick ());
	}

	void acceptClick() {
		accept.interactable = false;
		//put away the docet
		ObjectInteraction interaction = GetComponent<ObjectInteraction> ();
		interaction.Defocus ();

		Debug.Log("Accepting click...");
		//create a character thing
		character = Instantiate (characterPrefab);
		dialog = Instantiate (dialogPrefab);
		dialog.GetComponent<Document> ().SetBody (definition.title);
		Button[] buttons = dialog.GetComponentsInChildren<Button> ();
		if(buttons.Count() != 3) {
			Debug.Log ("Why are there not 3 buttons on docet dialog children?");
		}
		for(int i = 0; i < 3; ++i){
			buttons[i].gameObject.GetComponentInChildren<Text> ().text = definition.options[i].description;
			buttons[i].onClick.AddListener (() => ButtonClicked (i));
		}
	}

	public void CharacterLeave() {
		//TODO make character leave and destroy when finished
	}

	public void ButtonClicked(int index) {
		Destroy (dialog);
		CharacterLeave ();
		choice = definition.options [index];
	}
		
	public void Define(DocketDecisionDefinition def, Dictionary<string, string> values) {
		base.Define (def, values);
		GenerateProfile();
	}

	public void GenerateProfile () {
		Document doc = GetComponent<Document> ();
		definition.name = StringListReader.GetRandom ("PersonName");
		doc.SetTitle (definition.name);
		List<string> attribs = new List<string> ();
		attribs.Add("Representing: " + definition.org.name);
		attribs.Add("Eye Color: " + StringListReader.GetRandom("Color"));
		attribs.Add("Hair Color: " + StringListReader.GetRandom("Color"));
		attribs.OrderBy<string, float> ((string item) => UnityEngine.Random.value);
		string body = "";
		foreach(string attrib in attribs) {
			body += attrib + "\n";
		}
		doc.SetBody (body);
	}
}