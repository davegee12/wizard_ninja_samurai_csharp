using System;
using System.Collections.Generic;

namespace WizardNinjaSamurai
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Dave = new Human("Dave");
            Wizard Gandolf = new Wizard("Gandolf");
            Ninja Shredder = new Ninja("Shredder");
            Samurai Kyoto = new Samurai("Kyoto");
            Dave.Attack(Shredder);
            Gandolf.Attack(Shredder);
            Kyoto.Attack(Gandolf);
            Shredder.Attack(Gandolf);
            Gandolf.Heal(Kyoto);
            Shredder.Steal(Kyoto);
            Kyoto.Meditate();

        }
    }
    public class Human
    {
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        protected int health;
        public int Health
        {
            get { return health; }
            set{ health = value; }
        }
        public Human(string name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;
        }
        public Human(string name, int strength, int intelligence, int dexterity, int hp)
        {
            Name = name;
            Strength = strength;
            Intelligence = intelligence;
            Dexterity = dexterity;
            health = hp;
        }
        public virtual int Attack(Human target)
        {
            int Damage = 5 * Strength;
            Console.WriteLine(target.health);
            target.health -= Damage;
            Console.WriteLine(target.health);
            return target.health;
        }
    }
    public class Wizard : Human
    {
        public Wizard(string name) : base(name,3,25,3,50){}
        public override int Attack(Human target)
        {
            int Damage = 5 * Intelligence;
            Console.WriteLine($"{target.Name}'s health is at " +target.Health);
            Console.WriteLine($"{Name}'s health is at " + health);
            target.Health -= Damage;
            health += Damage;
            Console.WriteLine("ATTACK IN PROGRESS!");
            Console.WriteLine($"{target.Name}'s health is at " +target.Health);
            Console.WriteLine($"{Name}'s health is at " + health);
            return target.Health;
        }
        public int Heal(Human target)
        {
            int Favor = 10 * Intelligence;
            Console.WriteLine($"{target.Name}'s health is at " +target.Health);
            target.Health += Favor;
            Console.WriteLine("HEALING IN PROGRESS!");
            Console.WriteLine($"{target.Name}'s health is at " +target.Health);
            return target.Health;
        }
    }
    public class Ninja : Human
    {
        public Ninja(string name) : base(name,3,3,175,100){}
        public override int Attack(Human target)
        {
            Random rand = new Random();
            int criticalHit = rand.Next(0,10);
            if(criticalHit == 0 || criticalHit == 1)
            {
                int Damage = 5 * Dexterity;
                Damage += 10;
                Console.WriteLine($"{target.Name}'s health is at " +target.Health);
                Console.WriteLine($"{Name}'s health is at " + health);
                target.Health -= Damage;
                Console.WriteLine("ATTACK IN PROGRESS!");
                Console.WriteLine($"{target.Name}'s health is at " +target.Health);
                Console.WriteLine($"{Name}'s health is at " + health);
                return target.Health;
            }
            else
            {
                int Damage = 5 * Dexterity;
                Console.WriteLine($"{target.Name}'s health is at " +target.Health);
                Console.WriteLine($"{Name}'s health is at " + health);
                target.Health -= Damage;
                Console.WriteLine("ATTACK IN PROGRESS!");
                Console.WriteLine($"{target.Name}'s health is at " +target.Health);
                Console.WriteLine($"{Name}'s health is at " + health);
                return target.Health;
            }
        }
        public int Steal(Human target)
        {
            Console.WriteLine($"{target.Name}'s health is at " +target.Health);
            Console.WriteLine($"{Name}'s health is at " + health);
            target.Health -= 5;
            health += 5;
            Console.WriteLine("ROBBERY IN PROGRESS!");
            Console.WriteLine($"{target.Name}'s health is at " +target.Health);
            Console.WriteLine($"{Name}'s health is at " + health);
            return target.Health;
        }
    }
    public class Samurai : Human
    {
        public Samurai(string name) : base(name,3,3,3,200){}
        public override int Attack(Human target)
        {
            if(target.Health < 50)
            {
                target.Health = 0;
                return target.Health;
            }
            else
            {
                base.Attack(target);
                return target.Health;
            }
        }
        public int Meditate()
        {
            health = 200;
            return Health;
        }
    }
}
