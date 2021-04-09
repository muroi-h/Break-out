using UnityEngine;
using System.Collections;

public class C01_TitleScene : MonoBehaviour {
	void OnGUI(){
		if(GUI.Button(new Rect(Screen.width-730 , Screen.height-150 , 140 , 60),"START")){
			Application.LoadLevel("stage");	
		}

		if(Input.GetKey("return")) {
			Application.LoadLevel("stage");
		}
	}
}
