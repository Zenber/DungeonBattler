namespace DungeonBattler.ViewModels
{
    using DungeonBattler.Models;
    using System.Collections.Generic;

    public class BattlefieldViewModel
    {
        public List<NonPlayerChar>? Units { get; set; }
        public List<PlayerChar>? Pepos { get; set; }
        public List<String>? Log { get; set; }
    }
}
