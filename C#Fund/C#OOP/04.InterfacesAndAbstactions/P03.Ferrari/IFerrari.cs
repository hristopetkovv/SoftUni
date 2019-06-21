namespace P03.Ferrari
{
    public interface IFerrari
    {
        string Model { get;}

        string Driver { get;}

        string PushBrakes();

        string Gas();
    }
}
