using System.Collections;
using System.IO;
using ProtoBuf;
using UnityEngine;
using System.Collections.Generic;
using account_message;

public class AccountController : MessageController {

	private static AccountController instance = null;

	public static AccountController Instance
    {
        get
        {
            if (instance == null)
            {
				instance = new AccountController();
            }

            return instance;
        }
    }

	private AccountController()
    {

    }

    public void OnMessageResponse(int opcode, MemoryStream stream)
    {
        Debug.Log("---login controller receive opcode " + opcode);
        switch (opcode)
        {
            case Message.MSG_ACCOUNT_LOGIN_RESPONSE_S2C & 0x0000FFFF:
                OnAccountLoginResponse(stream);
                break;
            case Message.MSG_ACCOUNT_REGIST_RESPONSE_S2C & 0x0000FFFF:
                OnAccountRegistResponse(stream);
                break;
            default:
                break;
        }
    }

    private void OnAccountLoginResponse(MemoryStream stream)
    {
        MsgAccountLoginResponse response = ProtoBuf.Serializer.Deserialize<MsgAccountLoginResponse>(stream);
		long authid = response.authid;
		Debug.Log("-------authid:" + authid);
		if(authid == 0)
        {
            LoginUI.Instance.ShowErrorMsg("该用户不存在");
        }
        else
        {
			ApplicationData.authid = authid;
            Application.LoadLevel("role");
        }
        
    }

    private void OnAccountRegistResponse(MemoryStream stream)
    {
        MsgAccountRegistResponse response = ProtoBuf.Serializer.Deserialize<MsgAccountRegistResponse>(stream);
		long authid = response.authid;
		Debug.Log("-------authid:" + authid);
		if (authid == 0)
        {
            LoginUI.Instance.ShowErrorMsg("该用户不存在");
        }
        else
        {
			ApplicationData.authid = authid;
            Application.LoadLevel("role");
        }
    }

    public void SendLoginRequest(string account)
    {
        MsgAccountLoginRequest request = new MsgAccountLoginRequest();
        request.account = account;
		request.password = "123456";

		Debug.Log ("---login---:" + request.account);

        MemoryStream stream = new MemoryStream();
        Serializer.Serialize<MsgAccountLoginRequest>(stream, request);

        NetManager.Instance.Send(Message.MSG_ACCOUNT_LOGIN_REQUEST_C2S, stream);
    }

    public void SendRegistRequest(string account)
    {
        MsgAccountRegistRequest request = new MsgAccountRegistRequest();
        request.account = account;
		request.password = "123456";

        MemoryStream stream = new MemoryStream();
        Serializer.Serialize<MsgAccountRegistRequest>(stream, request);

        NetManager.Instance.Send(Message.MSG_ACCOUNT_REGIST_REQUEST_C2S, stream);
    }
}
