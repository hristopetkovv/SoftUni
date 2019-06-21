namespace P01_RawData
{
    using System.Collections.Generic;
    using System.Linq;

    public class CarCatalog
    {
        private const int  tireCount=4;
        private List<Car> cars;
        private EngineFactory engineFactory;

        public CarCatalog(EngineFactory engineFactory)
        {
            this.cars = new List<Car>();
            this.engineFactory = engineFactory;
        }

        public void Add(string[] parameters)
        {
            string model = parameters[0];
            int engineSpeed = int.Parse(parameters[1]);
            int enginePower = int.Parse(parameters[2]);
            int cargoWeight = int.Parse(parameters[3]);
            string cargoType = parameters[4];

            Engine engine = engineFactory.Create(engineSpeed, enginePower);
            Cargo cargo = new Cargo(cargoWeight, cargoType);
            Tire[] tires = GetTires(parameters.Skip(5).ToList());   
            Car car = new Car(model, engine, cargo, tires);

            cars.Add(car);
        }

        public Tire[] GetTires(List<string> tireParameters)
        {
            Tire[] tires = new Tire[tireCount];

            int tireIndex = 0;

            for (int j = 0; j < 8; j += 2)
            {
                double tirePressure = double.Parse(tireParameters[j]);
                int tireAge = int.Parse(tireParameters[j + 1]);

                Tire tire = new Tire(tirePressure, tireAge);

                tires[tireIndex] = tire;

                tireIndex++;
            }

            return tires;
        }

        public List<Car> GetCars()
        {
            return this.cars;   
        }
    }
}
