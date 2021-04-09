using UnityEngine;
using System.Collections;

public class C13_Block : MonoBehaviour {
	private C03_Score c03_score;
	private int hp;					// ブロックの体力.
	public GameObject prefab;		// プレハブ用変数.
	
	void Start(){
		c03_score = GameObject.Find("GameRoot").GetComponent<C03_Score>();
		
		switch(tag){	// タグ名で分岐
		case "Block02": hp = 2; break;
		case "Block03": hp = 3; break;
		default:		hp = 1; break; 
		}
	}
	
	// ■■■衝突時の動作■■■
	void OnCollisionEnter(Collision other){
		
		hp--;	// ボールが当たったら、hpを減らす.
		if(hp == 0){
			int rnd = Random.Range(0 , 100);
			switch(tag){	// タグ名で分岐
			case "Block01":
				c03_score.Additional_score(1);		// スコア加点
				break;
			case "Block02":
				c03_score.Additional_score(2);		// スコア加点
				if(rnd < 50){						// 50%の確率でアイテム発生.
					Instantiate(prefab , transform.position , Quaternion.identity);		// プレハブ作成.
				}
				break;
			case "Block03":
				c03_score.Additional_score(3);		// スコア加点
				if(rnd < 50){						// 50%の確率でアイテム発生.
					Instantiate(prefab , transform.position , Quaternion.identity);		// プレハブ作成.
				}
				break;
			}
			
			Destroy(gameObject);	// ブロックの破壊.
			
		}else{
			GetComponent<Renderer>().material.color *= new Color(1.0f , 1.0f , 1.0f , 0.66f);		// 透明度を変更.
		}
	}
}
