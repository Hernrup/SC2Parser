using System;
using System.Runtime.InteropServices;
namespace Starcraft2.ReplayParser.LimeSC2Parser
{
    [Guid("7F23415C-690A-431F-9194-25A979E363BF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface ILimeSC2Parser
    {
        Starcraft2.ReplayParser.Replay parse(string filePath);
    }
}
