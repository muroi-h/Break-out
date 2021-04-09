using UnityEngine;
using System.Collections;

public class End : MonoBehaviour {
	void OnGUI(){
		if(GUI.Button(new Rect(Screen.width-550 , Screen.height-150 , 140 , 60),"EXIT")){
			Application.Quit();	
		}
	}
}
