using UnityEngine;
using System.Collections.Generic;

public class DayController : MonoBehaviour {

	public Transform newspaperRoot;
	public Vector3 newspaperDelta;
	public Transform docetRoot;
	public Vector3 docetDelta;
	public Transform memoRoot;
	public Vector3 memoDelta;

	public DecisionSet decisionSet { get; private set; }

	DayController() {
	}

	public void Populate(DecisionSet decisions) {
		decisionSet = decisions;

		Vector3 d = newspaperDelta;
		foreach( GameObject paper in decisions.newspapers ) {
			paper.transform.SetParent (newspaperRoot);
			paper.transform.position = newspaperRoot.position;
			paper.transform.position += d;
			d += newspaperDelta;
		}

		d = memoDelta;
		foreach( GameObject memo in decisions.memos ) {
			memo.transform.SetParent (memoRoot);
			memo.transform.position = memoRoot.position;
			memo.transform.position += d;
			d += memoDelta;
		}

		d = docetDelta;
		foreach( GameObject docet in decisions.docets ) {
			docet.transform.SetParent (docetRoot);
			docet.transform.position = docetRoot.position;
			docet.transform.position += d;
			d += docetDelta;
		}
	}
}
