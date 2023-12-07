namespace Lab_02
{
    public sealed class RobotUnit : Unit
    {
        public int Energy;

        public override int MaxHealth => 55;

        public override void Attack(Unit otherTarget)
        {
            base.Attack(otherTarget);

            TakeEnergy();
        }

        private void TakeEnergy ()
        {
            Energy--;
            if (Energy <= 0)
                Health = 0;
        }

        public override object Clone()
        {
            var result = base.Clone() as RobotUnit;
            result.Energy = Energy;
            return result;
        }

        public override string ToString()
        {
            return $"{base.ToString()} [Energy: {Energy}]";
        }
    }
}
