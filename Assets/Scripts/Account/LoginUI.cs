using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoginUI : MonoBehaviour {

	private InputField accountInput;
	private InputField passwordInput;
    private Button loginBtn;
    private Button registBtn;
    private Text msgText;

    private static LoginUI instance;

    public static LoginUI Instance
    {
        get
        {
            return instance;
        }
    }

    private enum ButtonType
    {
        LOGIN,
        REGIST
    }

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () {
		msgText = GameObject.Find("MsgText").GetComponent<Text>();
		accountInput = GameObject.Find("AccountInput").GetComponent<InputField>();
		passwordInput = GameObject.Find("PasswordInput").GetComponent<InputField>();
		loginBtn = GameObject.Find("LoginBtn").GetComponent<Button>();
		registBtn = GameObject.Find("RegistBtn").GetComponent<Button>();
       
        loginBtn.onClick.AddListener(() => OnButtonClick(ButtonType.LOGIN));       
        registBtn.onClick.AddListener(() => OnButtonClick(ButtonType.REGIST));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnButtonClick(ButtonType type)
    {
        string account = accountInput.text;
		string password = passwordInput.text;
		Debug.Log("---"+account+"---" + password);
        if(account.Equals(""))
        {
            ShowErrorMsg("账号不能为空");
            return;
        }
		if (password.Equals("")) 
		{
			ShowErrorMsg ("密码不能为空");
			return;
		}

        if(type == ButtonType.LOGIN)
        {
			AccountController.Instance.SendLoginRequest(account, password);
        }
        else if(type == ButtonType.REGIST)
        {
			AccountController.Instance.SendRegistRequest(account, password);
        }
    }

    public void ShowErrorMsg(string msg)
    {
        msgText.text = msg;
    }
}
