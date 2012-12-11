// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Player.cs" company="SC2ReplayParser">
//   Copyright © 2011 All Rights Reserved
// </copyright>
// <summary>
//   Describes an individual player in a replay.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;

namespace Starcraft2.ReplayParser
{
    using System.Collections.Generic;
    using System.EnterpriseServices;
    using System.Runtime.InteropServices;
    using System.ComponentModel;
    using System.IO;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows.Forms;

    /// <summary>
    /// Describes an individual player in a replay.
    /// </summary>
    /// 
    [Guid("0D2C85C0-7E29-4DC3-8690-41EFB8DD4456")]
    [ClassInterface(ClassInterfaceType.None)]
    public class Parser : Starcraft2.ReplayParser.IParser
    {

        public string path { get; set; }

        public Parser() {
            this.path = "";
        }

        public Replay parse()
        {
            Replay replay = Replay.Parse(this.path);
            return replay;
        }

        public void selectFile() {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "replay files (*.SC2Replay)|*.*";
            dialog.InitialDirectory = GetDefaultReplayDirectory();
            dialog.Title = "Select a replay file";
            this.path = (dialog.ShowDialog() == DialogResult.OK) ? dialog.FileName : "";
        }

        public string GetDefaultReplayDirectory()
        {
            // The following gets a user's Starcraft II replay folder automatically.
            var sc2Accounts = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Starcraft II", "Accounts");

            if (Directory.Exists(sc2Accounts) == false)
            {
                Console.Out.WriteLine("Starcraft II is not installed on the system.");
                return null;
            }

            var accounts = Directory.GetDirectories(sc2Accounts);
            var selectedAccount = accounts.FirstOrDefault();

            if (selectedAccount == null || Directory.Exists(selectedAccount) == false)
            {
                // This likely shouldn't happen. I don't think these folders would
                // get created until the user has logged into the game for the first time.
                Console.Out.WriteLine("The user has never played Starcraft II, but it is installed.");
                return null;
            }

            var players = Directory.GetDirectories(selectedAccount);
            var selectedPlayer = players.FirstOrDefault();

            if (selectedPlayer == null || Directory.Exists(selectedPlayer) == false)
            {
                // I'm not sure why this would happen either. You CAN, however, have multiple players
                // registered to a single account. For example, my EU and US accounts were merged onto
                // a single account, and both players (with 1- and 2- regions) show up here.
                Console.Out.WriteLine("The user has never played Starcraft II, but it is installed.");
                return null;
            }

            var replayFolder = Path.Combine(selectedPlayer, "Replays", "Multiplayer");

            if (replayFolder == null || Directory.Exists(replayFolder) == false)
            {
                // This can happen if the user just has never saved any replays.
                Console.Out.WriteLine("The replay directory for the selected user does not exist.");
                return null;
            }

            return replayFolder;
        }


        public string getEnumName(string type, int value){
            Type t = null;
            switch(type){
                case "GameSpeed":
                    t = typeof(GameSpeed);
                    break;
                case "GameType":
                    t = typeof(GameType);
                    break;
                case "Race":
                    t = typeof(Race);
                    break;
                case "Difficulty":
                    t = typeof(Difficulty);
                    break;
            }
            if(t.Equals(null)){
                return "N/A";
            }else{
                return Enum.GetName(t, value);
            }
        }

    }
}