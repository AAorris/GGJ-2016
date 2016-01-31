using UnityEngine;
using System.Collections;

public class ObjectInteraction : MonoBehaviour {

	RaycastHit hit;
    Ray ray;

    public float k_damping = 0.025f;

	public Animator m_anim;
	public GameObject m_root;
	public Collider[] m_childcolliders;
	public Transform m_focalpoint;
	public Vector3 m_restpos;
	public Quaternion m_restrot;
	public bool m_focused;

	// Use this for initialization
	void Reset () {
		m_restpos = transform.position;
		m_restrot = transform.rotation;
		m_root = transform.Find("Root").gameObject;
		m_anim = m_root.GetComponent<Animator>();
		m_focalpoint = GameObject.Find("FocalPoint").transform;
		m_childcolliders = (m_root.GetComponentsInChildren<Collider>());
						   // .gameObject.GetComponent<Collider>());
		m_focused = false;
	}

	void Start () {
		Reset();
	}
	
	// Update is called once per frame
	void Update () {
		if (m_focused == true) {
			transform.position = Vector3.Lerp(
				transform.position,
				m_focalpoint.position,
				k_damping);
			transform.rotation = Quaternion.Lerp(
				transform.rotation,
				m_focalpoint.rotation,
				k_damping);
		} else {
			transform.position = Vector3.Lerp(
				transform.position,
				m_restpos,
				k_damping);
			transform.rotation = Quaternion.Lerp(
				transform.rotation,
				m_restrot,
				k_damping);
		}
	}

	public Collider[] Colliders() {
		return m_childcolliders;
	}

	public void Focus () {
		Debug.Log("Clicked.");
		m_focused = true;
		m_anim.SetBool("focused", m_focused);
	}

	public void Defocus () {
		Debug.Log("Clicked negation.");
		m_focused = false;
		m_anim.SetBool("focused", m_focused);
	}
}
