using DungeonBattler.Data;
using DungeonBattler.Models;
using DungeonBattler.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DungeonBattler.Controllers
{
    [Authorize]
    public class BattlefieldController : Controller
    {
        private readonly GameContext _context;

        private List<string> _log = new List<string>();

        public BattlefieldController(GameContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var units = _context.NonPlayerChar.ToList();
            var pepos = _context.PlayerChar.ToList();

            _log.Append("Initial log");

            var viewModel = new BattlefieldViewModel
            {
                Units = units,
                Pepos = pepos,
                Log = _log
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EndRound()
        {

            DealDamageToNPC();
            DealDamageToPC();


            _context.SaveChanges();

            Console.WriteLine("Round Ended!"); 
            _log.Append("---Round Ended!");


            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Restore()
        {
            RestoreHealth();
            RestoreStats();

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UsePotion(string type)
        {
            // Hrdina se nacte databaze, jenom prvni
            var hero = _context.PlayerChar.FirstOrDefault();

            if (hero != null)
            {
                switch (type)
                {
                    case "strength":
                        hero.Strength += 5;
                        break;
                    case "dexterity":
                        hero.Dexterity += 5;
                        break;
                    case "intelligence":
                        hero.Inteligence += 5;
                        break;
                }

                // Zapiseme do databaze stav hrdiny
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        private void DealDamageToNPC()
        {
            // nacteni z databaze 
            var NPC = _context.NonPlayerChar.ToList();
            var PC = _context.PlayerChar.ToList();

            int damage = 0;

            foreach (var hero in PC)
            {
                if (hero.Health > 0) {
                    damage += hero.Attack;
                }
            }

            var unit = NPC.Last();




            // kontrola, jestli jsou unity mertve
            while (unit.Health <= 0) 
            {
                unit.Health = 0;

                if (unit == NPC.First()) {
                    Console.WriteLine("All enemies are dead");
                    return;
                }

                NPC.Remove(unit);
                unit = NPC.Last();

            }


            unit.Health -= damage;
            if (unit.Health <= 0) {
                unit.Health = 0;
            }
            Console.WriteLine($"Heroes dealt: {damage} to {unit.Name}!!!");

            

           
        }

        private void DealDamageToPC()
        {
            var NPC = _context.NonPlayerChar.ToList();
            var PC = _context.PlayerChar.ToList();

            int damage = 0;

            foreach (var npc in NPC)
            {
                if (npc.Health > 0)
                {
                    damage += npc.Attack;
                }
            }

            var unit = PC.First();


            while (unit.Health <= 0)
            {
                unit.Health = 0;

                if (unit == PC.Last())
                {
                    Console.WriteLine("All Heroes are dead");
                    return;
                }

                PC.Remove(unit);
                unit = PC.First();

            }

            unit.Health -= damage;
            if (unit.Health <= 0)
            {
                unit.Health = 0;
            }
            Console.WriteLine($"Monsters dealt: {damage} to {unit.Name}!!!");

        }
        private void RestoreHealth() {
            var units = _context.NonPlayerChar.ToList();
            var pepos = _context.PlayerChar.ToList();

            // Obnovit zdraví všech unitů z databaze
            foreach (var unit in units)
            {
                unit.Health = unit.BaseHealth;
            }
            foreach (var unit in pepos)
            {
                unit.Health = unit.BaseHealth;
            }
        }

        private void RestoreStats() {
            var pepos = _context.PlayerChar.ToList();

            // Obnovi staty všech hrdinů z databaze
            foreach (var unit in pepos)
            {
                unit.Strength = unit.BaseStrength;
                unit.Dexterity = unit.BaseDexterity;
                unit.Inteligence = unit.BaseInteligence;
            }

        }


    }

    
}
