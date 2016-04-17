using System;
using ProtoBuf;
using System.Collections.Generic;

namespace server_message
{
	[ProtoContract]
	class MsgServer {
		[ProtoMember(1)]
		public int serverid { get; set; }
		[ProtoMember(2)]
		public string name { get; set; }
		[ProtoMember(3)]
		public string ip { get; set; }
		[ProtoMember(4)]
		public int port { get; set; }
	}

	[ProtoContract]
	class MsgServerListRequest {
		
	}

	[ProtoContract]
	class MsgServerListResponse {
		[ProtoMember(1)]
		public List<MsgServer> servers { get; set; }
	}

}

