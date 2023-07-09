using UnityEngine;
using UnityEngine.SceneManagement;

public class C01_TitleScene : MonoBehaviour {
	void OnGUI(){
		if(GUI.Button(new Rect(Screen.width-730 , Screen.height-150 , 140 , 60),"START")){
			SceneManager.LoadScene("stage");
		}

		if(Input.GetKey("return")) {
			SceneManager.LoadScene("stage");
		}
	}
}
