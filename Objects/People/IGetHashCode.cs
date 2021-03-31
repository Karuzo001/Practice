namespace Objects.People
{
    public interface IGetHashCode
    {
        int GetHashCode(string passportId);
    }

    public class GetHashCodeStatic : IGetHashCode
    {
        public int GetHashCode(string passportId)
        {
            return 137;
        }
    }

    public class GetHashCodeDynamic : IGetHashCode
    {
        public int GetHashCode(string passportId)
        {
            return passportId.GetHashCode();
        }
    }
}