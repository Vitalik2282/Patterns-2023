namespace Lab_02
{
    public sealed class HumanUnitsFactory : UnitFactory<HumanUnit>
    {
        public override string[] Names => new string[]
        {
            "John",
            "Max",
            "Jack",
            "Alexander",
            "Anton"
        };

        public override HumanUnit Create()
        {
            var result = base.Create();
            result.Damage = 5;
            return result;
        }
    }
}
