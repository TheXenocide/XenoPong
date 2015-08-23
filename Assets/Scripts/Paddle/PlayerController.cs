using UnityEngine;
using System.Collections;

public class PlayerController : PaddleController
{
	public override Character Character {
		get {
			return Character.Player;
		}
	}

	protected override float GetInputDirection ()
	{
		var vert = Input.GetAxis ("Vertical");

		if (vert == 0.0f && SystemInfo.deviceType == DeviceType.Handheld && !Application.isWebPlayer) {

			Debug.Log(Input.acceleration);
			vert = (0.4f + Input.acceleration.y) * 8.0f;
			if (vert > 1.5f) vert = 1.5f;
			if (vert <-1.5f) vert = -1.5f;
		}

		return vert;
	}
	
}
