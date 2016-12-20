using System;
using System.Collections.Generic;
using GameSparks.Core;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;

//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!
//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!
//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!

namespace GameSparks.Api.Requests{
	public class LogEventRequest_addcurrency1 : GSTypedRequest<LogEventRequest_addcurrency1, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_addcurrency1() : base("LogEventRequest"){
			request.AddString("eventKey", "addcurrency1");
		}
		public LogEventRequest_addcurrency1 Set_currencyRef( long value )
		{
			request.AddNumber("currencyRef", value);
			return this;
		}			
		public LogEventRequest_addcurrency1 Set_amount( long value )
		{
			request.AddNumber("amount", value);
			return this;
		}			
	}
	
	public class LogChallengeEventRequest_addcurrency1 : GSTypedRequest<LogChallengeEventRequest_addcurrency1, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_addcurrency1() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "addcurrency1");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_addcurrency1 SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		public LogChallengeEventRequest_addcurrency1 Set_currencyRef( long value )
		{
			request.AddNumber("currencyRef", value);
			return this;
		}			
		public LogChallengeEventRequest_addcurrency1 Set_amount( long value )
		{
			request.AddNumber("amount", value);
			return this;
		}			
	}
	
	public class LogEventRequest_takeTurn : GSTypedRequest<LogEventRequest_takeTurn, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_takeTurn() : base("LogEventRequest"){
			request.AddString("eventKey", "takeTurn");
		}
		public LogEventRequest_takeTurn Set_pos( long value )
		{
			request.AddNumber("pos", value);
			return this;
		}			
		
		public LogEventRequest_takeTurn Set_playericon( string value )
		{
			request.AddString("playericon", value);
			return this;
		}
	}
	
	public class LogChallengeEventRequest_takeTurn : GSTypedRequest<LogChallengeEventRequest_takeTurn, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_takeTurn() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "takeTurn");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_takeTurn SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		public LogChallengeEventRequest_takeTurn Set_pos( long value )
		{
			request.AddNumber("pos", value);
			return this;
		}			
		public LogChallengeEventRequest_takeTurn Set_playericon( string value )
		{
			request.AddString("playericon", value);
			return this;
		}
	}
	
}
	
	
	
namespace GameSparks.Api.Requests{
	
	public class LeaderboardDataRequest_highscore : GSTypedRequest<LeaderboardDataRequest_highscore,LeaderboardDataResponse_highscore>
	{
		public LeaderboardDataRequest_highscore() : base("LeaderboardDataRequest"){
			request.AddString("leaderboardShortCode", "highscore");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LeaderboardDataResponse_highscore (response);
		}		
		
		/// <summary>
		/// The challenge instance to get the leaderboard data for
		/// </summary>
		public LeaderboardDataRequest_highscore SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		/// <summary>
		/// The number of items to return in a page (default=50)
		/// </summary>
		public LeaderboardDataRequest_highscore SetEntryCount( long entryCount )
		{
			request.AddNumber("entryCount", entryCount);
			return this;
		}
		/// <summary>
		/// A friend id or an array of friend ids to use instead of the player's social friends
		/// </summary>
		public LeaderboardDataRequest_highscore SetFriendIds( List<string> friendIds )
		{
			request.AddStringList("friendIds", friendIds);
			return this;
		}
		/// <summary>
		/// Number of entries to include from head of the list
		/// </summary>
		public LeaderboardDataRequest_highscore SetIncludeFirst( long includeFirst )
		{
			request.AddNumber("includeFirst", includeFirst);
			return this;
		}
		/// <summary>
		/// Number of entries to include from tail of the list
		/// </summary>
		public LeaderboardDataRequest_highscore SetIncludeLast( long includeLast )
		{
			request.AddNumber("includeLast", includeLast);
			return this;
		}
		
		/// <summary>
		/// The offset into the set of leaderboards returned
		/// </summary>
		public LeaderboardDataRequest_highscore SetOffset( long offset )
		{
			request.AddNumber("offset", offset);
			return this;
		}
		/// <summary>
		/// If True returns a leaderboard of the player's social friends
		/// </summary>
		public LeaderboardDataRequest_highscore SetSocial( bool social )
		{
			request.AddBoolean("social", social);
			return this;
		}
		/// <summary>
		/// The IDs of the teams you are interested in
		/// </summary>
		public LeaderboardDataRequest_highscore SetTeamIds( List<string> teamIds )
		{
			request.AddStringList("teamIds", teamIds);
			return this;
		}
		/// <summary>
		/// The type of team you are interested in
		/// </summary>
		public LeaderboardDataRequest_highscore SetTeamTypes( List<string> teamTypes )
		{
			request.AddStringList("teamTypes", teamTypes);
			return this;
		}
		
	}

	public class AroundMeLeaderboardRequest_highscore : GSTypedRequest<AroundMeLeaderboardRequest_highscore,AroundMeLeaderboardResponse_highscore>
	{
		public AroundMeLeaderboardRequest_highscore() : base("AroundMeLeaderboardRequest"){
			request.AddString("leaderboardShortCode", "highscore");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AroundMeLeaderboardResponse_highscore (response);
		}		
		
		/// <summary>
		/// The number of items to return in a page (default=50)
		/// </summary>
		public AroundMeLeaderboardRequest_highscore SetEntryCount( long entryCount )
		{
			request.AddNumber("entryCount", entryCount);
			return this;
		}
		/// <summary>
		/// A friend id or an array of friend ids to use instead of the player's social friends
		/// </summary>
		public AroundMeLeaderboardRequest_highscore SetFriendIds( List<string> friendIds )
		{
			request.AddStringList("friendIds", friendIds);
			return this;
		}
		/// <summary>
		/// Number of entries to include from head of the list
		/// </summary>
		public AroundMeLeaderboardRequest_highscore SetIncludeFirst( long includeFirst )
		{
			request.AddNumber("includeFirst", includeFirst);
			return this;
		}
		/// <summary>
		/// Number of entries to include from tail of the list
		/// </summary>
		public AroundMeLeaderboardRequest_highscore SetIncludeLast( long includeLast )
		{
			request.AddNumber("includeLast", includeLast);
			return this;
		}
		
		/// <summary>
		/// If True returns a leaderboard of the player's social friends
		/// </summary>
		public AroundMeLeaderboardRequest_highscore SetSocial( bool social )
		{
			request.AddBoolean("social", social);
			return this;
		}
		/// <summary>
		/// The IDs of the teams you are interested in
		/// </summary>
		public AroundMeLeaderboardRequest_highscore SetTeamIds( List<string> teamIds )
		{
			request.AddStringList("teamIds", teamIds);
			return this;
		}
		/// <summary>
		/// The type of team you are interested in
		/// </summary>
		public AroundMeLeaderboardRequest_highscore SetTeamTypes( List<string> teamTypes )
		{
			request.AddStringList("teamTypes", teamTypes);
			return this;
		}
	}
}

namespace GameSparks.Api.Responses{
	
	public class _LeaderboardEntry_highscore : LeaderboardDataResponse._LeaderboardData{
		public _LeaderboardEntry_highscore(GSData data) : base(data){}
	}
	
	public class LeaderboardDataResponse_highscore : LeaderboardDataResponse
	{
		public LeaderboardDataResponse_highscore(GSData data) : base(data){}
		
		public GSEnumerable<_LeaderboardEntry_highscore> Data_highscore{
			get{return new GSEnumerable<_LeaderboardEntry_highscore>(response.GetObjectList("data"), (data) => { return new _LeaderboardEntry_highscore(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_highscore> First_highscore{
			get{return new GSEnumerable<_LeaderboardEntry_highscore>(response.GetObjectList("first"), (data) => { return new _LeaderboardEntry_highscore(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_highscore> Last_highscore{
			get{return new GSEnumerable<_LeaderboardEntry_highscore>(response.GetObjectList("last"), (data) => { return new _LeaderboardEntry_highscore(data);});}
		}
	}
	
	public class AroundMeLeaderboardResponse_highscore : AroundMeLeaderboardResponse
	{
		public AroundMeLeaderboardResponse_highscore(GSData data) : base(data){}
		
		public GSEnumerable<_LeaderboardEntry_highscore> Data_highscore{
			get{return new GSEnumerable<_LeaderboardEntry_highscore>(response.GetObjectList("data"), (data) => { return new _LeaderboardEntry_highscore(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_highscore> First_highscore{
			get{return new GSEnumerable<_LeaderboardEntry_highscore>(response.GetObjectList("first"), (data) => { return new _LeaderboardEntry_highscore(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_highscore> Last_highscore{
			get{return new GSEnumerable<_LeaderboardEntry_highscore>(response.GetObjectList("last"), (data) => { return new _LeaderboardEntry_highscore(data);});}
		}
	}
}	
	
	
namespace GameSparks.Api.Requests{
	
	public class LeaderboardDataRequest_points : GSTypedRequest<LeaderboardDataRequest_points,LeaderboardDataResponse_points>
	{
		public LeaderboardDataRequest_points() : base("LeaderboardDataRequest"){
			request.AddString("leaderboardShortCode", "points");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LeaderboardDataResponse_points (response);
		}		
		
		/// <summary>
		/// The challenge instance to get the leaderboard data for
		/// </summary>
		public LeaderboardDataRequest_points SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		/// <summary>
		/// The number of items to return in a page (default=50)
		/// </summary>
		public LeaderboardDataRequest_points SetEntryCount( long entryCount )
		{
			request.AddNumber("entryCount", entryCount);
			return this;
		}
		/// <summary>
		/// A friend id or an array of friend ids to use instead of the player's social friends
		/// </summary>
		public LeaderboardDataRequest_points SetFriendIds( List<string> friendIds )
		{
			request.AddStringList("friendIds", friendIds);
			return this;
		}
		/// <summary>
		/// Number of entries to include from head of the list
		/// </summary>
		public LeaderboardDataRequest_points SetIncludeFirst( long includeFirst )
		{
			request.AddNumber("includeFirst", includeFirst);
			return this;
		}
		/// <summary>
		/// Number of entries to include from tail of the list
		/// </summary>
		public LeaderboardDataRequest_points SetIncludeLast( long includeLast )
		{
			request.AddNumber("includeLast", includeLast);
			return this;
		}
		
		/// <summary>
		/// The offset into the set of leaderboards returned
		/// </summary>
		public LeaderboardDataRequest_points SetOffset( long offset )
		{
			request.AddNumber("offset", offset);
			return this;
		}
		/// <summary>
		/// If True returns a leaderboard of the player's social friends
		/// </summary>
		public LeaderboardDataRequest_points SetSocial( bool social )
		{
			request.AddBoolean("social", social);
			return this;
		}
		/// <summary>
		/// The IDs of the teams you are interested in
		/// </summary>
		public LeaderboardDataRequest_points SetTeamIds( List<string> teamIds )
		{
			request.AddStringList("teamIds", teamIds);
			return this;
		}
		/// <summary>
		/// The type of team you are interested in
		/// </summary>
		public LeaderboardDataRequest_points SetTeamTypes( List<string> teamTypes )
		{
			request.AddStringList("teamTypes", teamTypes);
			return this;
		}
		
	}

	public class AroundMeLeaderboardRequest_points : GSTypedRequest<AroundMeLeaderboardRequest_points,AroundMeLeaderboardResponse_points>
	{
		public AroundMeLeaderboardRequest_points() : base("AroundMeLeaderboardRequest"){
			request.AddString("leaderboardShortCode", "points");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AroundMeLeaderboardResponse_points (response);
		}		
		
		/// <summary>
		/// The number of items to return in a page (default=50)
		/// </summary>
		public AroundMeLeaderboardRequest_points SetEntryCount( long entryCount )
		{
			request.AddNumber("entryCount", entryCount);
			return this;
		}
		/// <summary>
		/// A friend id or an array of friend ids to use instead of the player's social friends
		/// </summary>
		public AroundMeLeaderboardRequest_points SetFriendIds( List<string> friendIds )
		{
			request.AddStringList("friendIds", friendIds);
			return this;
		}
		/// <summary>
		/// Number of entries to include from head of the list
		/// </summary>
		public AroundMeLeaderboardRequest_points SetIncludeFirst( long includeFirst )
		{
			request.AddNumber("includeFirst", includeFirst);
			return this;
		}
		/// <summary>
		/// Number of entries to include from tail of the list
		/// </summary>
		public AroundMeLeaderboardRequest_points SetIncludeLast( long includeLast )
		{
			request.AddNumber("includeLast", includeLast);
			return this;
		}
		
		/// <summary>
		/// If True returns a leaderboard of the player's social friends
		/// </summary>
		public AroundMeLeaderboardRequest_points SetSocial( bool social )
		{
			request.AddBoolean("social", social);
			return this;
		}
		/// <summary>
		/// The IDs of the teams you are interested in
		/// </summary>
		public AroundMeLeaderboardRequest_points SetTeamIds( List<string> teamIds )
		{
			request.AddStringList("teamIds", teamIds);
			return this;
		}
		/// <summary>
		/// The type of team you are interested in
		/// </summary>
		public AroundMeLeaderboardRequest_points SetTeamTypes( List<string> teamTypes )
		{
			request.AddStringList("teamTypes", teamTypes);
			return this;
		}
	}
}

namespace GameSparks.Api.Responses{
	
	public class _LeaderboardEntry_points : LeaderboardDataResponse._LeaderboardData{
		public _LeaderboardEntry_points(GSData data) : base(data){}
	}
	
	public class LeaderboardDataResponse_points : LeaderboardDataResponse
	{
		public LeaderboardDataResponse_points(GSData data) : base(data){}
		
		public GSEnumerable<_LeaderboardEntry_points> Data_points{
			get{return new GSEnumerable<_LeaderboardEntry_points>(response.GetObjectList("data"), (data) => { return new _LeaderboardEntry_points(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_points> First_points{
			get{return new GSEnumerable<_LeaderboardEntry_points>(response.GetObjectList("first"), (data) => { return new _LeaderboardEntry_points(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_points> Last_points{
			get{return new GSEnumerable<_LeaderboardEntry_points>(response.GetObjectList("last"), (data) => { return new _LeaderboardEntry_points(data);});}
		}
	}
	
	public class AroundMeLeaderboardResponse_points : AroundMeLeaderboardResponse
	{
		public AroundMeLeaderboardResponse_points(GSData data) : base(data){}
		
		public GSEnumerable<_LeaderboardEntry_points> Data_points{
			get{return new GSEnumerable<_LeaderboardEntry_points>(response.GetObjectList("data"), (data) => { return new _LeaderboardEntry_points(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_points> First_points{
			get{return new GSEnumerable<_LeaderboardEntry_points>(response.GetObjectList("first"), (data) => { return new _LeaderboardEntry_points(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_points> Last_points{
			get{return new GSEnumerable<_LeaderboardEntry_points>(response.GetObjectList("last"), (data) => { return new _LeaderboardEntry_points(data);});}
		}
	}
}	

namespace GameSparks.Api.Messages {


}
