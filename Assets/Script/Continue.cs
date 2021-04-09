using UnityEngine;
using System.Collections;

public class Continue : MonoBehaviour {
	void OnGUI(){
		if(GUI.Button(new Rect(Screen.width-730 , Screen.height-150 , 140 , 60),"CONTINUE")){
			Application.LoadLevel("title");	
		}

		if(Input.GetKey("esc")) {
			Application.LoadLevel("title");
		}
	}
}
