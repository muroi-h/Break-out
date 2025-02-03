using UnityEngine;
using UnityEngine.SceneManagement;

public class C02_StageScene : MonoBehaviour {
	private	C03_Score		c03_Score;
	private C11_Ball		c11_Ball;
	public	GameObject[]	prefab;						// ブロックのプレハブ格納要.
	
	static private int		stage_no	= 1;
	private	bool			gameClear	= false;		// クリアフラグ.
	public	bool			gameOver	= false;		// ゲームオーバーフラグ.
	private float			spd_timer	= 0.0f;
	public	GUIStyle		gui_gameClear;				// ゲームクリア用のGUIStyle.
	
	void Start(){
		c03_Score	= GetComponent<C03_Score>();
		c11_Ball	= GameObject.Find("Ball").GetComponent<C11_Ball>();
		switch(stage_no){
		case 1:	blockSetting(); break;		// ステージ１のブロックの配置.
		case 2: blockSetting(); break;		// ステージ２のブロックの配置.
		}
	}
	
	void Update(){
		if(gameClear){
			if(Input.GetMouseButtonDown(0)){
				stage_no++;
				if(stage_no < 3){
					SceneManager.LoadScene(stage_no);
				}else{
					SceneManager.LoadScene("ending");
				}
			}
			return;		// フラグが立っている時、Update()関数を強制終了。
		}
		
		if(gameOver){
			if(Input.GetMouseButtonDown(0)){
				stage_no = 1;				// ステージNoの初期化.
				c03_Score.Reset_score();	// スコアの初期化.
				SceneManager.LoadScene(0);	// タイトルへ.
			}
			return;		// フラグが立っている時、Update()関数を強制終了。
		}
		
		spd_timer += Time.deltaTime;	// 時間経過で値を増やしていく.
		
		if(spd_timer > 1.0f){			// １秒以上なら.	
			c11_Ball.spdUp();			// ボールの速度アップ
			spd_timer = 0.0f;			// 時間初期化.
		}
	}
	
	//■■■ブロックの配置■■■■■■■■■■■■■■■■■■■■■■■■■
	private void blockSetting(){
		for(int i=0 ; i<4 ; i++){
			// プレハブの作成.
			GameObject block_right1 = GameObject.Instantiate(prefab[0]) as GameObject;
			GameObject block_right2 = GameObject.Instantiate(prefab[1]) as GameObject;
			GameObject block_right3 = GameObject.Instantiate(prefab[2]) as GameObject;
			GameObject block_left1  = GameObject.Instantiate(prefab[0]) as GameObject;
			GameObject block_left2  = GameObject.Instantiate(prefab[1]) as GameObject;
			GameObject block_left3  = GameObject.Instantiate(prefab[2]) as GameObject;
			// プレハブの配置.
			block_right1.transform.position = new Vector3( 3.0f + (5*i) , 19.0f , 0.0f);
			block_right2.transform.position = new Vector3( 3.0f + (5*i) , 21.0f , 0.0f);
			block_right3.transform.position = new Vector3( 3.0f + (5*i) , 23.0f , 0.0f);
			block_left1.transform.position  = new Vector3(-3.0f - (5*i) , 19.0f , 0.0f);
			block_left2.transform.position  = new Vector3(-3.0f - (5*i) , 21.0f , 0.0f);
			block_left3.transform.position  = new Vector3(-3.0f - (5*i) , 23.0f , 0.0f);
		}
	}
	
	//■■■クリア判定(ブロックが残っているかを確認する)■■■■■■■■■■■■■■■■■■■■■■■■■
	public bool checkBlockAll(){
		if((GameObject.FindWithTag("Block01") == null) && (GameObject.FindWithTag("Block02") == null) && (GameObject.FindWithTag("Block03") == null)){
			gameClear = true;								// ブロックが見つからない場合、クリアフラグを立てる
		}
		return gameClear;
	}
	
	//■■■■■■■■■■■■■■■■■■■■■■■■■■■■
	public void stageNo_clear(){
		stage_no = 1;
	}
	
	//■■■GUI■■■■■■■■■■■■■■■■■■■■■■■■■
	void OnGUI(){
		// ▲▲▲クリアフラグがたっていたら、ラベル表示.▲▲▲
		if(gameClear){	GUI.Label(new Rect(0 , 0 , Screen.width , Screen.height) , "GameClear" , gui_gameClear);	}
		// ▲▲▲ゲームオーバーフラグがたっていたら、ラベル表示.▲▲▲
		if(gameOver){	GUI.Label(new Rect(0 , 0 , Screen.width , Screen.height) , "GameOver" , gui_gameClear);		}
	}
	
}
