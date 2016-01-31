using UnityEngine;
using System.Collections.Generic;

public class DecisionSet {
	public List<GameObject> newspapers = new List<GameObject> ();
	public List<GameObject> memos = new List<GameObject> ();
	public List<GameObject> docets = new List<GameObject> ();

	public void Destroy() {
		foreach( GameObject paper in newspapers ) {
			Object.Destroy (paper);
		}

		foreach( GameObject memo in memos ) {
			Object.Destroy (memo);
		}

		foreach( GameObject docet in docets ) {
			Object.Destroy (docet);
		}
	}

}
