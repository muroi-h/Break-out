using UnityEngine;
using System.Collections;

public class C12_Bar : MonoBehaviour {
	private struct KEY{			// 自作の構造体 KEYを作成
		public bool left;
		public bool right;
		public bool moveUp;
	}
	private KEY		key;			// KEY型の変数　keyを作成.
	
	private float	LIMIT_XL	= -18.5f;		// 左側の移動リミット.
	private float	LIMIT_XR	= 18.5f;		// 右側の移動リミット.
	private int		spd			= 10;			// 速度
	
	void Update () {
		getKyeInput();		// キー情報の取得.
		setSpd();			// 速度調整.
		
		if(key.left && transform.position.x > LIMIT_XL){
			transform.position += Vector3.left * spd * Time.deltaTime;
		}
		
		if(key.right && transform.position.x < LIMIT_XR){
			transform.position += Vector3.right * spd * Time.deltaTime;
		}
	}
	
	// ■■■キー処理■■■
	private void getKyeInput(){
		// 関数が呼び出されたら、値を全てfalseにする。
		key.left	= false;
		key.right	= false;
		key.moveUp	= false;
		
		// 特定のキーが押されたら、その値を格納する。
		key.left	|= Input.GetKey(KeyCode.LeftArrow);		// ←
		key.left	|= Input.GetKey(KeyCode.A);				// Ａ
		key.left	|= Input.GetKey(KeyCode.Keypad4);		// テンキー４
		key.left	|= Input.GetMouseButton(0);				// 左クリック
		
		key.right	|= Input.GetKey(KeyCode.RightArrow);	// →
		key.right	|= Input.GetKey(KeyCode.D);				// Ｄ
		key.right	|= Input.GetKey(KeyCode.Keypad6);		// テンキー６
		key.right	|= Input.GetMouseButton(1);				// 右クリック
		
		key.moveUp	|= Input.GetKey(KeyCode.LeftShift);		// 左シフト
		key.moveUp	|= Input.GetKey(KeyCode.RightShift);	// 右シフト
	}
	
	// ■■■速度アップ用キーによる、基本速度変更■■■
	private void setSpd(){
		if(!key.moveUp){
			spd = 35;
		}else{
			spd = 40;
		}
	}
	
	// ■■■アイテム取得時、コルーチン開始■■■
	private void getItem01(){
		StartCoroutine("item01");
	}
	
	// ■■■アイテム取得時の処理■■■
	IEnumerator item01(){
		transform.localScale += Vector3.up;		// Y方向にサイズを＋１する.
		LIMIT_XL += 1.0f;		// 左側のリミットを＋１する。
		LIMIT_XR -= 1.0f;		// 右側のリミットを－１する。
		
		yield return new WaitForSeconds(10.0f);	// 10秒間、処理を待機.
		
		transform.localScale -= Vector3.up;		// Y方向にサイズを－１する.
		LIMIT_XL -= 1.0f;		// 左側のリミットを－１する。
		LIMIT_XR += 1.0f;		// 右側のリミットを＋１する。
	}
	
}