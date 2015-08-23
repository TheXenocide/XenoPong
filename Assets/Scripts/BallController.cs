using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{
	public Rigidbody Ball { get; private set; }
	GameController game;

	// Use this for initialization
	void Start ()
	{
		this.game = GetComponentInParent<GameController> ();
		this.Ball = GetComponent<Rigidbody> ();

		Respawn ();

	}

	void Update() {
		if (game.GameOver)
			return;

		if (this.Ball.position.y < -2.0f) {
			if (this.Ball.position.x < -3) {
				this.game.OpponentScore++;
			} else {
				this.game.PlayerScore++;
			}
			Respawn();
		}
	}

	public void Respawn() 
	{
		if (game.GameOver)
			return;

		this.Ball.velocity = new Vector3 ();
		this.Ball.position = new Vector3 (-3, 0.01f, 4);

		if (randomInitialSpeed) {
			this.initialSpeed = new Vector2(Random.Range(minimumInitialSpeed.x, maximumInitialSpeed.x), Random.Range(minimumInitialSpeed.y, maximumInitialSpeed.y));
		}
		
		if (randomInitialVector) {
			var randCircle = Random.insideUnitCircle;
			
			this.initialVector = new Vector3(randCircle.x * initialSpeed.y, 0, randCircle.y * initialSpeed.y);
		}
		
		this.Ball.velocity = this.initialVector;
	}

	#region Designer Properties

	public Vector2 initialSpeed;
	public Vector3 initialVector;

	public bool randomInitialSpeed;
	public Vector2 minimumInitialSpeed = new Vector2(0.1f, 0.1f);
	public Vector2 maximumInitialSpeed = new Vector2(5.0f, 5.0f);

	public bool randomInitialVector; 

	#endregion

}