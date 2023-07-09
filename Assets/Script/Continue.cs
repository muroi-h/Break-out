using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour {
	void OnGUI(){
		if(GUI.Button(new Rect(Screen.width-730 , Screen.height-150 , 140 , 60),"CONTINUE")){
			SceneManager.LoadScene("title");
		}

		if(Input.GetKey("esc")) {
			SceneManager.LoadScene("title");
		}
	}
}
