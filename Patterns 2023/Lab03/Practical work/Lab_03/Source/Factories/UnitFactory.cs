using System;

namespace Lab_02
{
    public abstract class UnitFactory<T> where T : Unit
    {
        public abstract string[] Names { get; }

        public virtual T Create ()
        {
            var result = Activator.CreateInstance<T> ();
            result.Name = GetRandomName();
            result.Health = result.MaxHealth;
            return result;
        }

        private int randomOffset = 0;

        public string GetRandomName ()
        {
            var random = new Random(++randomOffset + DateTime.Now.Millisecond);
            return Names[random.Next(0, Names.Length)];
        }
    }
}