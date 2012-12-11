using System;
using System.Runtime.InteropServices;
namespace Starcraft2.ReplayParser
{
    [Guid("98D8AB85-10CC-471B-A8A5-961F9211122D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IParser
    {
        string path { get; set; }
        Replay parse();
        void selectFile();
        string GetDefaultReplayDirectory();
        string getEnumName(string type, int value);
    }
}
