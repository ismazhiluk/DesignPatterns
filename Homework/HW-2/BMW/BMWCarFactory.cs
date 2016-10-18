using HW_2.Interface;

namespace HW_2.BMW
{
    public class BMWCarFactory : ICarFactory
    {
        public IBody CreateBody()
        {
            return new BMWBody();
        }

        public IEngine CreateEngine()
        {
            return new BMWEngine();
        }

        public IInterior CreateInterior()
        {
            return new BMWInterior();
        }
    }
}
