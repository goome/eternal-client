using ProtoBuf;
using System.Collections.Generic;

namespace role_message {

	[ProtoContract]
	public class MsgRole {
		[ProtoMember(1)]
		public int roleid { get; set; }
		[ProtoMember(2)]
		public string nickname { get; set; }
		[ProtoMember(3)]
		public int level { get; set; }
		[ProtoMember(4)]
		public int race { get; set; }
		[ProtoMember(5)]
		public int sceneid { get; set; }
	}

	[ProtoContract]
	class MsgRoleListRequest {
		[ProtoMember(1)]
		public string authid { get; set; }
		[ProtoMember(2)]
		public int serverid { get; set; }
	}
		
	[ProtoContract]
	class MsgRoleListResponse {
		[ProtoMember(1)]
		public List<MsgRole> roles { get; set; }
	}

	[ProtoContract]
	class MsgRoleCreateRequest {
		[ProtoMember(1)]
		public string authid { get; set; }
		[ProtoMember(2)]
		public int serverid { get; set; }
		[ProtoMember(3)]
		public int race { get; set; }
		[ProtoMember(4)]
		public string nickname { get; set; }

	}

	[ProtoContract]
	class MsgRoleCreateResponse {
		[ProtoMember(1)]
		public bool success { get; set; }
		[ProtoMember(2)]
		public int retcode { get; set; }
	}

	[ProtoContract]
	class MsgRoleDeleteRequest {
		[ProtoMember(1)]
		public int roleid { get; set; }
	}

	[ProtoContract]
	class MsgRoleDeleteResponse {
		[ProtoMember(1)]
		public bool success { get; set; }
		[ProtoMember(2)]
		public int retcode { get; set; }
	}
}
