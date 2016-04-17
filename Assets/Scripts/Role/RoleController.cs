using UnityEngine;
using System.Collections;
using System.IO;
using role_message;
using System.Collections.Generic;
using ProtoBuf;

public class RoleController : MessageController {

    private static RoleController instance;

    public static RoleController Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new RoleController();
            }
            return instance;
        }
    }

    private RoleController()
    {

    }

    public void OnMessageResponse(int opcode, MemoryStream stream)
    {
        Debug.Log("---role controller receive opcode " + opcode);
        switch (opcode)
        {
            case Message.MSG_ROLE_LIST_RESPONSE_S2C & 0x0000FFFF:
                OnRoleListResponse(stream);
                break;
            case Message.MSG_ROLE_CREATE_RESPONSE_S2C & 0x0000FFFF:
                OnRoleCreateResponse(stream);
                break;
            default:
                break;
        }
    }

    private void OnRoleCreateResponse(MemoryStream stream)
    {
        MsgRoleCreateResponse response = ProtoBuf.Serializer.Deserialize<MsgRoleCreateResponse>(stream);
		bool success = response.success;
		Debug.Log("---create role---" + success);
    }

    private void OnRoleListResponse(MemoryStream stream)
    {
        MsgRoleListResponse response = ProtoBuf.Serializer.Deserialize<MsgRoleListResponse>(stream);
        List<MsgRole> list = response.roles;
        Debug.Log("---role list---" + list.Capacity);

        RoleUI.Instance.ShowRoleList(list);
    }

    public void SendRoleListRequest(string authid)
    {
        Debug.Log("---authid:" + authid);
        MsgRoleListRequest request = new MsgRoleListRequest();
		request.authid = authid.ToString();

        MemoryStream stream = new MemoryStream();
        Serializer.Serialize<MsgRoleListRequest>(stream, request);

        NetManager.Instance.Send(Message.MSG_ROLE_LIST_REQUEST_C2S, stream);
    }

    public void SendRoleCreateRequest(string nickname)
    {
        MsgRoleCreateRequest request = new MsgRoleCreateRequest();
		request.race = 1;
        request.nickname = nickname;
		request.authid = ApplicationData.authid.ToString();

        MemoryStream stream = new MemoryStream();
        Serializer.Serialize<MsgRoleCreateRequest>(stream, request);

        NetManager.Instance.Send(Message.MSG_ROLE_CREATE_REQUEST_C2S, stream);
    }
}
