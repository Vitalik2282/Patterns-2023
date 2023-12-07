using System;

namespace Lab_02
{
    public abstract class Unit : ICloneable
    {
        public abstract int MaxHealth { get; }

        public string Name;
        public int Health;
        public int Damage;

        public bool IsDead =>
            Health <= 0;

        public virtual void Attack(Unit otherTarget)
        {
            otherTarget.TakeHealth(Damage);
            GameManager.Instance.Log($"{Name} attack {otherTarget.Name} (-{Damage} health)");
        }

        public virtual void TakeHealth (int count)
        {
            Health -= count;
        }

        public override string ToString()
        {
            var format = "{0,-15} {1,-15} {2,-8} {3,-8}";
            return string.Format(format, Name, GetType().Name, $"HP: {Health}/{MaxHealth}", $"Damage: {Damage}");
        }

        public virtual object Clone()
        {
            var currentType = GetType();
            if(currentType.IsAbstract == false &&
                currentType.IsSubclassOf(typeof(Unit)))
            {
                var result = (Unit)Activator.CreateInstance(currentType);

                result.Name = Name;
                result.Health = Health;
                result.Damage = Damage;

                return result;
            }
            else
            {
                throw new Exception($"Cannot clone {currentType.Name}");
            }
        }
    }

    public enum UnitRaceType
    {
        Human,
        Robot
    }
}
