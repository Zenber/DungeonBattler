namespace DungeonBattler.Models
{
    public class NonPlayerChar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }

        public int BaseHealth { get; set; }
        public int BaseAttack { get; set; }
    }
}
