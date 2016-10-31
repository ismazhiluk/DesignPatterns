using HW_2.Enum;
using HW_2.Interface;

namespace HW_2.AUDI
{
    public class AUDIEngine : IEngine
    {
        public EngineType Type => EngineType.Turbine;
        public double Power => 230;
    }
}
