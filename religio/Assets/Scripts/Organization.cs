using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class Organization : MonoBehaviour
{
	static System.Random rand = new System.Random ((int)DateTime.Now.Ticks);

	new public string name = "default org name";
	public DictionaryTopicInt m_stances;

	public Organization ()
	{
		m_stances = new DictionaryTopicInt();
		foreach(Topic t in Enum.GetValues(typeof(Topic))){
			m_stances [t] = 0;
		}
	}

	public void Randomize() {
		foreach(Topic t in Enum.GetValues(typeof(Topic))) {
			SetStance (t, rand.Next (200) - 100);
		}
	}

	public int GetStance(Topic topic) {
		return m_stances [topic];
	}

	public void SetStance(Topic topic, int value) {
		m_stances [topic] = Math.Min(100, Math.Max(-100, value));
	}

	public int ChangeStance(Topic topic, int delta) {
		int value = GetStance (topic) + delta;
		SetStance (topic, value);
		return value;
	}

	//returns the amount that the input value is aligned
	//to the state of this organization
	public int Alignment(Topic topic, int compareWith) {
		//simple delta for now
		//get the delta, then map to -100 - 100
		int delta = Math.Abs(GetStance (topic) - compareWith);
		return -(delta * 2) + 100;
	}

	//return the aligment between two organizations
	public int Alignment(Organization org) {
		//just the average of all alignments
		int sum = 0;
		Array topics = Enum.GetValues(typeof(Topic));
		foreach(Topic t in topics){
			sum += Alignment(t, org.GetStance(t));
		}
		return sum / topics.Length;
	}

	public override string ToString() {
		return (name + ":" + 
			" Culture: " + 	m_stances[Topic.Culture] +
			" Diplomacy: " + m_stances[Topic.Diplomacy] +
			" Education: " + m_stances[Topic.Education] +
			" Enterprise: "+ m_stances[Topic.Enterprise] +
			" Freedom: " +	m_stances[Topic.Freedom] +
			" Welfare: " + 	m_stances[Topic.Welfare]
		);
		
	}
}
