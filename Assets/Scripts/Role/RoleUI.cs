using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using role_message;

public class RoleUI : MonoBehaviour {

    private static RoleUI instance;

    public static RoleUI Instance
    {
        get
        {
            return instance;
        }
    }

	private Button enterGameBtn;
    private Button createRoleBtn;
	private Button deleteRoleBtn;

    private InputField nicknameInput;
    private Text msgText;

    enum ButtonType
    {
		ENTER_GAME,
        CREATE_ROLE,
		DELETE_ROLE
    }

    void Awake() {
        instance = this;
    }

	// Use this for initialization
	void Start () {
		enterGameBtn = GameObject.Find("EnterGameBtn").GetComponent<Button>();
		enterGameBtn.onClick.AddListener(() => OnButtonClick(ButtonType.ENTER_GAME));

		createRoleBtn = GameObject.Find("CreateRoleBtn").GetComponent<Button>();
		createRoleBtn.onClick.AddListener(() => OnButtonClick(ButtonType.CREATE_ROLE));

		deleteRoleBtn = GameObject.Find("DeleteRoleBtn").GetComponent<Button>();
		deleteRoleBtn.onClick.AddListener(() => OnButtonClick(ButtonType.DELETE_ROLE));


        msgText = GameObject.Find("MsgText").GetComponent<Text>();
        nicknameInput = GameObject.Find("NicknameInput").GetComponent<InputField>();

		string authid = ApplicationData.authid;
		RoleController.Instance.SendRoleListRequest(authid);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnButtonClick(ButtonType type)
    {
        string nickname = nicknameInput.text;
		Debug.Log("---" + nickname + "---");
		if (nickname.Equals(""))
        {
            ShowErrorMsg("昵称不能为空");
            return;
        }

		if (type == ButtonType.CREATE_ROLE) {
			RoleController.Instance.SendRoleCreateRequest (nickname);
		} else if (type == ButtonType.DELETE_ROLE) {
			
		} else if (type == ButtonType.ENTER_GAME) {
            
        }
    }

    public void ShowErrorMsg(string msg)
    {
        this.msgText.text = msg;
    }
		
	public void ShowRoleList(List<MsgRole> roles)
    {

    }
}
