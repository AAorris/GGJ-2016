using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Document : MonoBehaviour {

	public UnityEngine.UI.Text document_title;
	public UnityEngine.UI.Text document_body;
	public string m_title = "TitleText";
	public string m_body = "BodyText";

	// Use this for initialization
	void Start () {
		SetTitle(m_title);
		SetBody(m_body);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetTitle(string text) {
		m_title = text;
		document_title.text = text;
	}

	public void SetBody(string text) {
		m_body = text;
		document_body.text = text;
	}
}
