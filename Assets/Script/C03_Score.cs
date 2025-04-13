using UnityEngine;
using System.Collections;
[ExecuteInEditMode()] // ゲームを実行しなくてもプログラムを実行させる一文.

public class C03_Score : MonoBehaviour
{
	static private int score = 0; // スコア.
	static private int max_score = 0; // スコア最高得点.
	private bool flag = false;
	public GUIStyle gui_score; // GUIスタイル

	/// <summary>
	/// スコア加算用の関数
	/// </summary>
	public void Additional_score(int value)
	{
		score += value;
	}

	/// <summary>
	/// ゲームクリア時の処理
	/// </summary>
	public void GameClear_score()
	{
		if (max_score < score)
		{
			max_score = score;
		}
		flag = true;
	}

	/// <summary>
	/// スコアの初期化
	/// </summary>
	public void Reset_score()
	{
		score = 0;
	}

	/// <summary>
	/// スコアの表示
	/// </summary>
	void OnGUI()
	{
		if (!flag)
		{
			GUI.Label(new Rect(0, 0, Screen.width - 10, 30), "SCORE : " + score, gui_score);
		}
		else
		{
			GUI.Label(new Rect(0, Screen.height - 150, Screen.width - 120, 30), "  今回の得点 : " + score, gui_score);
			GUI.Label(new Rect(0, Screen.height - 100, Screen.width - 120, 30), "過去最高得点 : " + score, gui_score);
		}
	}
}
