using UnityEngine;
using System.Collections;
using System.Linq;

public class ScoreController : MonoBehaviour
{

	byte maxScore;

	DigitController[] digits;
	byte previousScore = 88;

	// Use this for initialization
	void Start () {
		this.digits = GetComponentsInChildren<DigitController> ().OrderBy (d => d.digitPlace).ToArray ();

		if (this.digits.Length == 3)
			maxScore = byte.MaxValue;
		else if (this.digits.Length == 2) 
			maxScore = 99;
		else 
			maxScore = 9;


	}

	private const byte DigitSlice = 10;

	// Update is called once per frame
	void Update ()
	{
		if (currentScore > maxScore) {
			throw new System.ArgumentOutOfRangeException("currentScore");
		}

		if (this.currentScore != this.previousScore) {
			byte remainingDigitValues = this.currentScore;

			for (int digit = 1; digit <= digits.Length; digit++) {
				var digitController = this.digits[digit - 1];

				byte currDigit = (byte)(remainingDigitValues % DigitSlice);
				remainingDigitValues -= currDigit;
				remainingDigitValues /= DigitSlice;

				digitController.digitValue = currDigit;

			}

			this.previousScore = this.currentScore;
		}
	}

	public byte currentScore = 88;
	public Character Character = Character.Player;
}

