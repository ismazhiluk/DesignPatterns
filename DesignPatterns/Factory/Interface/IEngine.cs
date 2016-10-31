using HW_2.Enum;

namespace HW_2.Interface
{
    public interface IEngine
    {
        EngineType Type { get; }
        double Power { get; }
    }
}
