namespace Objects
{
    public class GetHashCodeStatic
    {
        public int GetHashCode(string passportId)
        {
            return 137;
        }

        public GetHashCodeStatic Clone()
        {
            return new GetHashCodeStatic();
        }
    }

    public class GetHashCodeDynamic
    {
        public GetHashCodeDynamic Clone()
        {
            return new GetHashCodeDynamic();
        }
    }
}