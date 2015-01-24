using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {
	[SerializeField]
	private string m_name;
	public string name
	{
		get {return m_name; }
	}

	[SerializeField]
	private int m_dialogId;
	public int dialogId
	{
		get {return m_dialogId; }
		set {m_dialogId = value; }
	}

	[SerializeField]
	private int m_affection;
	public int affection
	{
		get {return m_affection; }
	}
	
	public void AddAffection(int amount) {
		m_affection += amount;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
