/*
Shimadzu corp , 2019, Akira NODA (a-noda@shimadzu.co.jp / you.akira.noda@gmail.com)

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

// Please check out https://gist.github.com/akirayou/0a444f0081acd1f268804af0347957f9
// for a NTP implementation of the Timer class


using System;
using UnityEngine;
using std_msgs = RosSharp.RosBridgeClient.MessageTypes.Std;

namespace RosSharp.RosBridgeClient
{
    public class FixedTimer : Timer
    {
        public override std_msgs.Time Now()
        {
            std_msgs.Time stamp = new std_msgs.Time();
            float time = Time.fixedTime;
            stamp.secs = (uint)time;
            stamp.nsecs = (uint)(1e9 * (time - stamp.secs));
            return stamp;
        }

        public override void Now(std_msgs.Time stamp)
        {
            float time = Time.fixedTime;
            stamp.secs = (uint)time;
            stamp.nsecs = (uint)(1e9 * (time - stamp.secs));
        }
    }
}