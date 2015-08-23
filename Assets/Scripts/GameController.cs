using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GameController : MonoBehaviour {

	
	private ScoreController playerScore;
	private ScoreController opponentScore;
	private bool touchHeld;

	public byte PlayerScore { get; set; }
	public byte OpponentScore { get; set; }

	// Use this for initialization
	void Start () {
		this.Ball = this.GetComponentInChildren<BallController> ();

		var paddles = this.GetComponentsInChildren<PaddleController> ();
		this.Player = paddles.Single (p => p.Character == Character.Player);
		this.Opponent = paddles.Single (p => p.Character == Character.Opponent);

		var scores = this.GetComponentsInChildren<ScoreController> ();
		this.playerScore = scores.Single (s => s.Character == Character.Player);
		this.opponentScore = scores.Single (s => s.Character == Character.Opponent);
	}
	
	// Update is called once per frame
	void Update () {
		this.playerScore.currentScore = this.PlayerScore;
		this.opponentScore.currentScore = this.OpponentScore;

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
			return;
		}

		if (Input.touchCount > 0 || Input.GetKeyDown (KeyCode.Return)) {
			touchHeld = true;
		} else if (touchHeld) {
			touchHeld = false;
			Reset();
		}
	}

	private void Reset() {
		if (this.GameOver) {
			this.PlayerScore = this.OpponentScore = 0;
		}
		this.Ball.Respawn ();
	}

	public bool GameOver { get { return this.PlayerScore == this.winningScore || this.OpponentScore == this.winningScore; } }

	#region Game Objects

	public BallController Ball { get; private set; }

	public PaddleController Player { get; private set; }
	public PaddleController Opponent { get; private set; }

	#endregion

	#region Designer Properties

	public byte winningScore = 20;

	#endregion
}

public enum Character : byte
{
	Player = 0,
	Opponent = 1
}
