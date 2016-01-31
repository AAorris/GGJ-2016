using UnityEngine;
using System.Collections;

public class ClickSender : MonoBehaviour {

	ObjectInteraction m_interactions;

	RaycastHit hit;
    Ray ray;

	public bool k_negate = false;
	public bool m_clickedon = false;
	public GameObject m_target;

	void Reset () {
		m_interactions = m_target.GetComponent<ObjectInteraction>();
	}

	void Start() {
		Reset();
	}

	void Update() {
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		m_clickedon = false;
		Physics.Raycast(ray, out hit, Mathf.Infinity);
		foreach (Collider collider in m_interactions.Colliders()) {
			if (hit.collider == collider)
				m_clickedon = true;
		}

		if (Input.GetMouseButtonDown(0) && !k_negate && !m_clickedon)
            m_interactions.Defocus();
	}

	void OnMouseDown () {
		if (k_negate)
			m_interactions.Defocus();
		else
			m_interactions.Focus();
	}
}
