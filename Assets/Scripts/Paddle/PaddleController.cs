using UnityEngine;
using System.Collections;

public abstract class PaddleController : MonoBehaviour {

	#region Private Fields

	protected Rigidbody paddle;
	protected GameController game;

	#endregion

	// Use this for initialization
	void Start ()
	{
		this.paddle = GetComponent<Rigidbody> ();
		this.game = GetComponentInParent<GameController> ();
	}

	#region Public Properties

	public abstract Character Character { get; }

	#endregion
	
	#region Designer Properties
	
	public float Speed;
	
	public Vector2 speedMultiplier = new Vector2(1.1f, 1.1f);
	
	#endregion

	void FixedUpdate ()
	{
		if (this.game.GameOver) {
			paddle.velocity = new Vector3();
			return;
		}

		var inputDir = GetInputDirection ();
		
		paddle.AddForce (new Vector3 (0, 0, inputDir * this.Speed));
	}

	protected abstract float GetInputDirection ();

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "Ball")
		{
			var ball = col.gameObject.GetComponent<BallController>().Ball;
			ball.velocity = new Vector3(ball.velocity.x * speedMultiplier.x, ball.velocity.y, ball.velocity.z * speedMultiplier.y);
		}
	}

}
