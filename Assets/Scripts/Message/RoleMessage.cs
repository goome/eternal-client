using ProtoBuf;
using System.Collections.Generic;

namespace role_message {

	[ProtoContract]
	public class Role {
		[ProtoMember(1)]
		public int id { get; set; }
		[ProtoMember(2)]
		public string nickname { get; set; }
		[ProtoMember(3)]
		public int level { get; set; }
		[ProtoMember(4)]
		public int roletype { get; set; }
	}

	[ProtoContract]
	class CMsgRoleListRequest {
		[ProtoMember(1)]
		public string accountid { get; set;}
	}
		
	[ProtoContract]
	class CMsgRoleListResponse {
		[ProtoMember(1)]
		public List<Role> roles { get; set; }
	}

	[ProtoContract]
	class CMsgRoleCreateRequest {
		[ProtoMember(1)]
		public string accountid { get; set; }
		[ProtoMember(2)]
		public string nickname { get; set; }
		[ProtoMember(3)]
		public int roletype { get; set; }
	}

	[ProtoContract]
	class CMsgRoleCreateResponse {
		[ProtoMember(1)]
		public Role role { get; set; }
	}

}
