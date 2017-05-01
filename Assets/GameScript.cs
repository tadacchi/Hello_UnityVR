using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {
	public Camera mainCamera;
	public float moveSpeed  = 2.0f;
	public float moveAngleX = 20.0f;

	float yOffset;

	// Use this for initialization
	void Start () {
		yOffset = mainCamera.transform.position.y;
	}

	// Update is called once per frame
	void Update () {

		// 1.カメラの傾きを取得
		float x = mainCamera.transform.eulerAngles.x;
		Debug.Log (x);

		// 2.ある角度以内であれば前進させる
		if (moveAngleX < x && x < 90.0f) {
			moveFoward ();
		}
	}

	private void moveFoward() {
		Vector3 direction = new Vector3 (mainCamera.transform.forward.x, 0, mainCamera.transform.forward.z).normalized * moveSpeed * Time.deltaTime;
		Quaternion rotation = Quaternion.Euler (new Vector3 (0, -mainCamera.transform.rotation.eulerAngles.y, 0));
		mainCamera.transform.Translate (rotation * direction);
		mainCamera.transform.position = new Vector3 (mainCamera.transform.position.x, yOffset, mainCamera.transform.position.z);
	}
}