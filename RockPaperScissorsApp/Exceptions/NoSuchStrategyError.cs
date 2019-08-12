using System;

namespace RockPaperScissorsApp.Exceptions
{
    [Serializable()]
    class NoSuchStrategyError : Exception
    {
        public NoSuchStrategyError() : base() { }
        public NoSuchStrategyError(string message) : base(message) { }
        public NoSuchStrategyError(string message, System.Exception inner) : base(message, inner) { }

        protected NoSuchStrategyError(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
