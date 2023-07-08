using UnityEngine;
using UnityEngine.SceneManagement;

public class C90_Ending : MonoBehaviour {
	private C02_StageScene c02_stageScene;
	private	C03_Score	c03_Score;
	private float		step_timer = 0.0f;
	
	void Start(){
		c02_stageScene = GetComponent<C02_StageScene>();	// 自分自身のいるブジェクト内から、スクリプトを代入。
		c02_stageScene.stageNo_clear();
		c02_stageScene.enabled = false;
		
		c03_Score = GetComponent<C03_Score>();	// 自分自身のいるブジェクト内から、スクリプトを代入。
		c03_Score.GameClear_score();			// ゲームクリア処理.
	}
	
	void Update () {
		step_timer += Time.deltaTime;
		
		if(step_timer > 120.0f){			// ５秒たったら
			c03_Score.Reset_score();		// スコアをクリア.
			SceneManager.LoadScene(0);		// タイトルシーンに移動.
		}
	}
}
