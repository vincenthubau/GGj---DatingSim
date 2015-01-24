using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {
	[SerializeField]
	private int m_npcId;
	public int npcId
	{
		get {return m_npcId; }
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
