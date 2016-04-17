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
		string authid = response.authid;
		bool success = response.success;
		Debug.Log("-------authid:" + authid + "," + success);
		if(!success)
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
		string authid = response.authid;
		bool success = response.success;
		Debug.Log("-------authid:" + authid + "," + success);
		if (!success)
        {
            LoginUI.Instance.ShowErrorMsg("注册失败");
        }
        else
        {
			ApplicationData.authid = authid;
            Application.LoadLevel("role");
        }
    }

	public void SendLoginRequest(string account, string password)
    {
        MsgAccountLoginRequest request = new MsgAccountLoginRequest();
        request.account = account;
		request.password = password;

		Debug.Log ("---login---:" + request.account);

        MemoryStream stream = new MemoryStream();
        Serializer.Serialize<MsgAccountLoginRequest>(stream, request);

        NetManager.Instance.Send(Message.MSG_ACCOUNT_LOGIN_REQUEST_C2S, stream);
    }

	public void SendRegistRequest(string account, string password)
    {
        MsgAccountRegistRequest request = new MsgAccountRegistRequest();
        request.account = account;
		request.password = password;

        MemoryStream stream = new MemoryStream();
        Serializer.Serialize<MsgAccountRegistRequest>(stream, request);

        NetManager.Instance.Send(Message.MSG_ACCOUNT_REGIST_REQUEST_C2S, stream);
    }
}
