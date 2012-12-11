using System;
using System.Runtime.InteropServices;
namespace Starcraft2.ReplayParser
{
    [Guid("A742D9AE-6840-4331-86D9-D562C576CF3A")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IReplay
    {
        System.Collections.Generic.IList<ChatMessage> ChatMessages { get; }
        Player[] ClientList { get; }
        TimeSpan GameLength { get; }
        string GameLengthText {get;}
        GameSpeed GameSpeed { get; }
        GameType GameType { get; }
        System.Collections.Generic.Dictionary<int, Unit> GameUnits { get; }
        string Gateway { get; }
        Player GetPlayerById(int playerId);
        Unit GetUnitById(int unitId);
        string Map { get; }
        string MapGateway { get; }
        byte[] MapHash { get; }
        string MapPreviewName { get; }
        System.Collections.Generic.List<IGameEvent> PlayerEvents { get; }
        Player[] Players { get; }
        System.Collections.ArrayList PlayersList { get; }
        int ReplayBuild { get; }
        string ReplayVersion { get; }
        string TeamSize { get; }
        DateTime Timestamp { get; }
  
    }
}
