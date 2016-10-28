using UnityEngine;
using System.Collections;

public class IntBars : MonoBehaviour {

	public float Stat = 1;
	public float maxStat = 1;

	public float stage1 = 0;
	public float stage2 = 0;
	public float stage3 = 0;
	public float stage4 = 0;

	public Transform TargetPlayer;

	void Start () {
		stage1 = Stat * 0.8f;
		stage2 = Stat * 0.6f;
		stage3 = Stat * 0.4f;
		stage4 = Stat * 0.2f;
	}

	void Update () {


		Quaternion rotation = Quaternion.LookRotation(TargetPlayer.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 50f);

		if (Input.GetKeyDown ("f") && Stat > 0) {
			Stat -= 20;
		}

		if (Stat < 0) {
			Stat = 0;
		}



		if (Stat < stage1) { transform.localScale = new Vector3(0.8F, 1, 1); }
		if (Stat < stage2) { transform.localScale = new Vector3(0.6F, 1, 1); }
		if (Stat < stage3) { transform.localScale = new Vector3(0.4F, 1, 1); }
		if (Stat < stage4) { transform.localScale = new Vector3(0.2F, 1, 1); }
		if (Stat <= 0) { transform.localScale = new Vector3(0F, 1, 1); }

		if (Stat > stage1) { transform.localScale = new Vector3(1F, 1, 1); }
		if (Stat > stage2 && Stat < stage1) { transform.localScale = new Vector3(0.8F, 1, 1); }
		if (Stat > stage3 && Stat < stage2 && Stat < stage1) { transform.localScale = new Vector3(0.6F, 1, 1); }
		if (Stat > stage4 && Stat < stage3 && Stat < stage2 && Stat < stage1) { transform.localScale = new Vector3(0.4F, 1, 1); }

	}

	void AddStat () {
		stage1 = Stat * 0.8f;
		stage2 = Stat * 0.6f;
		stage3 = Stat * 0.4f;
		stage4 = Stat * 0.2f;
	}
}
