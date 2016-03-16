using ProtoBuf;

namespace login_message {
	
	[ProtoContract]
	class CMsgAccountLoginRequest {
		[ProtoMember(1)]
		public string account { get; set;}
	}

	[ProtoContract]
	class CMsgAccountLoginResponse {
		[ProtoMember(1)]
		public int accountid { get; set; }
	}

	[ProtoContract]
	class CMsgAccountRegistRequest {
		[ProtoMember(1)]
		public string account { get; set; }
	}

	[ProtoContract]
	class CMsgAccountRegistResponse {
		[ProtoMember(1)]
		public int accountid { get; set; }
	}

}
