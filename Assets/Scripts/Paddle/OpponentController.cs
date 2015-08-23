using UnityEngine;
using System.Collections;

public class OpponentController : PaddleController {

	public override Character Character {
		get {
			return Character.Opponent;
		}
	}

	protected override float GetInputDirection ()
	{
		var heading = game.Ball.Ball.position - this.paddle.position;
		var distance = heading.magnitude;
		var direction = heading / distance;
		return direction.z;
	}
}
