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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
