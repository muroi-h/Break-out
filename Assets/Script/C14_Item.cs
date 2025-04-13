using UnityEngine;
using System.Collections;

public class C14_Item : MonoBehaviour
{
	void Update()
	{
		transform.Rotate(Vector3.up * 90 * Time.deltaTime); // Y方向に１秒で90度回転させる.

		if (transform.position.y < -1.0f)
		{
			// Y位置が-1未満になったら
			Destroy(gameObject); // アイテムを削除.
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			// 衝突した相手のタグ名がplayerなら
			other.transform.root.SendMessage("getItem01"); // 衝突した相手に、getItem01()関数の実行命令を送る.
			Destroy(gameObject); // アイテムを削除.
		}
	}
}
