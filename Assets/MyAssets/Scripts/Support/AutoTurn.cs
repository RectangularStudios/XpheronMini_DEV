using UnityEngine;
using System.Collections;

public class AutoTurn : MonoBehaviour {
	public float xSpeed = 1f;
	public float ySpeed = 1f;
	public float zSpeed = 1f;

	void Update()
	{
		transform.Rotate(
			xSpeed * Time.deltaTime,
			ySpeed * Time.deltaTime,
			zSpeed * Time.deltaTime
			);
	}
}
