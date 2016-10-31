namespace HW_2.Interface
{
    public interface ICarFactory
    {
        IBody CreateBody();
        IEngine CreateEngine();
        IInterior CreateInterior();
    }
}