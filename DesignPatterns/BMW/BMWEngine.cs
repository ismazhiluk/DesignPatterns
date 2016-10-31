using HW_2.Enum;
using HW_2.Interface;

namespace HW_2.BMW
{
    public class BMWEngine : IEngine
    {
        public EngineType Type => EngineType.Diesel;
        public double Power => 245;
    }
}
