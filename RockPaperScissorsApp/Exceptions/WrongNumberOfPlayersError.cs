using System;

namespace RockPaperScissorsApp.Exceptions
{
    [Serializable()]
    public class WrongNumberOfPlayersError : Exception
    {
        public WrongNumberOfPlayersError() : base() { }
        public WrongNumberOfPlayersError(string message) : base(message) { }
        public WrongNumberOfPlayersError(string message, System.Exception inner) : base(message, inner) { }

        protected WrongNumberOfPlayersError(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
