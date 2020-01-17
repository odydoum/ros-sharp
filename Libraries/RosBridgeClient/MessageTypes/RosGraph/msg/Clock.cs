
using System.Runtime.Serialization;

using RosSharp.RosBridgeClient.MessageTypes.Std;

namespace RosSharp.RosBridgeClient.Messages.RosGraph
{
    public class Clock : Message
    {
        [IgnoreDataMember]
        public const string RosMessageName = "rosgraph_msgs/Clock";
        public Time clock;
        public Clock()
        {
            clock = new Time();
        }
    }
}
