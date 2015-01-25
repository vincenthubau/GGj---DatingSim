using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour {
	[SerializeField]
	private string m_name;
	public Slider affectionSlider;
	//4 Sprites : Neutral, happy, sad and angry
	public Sprite[] characterExpressions;
	//3 SPrites : Date1, Date2, Date3
	public Sprite[] backgroundImages;
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
	private float m_affection = 0;
	public float affection
	{
		get {return m_affection; }
	}
	
	public void AddAffection(float amount) {
		m_affection += amount;
		affectionSlider.value = m_affection /100;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
