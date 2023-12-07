using System;
using System.Linq;

namespace Lab_02
{
    public abstract class PlayerBase<UnitType> : IPlayer
        where UnitType : Unit
    {
        public virtual ConsoleColor TextColor { get; } = ConsoleColor.Red;
        public virtual int ChanceOfBooster { get; } = 2;

        public UnitType[] Army { get; private set; }

        protected UnitFactory<UnitType> factory;

        protected virtual void CreateArmy (int unitsCount)
        {
            Army = new UnitType[unitsCount];
            for (var x = 0; x < unitsCount; x++)
                CreateUnit(x);
        }

        protected virtual void CreateUnit (int arrayIndex)
        {
            Army[arrayIndex] = factory.Create();
        }

        internal void CloneUnit (int index)
        {
            if(index >= 0 && index < Army.Length)
            {
                var clone = Army[index].Clone() as UnitType;

                var tmp = Army.ToList();
                tmp.Add(clone);
                Army = tmp.ToArray();
            }
        }

        public abstract void PlayTurn();

        public void RemoveDeadUnits()
        {
            var needRepeat = true;
            while (needRepeat)
            {
                needRepeat = false;
                var tmp = Army.ToList();

                for (var x = 0; x < Army.Length; x++)
                {
                    if (Army[x].IsDead)
                    {
                        tmp.RemoveAt(x);
                        Army = tmp.ToArray();
                        needRepeat = true;
                        break;
                    }
                }
            }
        }

        public bool IsDefeat
        {
            get
            {
                if (Army.Length == 0)
                    return true;
                
                for(var x = 0; x < Army.Length; x++)
                {
                    if (Army[x].IsDead == false)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public void ShowStatus()
        {
            Console.ForegroundColor = TextColor;
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            var result = $"{GetType().Name} status:\n";
            for(var x = 0; x < Army.Length; x++)
            {
                if(x > 0) result += "\n";
                result += "\t" + Army[x].ToString();
            }

            return result;
        }
    }
}