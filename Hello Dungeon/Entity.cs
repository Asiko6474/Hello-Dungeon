using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Hello_Dungeon
{
    class Entity
    {
        private string _name;
        private float _health;
        private float _attackLevel;
        private float _defenseLevel;

        public string Name
        {
            get { return _name; }
        }

        public virtual float Health
        {
            get { return _health; }
        }

        public virtual float AttackLevel
        {
            get { return _attackLevel; }
        }

        public virtual float DefenseLevel
        {
            get { return _defenseLevel; }
        }

        //initializes a default entity
        public Entity()
        {
            _name = "John Doe";
        }
        public Entity(string name, float health, float attackLevel, float defenseLevel)
        {
            _name = name;
            _health = health;
            _attackLevel = attackLevel;
            _defenseLevel = defenseLevel;
        }

        //Allows entities to take damage during combat
        public float TakeDamage(float damageAmount)
        {
            float damageTaken = damageAmount - DefenseLevel;

            if (damageTaken < 0)
            {
                damageTaken = 0;
            }

            _health -= damageTaken;

            return damageTaken;
        }
        //allows entities to attack each other
        public float Attack(Entity defender)
        {
            return defender.TakeDamage(AttackLevel);
        }
        //saves entity data
        public virtual void Save(StreamWriter writer)
        {
            writer.WriteLine(_name);
            writer.WriteLine(_health);
            writer.WriteLine(_attackLevel);
            writer.WriteLine(_defenseLevel);
        }
        //loads entity data
        public virtual bool Load(StreamReader reader)
        {
            _name = reader.ReadLine();

            if (!float.TryParse(reader.ReadLine(), out _health))
                return false;

            if (!float.TryParse(reader.ReadLine(), out _attackLevel))
                return false;

            if (!float.TryParse(reader.ReadLine(), out _defenseLevel))
                return false;

            return true;
        }

    }
}
