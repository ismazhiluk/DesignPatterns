using HW_2.Interface;

namespace HW_2.AUDI
{
    public class AUDICarFactory : ICarFactory
    {
        public IBody CreateBody()
        {
            return new AUDIBody();
        }

        public IEngine CreateEngine()
        {
            return new AUDIEngine();
        }

        public IInterior CreateInterior()
        {
            return new AUDIInterior();
        }
    }
}
