using UnityEngine;
using System.Collections;

public class C11_Ball : MonoBehaviour
{
	private AudioSource audioSource;
	public AudioClip sound;
	private C02_StageScene c02_StageScene;
	private float basicSPD = 20.0f; // 基本速度.
	public float addSPD = 0.0f; // 追加速度.
	private float max_addSPD = 25.0f; // 最大追加速度.

	void Start()
	{
		audioSource = gameObject.AddComponent<AudioSource>(); // AudioSorceコンポーネントを追加し、変数に代入.
		audioSource.clip = sound; // 鳴らす音(変数)を格納.
		audioSource.loop = false; // 音のループなし。
		c02_StageScene = GameObject.Find("GameRoot").GetComponent<C02_StageScene>(); // 『GameRoot』オブジェクトを探し、そのオブジェクトが持っているスクリプトを代入。

		Vector3 v = new Vector3(1.0f, 1.0f, 0.0f);
		v.Normalize();
		transform.GetComponent<Rigidbody>().velocity = v * basicSPD;
		StartCoroutine("checkPos");
	}

	/// <summary>
	/// 衝突判定
	/// </summary>
	void OnCollisionEnter(Collision other)
	{
		velocityCtrl(); // 速度調整.
		audioSource.Play(); // 音を鳴らす.

		StartCoroutine("checkBlock"); // ブロックの確認。
	}

	/// <summary>
	/// ボール位置確認
	/// </summary>
	IEnumerator checkPos()
	{
		while (true)
		{
			yield return new WaitForSeconds(1.0f); // 1秒間、処理を待機.

			if (transform.position.y < -1.0f)
			{
				c02_StageScene.gameOver = true; // ゲームオーバーフラグをたてる.
				transform.GetComponent<Rigidbody>().velocity = Vector3.zero; // ボールの速度をゼロにする.
				break; // ループを強制的に抜ける.
			}
		}
	}

	/// <summary>
	/// ブロック走査
	/// </summary>
	IEnumerator checkBlock()
	{
		yield return new WaitForSeconds(0.1f); // 0.1秒間、処理を待機.

		if (c02_StageScene.checkBlockAll())
		{
			// ブロック確認 (関数を呼びだし、trueが返ってきたらカッコ内を実行)
			transform.GetComponent<Rigidbody>().velocity = Vector3.zero; // ボールの速度をゼロにする.
		}
	}

	/// <summary>
	/// 速度調整
	/// </summary>
	private void velocityCtrl()
	{
		Vector3 v = transform.GetComponent<Rigidbody>().velocity; // 速度を取得.

		if (-3.0f < v.x && v.x <= 0.0f)
		{
			// Xの速度が-3～0なら、Xの値を -3.0f に.
			v.x = -3.0f;
		}
		else if (0.0f < v.x && v.x < 3.0f)
		{
			// Xの速度が0～3なら、Xの値を +3.0f に.
			v.x = 3.0f;
		}

		if (-10.0f < v.y && v.y <= 0.0f)
		{
			// Yの速度が-10～0なら、Yの値を -10.0f に.
			v.y = -10.0f;
		}
		else if (0.0f < v.y && v.y < 10.0f)
		{   // Yの速度が0～10なら、 Yの値を +10.0f に.
			v.y = 10.0f;
		}

		v.Normalize(); // ボールの速度を一旦１に戻す.
		v *= basicSPD + addSPD; // 速度をn倍にする.

		transform.GetComponent<Rigidbody>().velocity = v; // 値を反映.
	}

	/// <summary>
	/// 自機のスピードアップ処理
	/// </summary>
	public void spdUp()
	{
		if (addSPD < max_addSPD)
		{
			addSPD += 0.1f;
		}
	}
}
