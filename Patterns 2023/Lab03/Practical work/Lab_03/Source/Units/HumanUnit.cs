using System;

namespace Lab_02
{
    public sealed class HumanUnit : Unit
    {
        public const int UpgradeExperienseCost = 3; 
        public const int UpgradeAttackPerLevel = 2; 

        public int Experiense { get; private set; }
        public int Level { get; private set; }

        public override int MaxHealth => 35;

        public override void Attack(Unit otherTarget)
        {
            base.Attack(otherTarget);

            IncrementExperiense();
        }

        private void IncrementExperiense ()
        {
            Experiense++;
            if (Experiense >= UpgradeExperienseCost)
            {
                Experiense = 0;
                Level++;

                Console.WriteLine($"\n{this} level up to {Level}. Attack now: {Damage} + {UpgradeAttackPerLevel}");
                Damage += UpgradeAttackPerLevel;
            }
        }

        public override object Clone()
        {
            var result = base.Clone() as HumanUnit;
            result.Experiense = Experiense;
            result.Level = Level;
            return result;
        }

        public override string ToString()
        {
            return $"{base.ToString()} [Level: {Level},  Exp: {Experiense}]";
        }
    }
}