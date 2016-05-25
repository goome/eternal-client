using ProtoBuf;
using System.Collections.Generic;

namespace account_message {

	[ProtoContract]
	class MsgAccountLoginRequest {
		[ProtoMember(1)]
		public string account { get; set; }
		[ProtoMember(2)]
		public string password { get; set; }
	}

	[ProtoContract]
	class MsgAccountLoginResponse {
		[ProtoMember(1)]
		public bool success { get; set; }
		[ProtoMember(2)]
		public int retcode { get; set; }
		[ProtoMember(3)]
		public string authid { get; set; }
		[ProtoMember(4)]
		public int currServId { get; set; }
	}

	[ProtoContract]
	class MsgAccountRegisterRequest {
		[ProtoMember(1)]
		public string account { get; set; }
		[ProtoMember(2)]
		public string password { get; set; }
	}

	[ProtoContract]
	class MsgAccountRegisterResponse {
		[ProtoMember(1)]
		public bool success { get; set; }
		[ProtoMember(2)]
		public int retcode { get; set; }
		[ProtoMember(3)]
		public string authid { get; set; }
		[ProtoMember(4)]
		public int currServId { get; set; }
	}

}
