using ProtoBuf;
using System.Collections.Generic;

namespace account_message {

	[ProtoContract]
	class MsgGateServer {
		[ProtoMember(1)]
		public string name { get; set; }
		[ProtoMember(2)]
		public string ip { get; set; }
		[ProtoMember(3)]
		public int port { get; set; }
	}

	[ProtoContract]
	class MsgAccountLoginRequest {
		[ProtoMember(1)]
		public string account { get; set;}
		[ProtoMember(2)]
		public string password { get; set;}
	}

	[ProtoContract]
	class MsgAccountLoginResponse {
		[ProtoMember(1)]
		public bool success { get; set; }
		[ProtoMember(2)]
		public int retcode { get; set; }
		[ProtoMember(3)]
		public int authid { get; set; }
		[ProtoMember(4)]
		public List<MsgGateServer> servers { get; set; }
	}

	[ProtoContract]
	class MsgAccountRegistRequest {
		[ProtoMember(1)]
		public string account { get; set;}
		[ProtoMember(2)]
		public string password { get; set;}
	}

	[ProtoContract]
	class MsgAccountRegistResponse {
		[ProtoMember(1)]
		public bool success { get; set; }
		[ProtoMember(2)]
		public int retcode { get; set; }
		[ProtoMember(3)]
		public int authid { get; set; }
		[ProtoMember(4)]
		public List<MsgGateServer> servers { get; set; }
	}

}
