using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ServerUI : MonoBehaviour {

	private InputField currServerInput;
	private Button enterGameBtn;

	// Use this for initialization
	void Start () {
		currServerInput = GameObject.Find("CurrServerInput").GetComponent<InputField>();
		enterGameBtn = GameObject.Find ("EnterGameBtn").GetComponent<Button> ();

		enterGameBtn.onClick.AddListener(() => OnButtonClick());      
	}
	
	// Update is called once per frame
	void Update() {
	
	}


	private void OnInputClick() {
	
	}

	private void OnButtonClick() {
		Debug.Log ("enter game");
	}
}
