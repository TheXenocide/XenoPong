using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour {

	MeshRenderer self;

	// Use this for initialization
	void Start () {
		this.self = GetComponent<MeshRenderer> ();

	}
	
	// Update is called once per frame
	void Update () {
		this.self.enabled = this.on;
	}

	public bool on = true;
	public DigitLight digitLight;

	public enum DigitLight {
		Middle = 0,
		Top = 1,
		Bottom = 2,
		Left = 4, 
		Right = 8,
		TopLeft = Top | Left,
		TopRight = Top | Right,
		BottomLeft = Bottom | Left,
		BottomRight = Bottom | Right
	}
}
