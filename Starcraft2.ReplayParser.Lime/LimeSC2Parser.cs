using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starcraft2.ReplayParser;
using System.EnterpriseServices;
using System.Runtime.InteropServices;

namespace Starcraft2.ReplayParser.Lime
{
    [Guid("4FF89E3F-0246-4391-817E-50FECE518379")]
    [ClassInterface(ClassInterfaceType.None)]
    public class LimeSC2Parser : Starcraft2.ReplayParser.LimeSC2Parser.ILimeSC2Parser
    {
        public Replay parse(string filePath){
            Replay replay = Replay.Parse(filePath);
            return replay;
        }
    
    }

    
}
