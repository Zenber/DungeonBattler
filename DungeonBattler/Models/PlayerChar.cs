namespace DungeonBattler.Models
{
    public class PlayerChar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Inteligence { get; set; }

        public int BaseHealth { get; set; }
        public int BaseAttack { get; set; }
        public int BaseStrength { get; set; }
        public int BaseDexterity { get; set; }
        public int BaseInteligence { get; set; }
    }
}
