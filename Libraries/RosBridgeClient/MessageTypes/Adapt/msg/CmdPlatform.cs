/*
© Siemens AG, 2017-2018
Author: Dr. Martin Bischoff (martin.bischoff@siemens.com)

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
<http://www.apache.org/licenses/LICENSE-2.0>.
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using System.Runtime.Serialization;

using RosSharp.RosBridgeClient.MessageTypes.Std;

namespace RosSharp.RosBridgeClient.Messages.Adapt
{
    public class CmdPlatform : Message
    {
        [IgnoreDataMember]
        public const string RosMessageName = "adapt_msgs/CmdPlatform";
        public Header header;
        public float pitch;
        public float roll;
        public float yaw;
        public float heave;
        public float rpm;
        public float torque;
        public CmdPlatform()
        {
            header = new Header();
            pitch = 0;
            roll = 0;
            yaw = 0;
            heave = 0;
            rpm = 0;
            torque = 0;
        }
    }
}