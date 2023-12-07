namespace Lab_02
{
    public sealed class RobotUnitsFactory : UnitFactory<RobotUnit>
    {
        public override string[] Names => new string[]
        {
            "M-11",
            "R-11a",
            "F-112B",
            "JH-311",
            "B-2a-3f"
        };

        public override RobotUnit Create()
        {
            var result = base.Create();
            result.Damage = 7;
            result.Energy = 10;
            return result;
        }
    }
}
