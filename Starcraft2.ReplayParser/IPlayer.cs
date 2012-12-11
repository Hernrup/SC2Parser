using System;
using System.Runtime.InteropServices;
namespace Starcraft2.ReplayParser
{
    [Guid("E5A5C281-2745-4CCF-8C37-0A9DBF4DE3AA")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IPlayer
    {
        int BattleNetId { get; set; }
        int BattleNetSubId { get; set; }
        string Color { get; set; }
        Difficulty Difficulty { get; set; }
        int Handicap { get; set; }
        bool IsWinner { get; set; }
        string Name { get; set; }
        PlayerType PlayerType { get; set; }
        string Race { get; set; }
        Race SelectedRace { get; set; }
        int Team { get; set; }
        string ToString();
    }
}
