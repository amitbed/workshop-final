using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumTests
{
    class Driver
    {
        public static BridgeProject getBridge()
        {
            BridgeProxy bridge = new BridgeProxy();
            bridge.setRealBridge(new realProject());
            return bridge;
        }
    }
}
