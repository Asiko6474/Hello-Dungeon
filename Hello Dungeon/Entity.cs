using System;
using System.Collections.Generic;
using System.Text;

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

        public float Attack(Entity defender)
        {
            return defender.TakeDamage(AttackLevel);
        }
    }
}
