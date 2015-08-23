using UnityEngine;
using System.Collections.Generic;

public class DigitController : MonoBehaviour
{

	LightController top, topLeft, topRight, middle, bottomLeft, bottomRight, bottom;
	HashSet<LightController>[] lightMap;

	float lastDigitValue = 8;

	// Use this for initialization
	void Start ()
	{
		if (digitPlace > 3 || digitPlace < 1) {
			throw new System.ArgumentOutOfRangeException("digitPlace");
		}

		foreach (LightController lightObject in GetComponentsInChildren<LightController>()) {
			switch (lightObject.digitLight) {
			case LightController.DigitLight.Top:
				this.top = lightObject;
				break;
			case LightController.DigitLight.TopLeft:
				this.topLeft = lightObject;
				break;
			case LightController.DigitLight.TopRight:
				this.topRight = lightObject;
				break;
			case LightController.DigitLight.Middle:
				this.middle = lightObject;
				break;
			case LightController.DigitLight.BottomLeft:
				this.bottomLeft = lightObject;
				break;
			case LightController.DigitLight.BottomRight:
				this.bottomRight = lightObject;
				break;
			case LightController.DigitLight.Bottom:
				this.bottom = lightObject;
				break;
			}
		}

		lightMap = new HashSet<LightController>[] {
			/* 0   */ new HashSet<LightController>() { top, topLeft, topRight, bottomLeft, bottomRight, bottom }
			/* 1 */ , new HashSet<LightController>() { topRight, bottomRight }
			/* 2 */ , new HashSet<LightController>() { top, topRight, middle, bottomLeft, bottom }
			/* 3 */ , new HashSet<LightController>() { top, topRight, middle, bottomRight, bottom }
			/* 4 */ , new HashSet<LightController>() { topLeft, topRight, middle, bottomRight }
			/* 5 */ , new HashSet<LightController>() { top, topLeft, middle, bottomRight, bottom }
			/* 6 */ , new HashSet<LightController>() { top, topLeft, middle, bottomLeft, bottomRight, bottom }
			/* 7 */ , new HashSet<LightController>() { top, topRight, bottomRight }
			/* 8 */ , new HashSet<LightController>() { top, topLeft, topRight, middle, bottomLeft, bottomRight, bottom }
			/* 9 */ , new HashSet<LightController>() { top, topLeft, topRight, middle, bottomRight }
		};
	}

	// Update is called once per frame
	void Update ()
	{
		if (digitValue > 9)
			throw new System.ArgumentOutOfRangeException("digitValue");

		if (lastDigitValue != digitValue) {

			var map = lightMap[digitValue]; // get set of lights that should be on

			foreach (var l in GetAllLights()) {
				l.on = map.Contains(l);
			}

			this.lastDigitValue = digitValue;
		}
	}

	private IEnumerable<LightController> GetAllLights() {
		yield return top;
		yield return topLeft;
		yield return topRight;
		yield return middle;
		yield return bottomLeft;
		yield return bottomRight;
		yield return bottom;
	}

	public byte digitValue = 8;
	public byte digitPlace = 1;
}