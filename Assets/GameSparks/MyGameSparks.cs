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
	
	public class LogEventRequest_bid : GSTypedRequest<LogEventRequest_bid, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_bid() : base("LogEventRequest"){
			request.AddString("eventKey", "bid");
		}
		public LogEventRequest_bid Set_tricks( long value )
		{
			request.AddNumber("tricks", value);
			return this;
		}			
	}
	
	public class LogChallengeEventRequest_bid : GSTypedRequest<LogChallengeEventRequest_bid, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_bid() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "bid");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_bid SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		public LogChallengeEventRequest_bid Set_tricks( long value )
		{
			request.AddNumber("tricks", value);
			return this;
		}			
	}
	
	public class LogEventRequest_level_event : GSTypedRequest<LogEventRequest_level_event, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_level_event() : base("LogEventRequest"){
			request.AddString("eventKey", "level_event");
		}
		public LogEventRequest_level_event Set_l_score( long value )
		{
			request.AddNumber("l_score", value);
			return this;
		}			
	}
	
	public class LogChallengeEventRequest_level_event : GSTypedRequest<LogChallengeEventRequest_level_event, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_level_event() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "level_event");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_level_event SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		public LogChallengeEventRequest_level_event Set_l_score( long value )
		{
			request.AddNumber("l_score", value);
			return this;
		}			
	}
	
	public class LogEventRequest_Match_Event : GSTypedRequest<LogEventRequest_Match_Event, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_Match_Event() : base("LogEventRequest"){
			request.AddString("eventKey", "Match_Event");
		}
		
		public LogEventRequest_Match_Event Set_match_code( string value )
		{
			request.AddString("match_code", value);
			return this;
		}
	}
	
	public class LogChallengeEventRequest_Match_Event : GSTypedRequest<LogChallengeEventRequest_Match_Event, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_Match_Event() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "Match_Event");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_Match_Event SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		public LogChallengeEventRequest_Match_Event Set_match_code( string value )
		{
			request.AddString("match_code", value);
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
		
		public LogEventRequest_takeTurn Set_card( string value )
		{
			request.AddString("card", value);
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
		public LogChallengeEventRequest_takeTurn Set_card( string value )
		{
			request.AddString("card", value);
			return this;
		}
	}
	
	public class LogEventRequest_tarneeb : GSTypedRequest<LogEventRequest_tarneeb, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_tarneeb() : base("LogEventRequest"){
			request.AddString("eventKey", "tarneeb");
		}
		
		public LogEventRequest_tarneeb Set_trump( string value )
		{
			request.AddString("trump", value);
			return this;
		}
	}
	
	public class LogChallengeEventRequest_tarneeb : GSTypedRequest<LogChallengeEventRequest_tarneeb, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_tarneeb() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "tarneeb");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_tarneeb SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		public LogChallengeEventRequest_tarneeb Set_trump( string value )
		{
			request.AddString("trump", value);
			return this;
		}
	}
	
}
	
	
	
namespace GameSparks.Api.Requests{
	
	public class LeaderboardDataRequest_High_Score_Leaderboard : GSTypedRequest<LeaderboardDataRequest_High_Score_Leaderboard,LeaderboardDataResponse_High_Score_Leaderboard>
	{
		public LeaderboardDataRequest_High_Score_Leaderboard() : base("LeaderboardDataRequest"){
			request.AddString("leaderboardShortCode", "High_Score_Leaderboard");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LeaderboardDataResponse_High_Score_Leaderboard (response);
		}		
		
		/// <summary>
		/// The challenge instance to get the leaderboard data for
		/// </summary>
		public LeaderboardDataRequest_High_Score_Leaderboard SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		/// <summary>
		/// The number of items to return in a page (default=50)
		/// </summary>
		public LeaderboardDataRequest_High_Score_Leaderboard SetEntryCount( long entryCount )
		{
			request.AddNumber("entryCount", entryCount);
			return this;
		}
		/// <summary>
		/// A friend id or an array of friend ids to use instead of the player's social friends
		/// </summary>
		public LeaderboardDataRequest_High_Score_Leaderboard SetFriendIds( List<string> friendIds )
		{
			request.AddStringList("friendIds", friendIds);
			return this;
		}
		/// <summary>
		/// Number of entries to include from head of the list
		/// </summary>
		public LeaderboardDataRequest_High_Score_Leaderboard SetIncludeFirst( long includeFirst )
		{
			request.AddNumber("includeFirst", includeFirst);
			return this;
		}
		/// <summary>
		/// Number of entries to include from tail of the list
		/// </summary>
		public LeaderboardDataRequest_High_Score_Leaderboard SetIncludeLast( long includeLast )
		{
			request.AddNumber("includeLast", includeLast);
			return this;
		}
		
		/// <summary>
		/// The offset into the set of leaderboards returned
		/// </summary>
		public LeaderboardDataRequest_High_Score_Leaderboard SetOffset( long offset )
		{
			request.AddNumber("offset", offset);
			return this;
		}
		/// <summary>
		/// If True returns a leaderboard of the player's social friends
		/// </summary>
		public LeaderboardDataRequest_High_Score_Leaderboard SetSocial( bool social )
		{
			request.AddBoolean("social", social);
			return this;
		}
		/// <summary>
		/// The IDs of the teams you are interested in
		/// </summary>
		public LeaderboardDataRequest_High_Score_Leaderboard SetTeamIds( List<string> teamIds )
		{
			request.AddStringList("teamIds", teamIds);
			return this;
		}
		/// <summary>
		/// The type of team you are interested in
		/// </summary>
		public LeaderboardDataRequest_High_Score_Leaderboard SetTeamTypes( List<string> teamTypes )
		{
			request.AddStringList("teamTypes", teamTypes);
			return this;
		}
		
	}

	public class AroundMeLeaderboardRequest_High_Score_Leaderboard : GSTypedRequest<AroundMeLeaderboardRequest_High_Score_Leaderboard,AroundMeLeaderboardResponse_High_Score_Leaderboard>
	{
		public AroundMeLeaderboardRequest_High_Score_Leaderboard() : base("AroundMeLeaderboardRequest"){
			request.AddString("leaderboardShortCode", "High_Score_Leaderboard");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AroundMeLeaderboardResponse_High_Score_Leaderboard (response);
		}		
		
		/// <summary>
		/// The number of items to return in a page (default=50)
		/// </summary>
		public AroundMeLeaderboardRequest_High_Score_Leaderboard SetEntryCount( long entryCount )
		{
			request.AddNumber("entryCount", entryCount);
			return this;
		}
		/// <summary>
		/// A friend id or an array of friend ids to use instead of the player's social friends
		/// </summary>
		public AroundMeLeaderboardRequest_High_Score_Leaderboard SetFriendIds( List<string> friendIds )
		{
			request.AddStringList("friendIds", friendIds);
			return this;
		}
		/// <summary>
		/// Number of entries to include from head of the list
		/// </summary>
		public AroundMeLeaderboardRequest_High_Score_Leaderboard SetIncludeFirst( long includeFirst )
		{
			request.AddNumber("includeFirst", includeFirst);
			return this;
		}
		/// <summary>
		/// Number of entries to include from tail of the list
		/// </summary>
		public AroundMeLeaderboardRequest_High_Score_Leaderboard SetIncludeLast( long includeLast )
		{
			request.AddNumber("includeLast", includeLast);
			return this;
		}
		
		/// <summary>
		/// If True returns a leaderboard of the player's social friends
		/// </summary>
		public AroundMeLeaderboardRequest_High_Score_Leaderboard SetSocial( bool social )
		{
			request.AddBoolean("social", social);
			return this;
		}
		/// <summary>
		/// The IDs of the teams you are interested in
		/// </summary>
		public AroundMeLeaderboardRequest_High_Score_Leaderboard SetTeamIds( List<string> teamIds )
		{
			request.AddStringList("teamIds", teamIds);
			return this;
		}
		/// <summary>
		/// The type of team you are interested in
		/// </summary>
		public AroundMeLeaderboardRequest_High_Score_Leaderboard SetTeamTypes( List<string> teamTypes )
		{
			request.AddStringList("teamTypes", teamTypes);
			return this;
		}
	}
}

namespace GameSparks.Api.Responses{
	
	public class _LeaderboardEntry_High_Score_Leaderboard : LeaderboardDataResponse._LeaderboardData{
		public _LeaderboardEntry_High_Score_Leaderboard(GSData data) : base(data){}
		public long? l_score{
			get{return response.GetNumber("l_score");}
		}
	}
	
	public class LeaderboardDataResponse_High_Score_Leaderboard : LeaderboardDataResponse
	{
		public LeaderboardDataResponse_High_Score_Leaderboard(GSData data) : base(data){}
		
		public GSEnumerable<_LeaderboardEntry_High_Score_Leaderboard> Data_High_Score_Leaderboard{
			get{return new GSEnumerable<_LeaderboardEntry_High_Score_Leaderboard>(response.GetObjectList("data"), (data) => { return new _LeaderboardEntry_High_Score_Leaderboard(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_High_Score_Leaderboard> First_High_Score_Leaderboard{
			get{return new GSEnumerable<_LeaderboardEntry_High_Score_Leaderboard>(response.GetObjectList("first"), (data) => { return new _LeaderboardEntry_High_Score_Leaderboard(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_High_Score_Leaderboard> Last_High_Score_Leaderboard{
			get{return new GSEnumerable<_LeaderboardEntry_High_Score_Leaderboard>(response.GetObjectList("last"), (data) => { return new _LeaderboardEntry_High_Score_Leaderboard(data);});}
		}
	}
	
	public class AroundMeLeaderboardResponse_High_Score_Leaderboard : AroundMeLeaderboardResponse
	{
		public AroundMeLeaderboardResponse_High_Score_Leaderboard(GSData data) : base(data){}
		
		public GSEnumerable<_LeaderboardEntry_High_Score_Leaderboard> Data_High_Score_Leaderboard{
			get{return new GSEnumerable<_LeaderboardEntry_High_Score_Leaderboard>(response.GetObjectList("data"), (data) => { return new _LeaderboardEntry_High_Score_Leaderboard(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_High_Score_Leaderboard> First_High_Score_Leaderboard{
			get{return new GSEnumerable<_LeaderboardEntry_High_Score_Leaderboard>(response.GetObjectList("first"), (data) => { return new _LeaderboardEntry_High_Score_Leaderboard(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_High_Score_Leaderboard> Last_High_Score_Leaderboard{
			get{return new GSEnumerable<_LeaderboardEntry_High_Score_Leaderboard>(response.GetObjectList("last"), (data) => { return new _LeaderboardEntry_High_Score_Leaderboard(data);});}
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
