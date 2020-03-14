namespace Kata
{
    public class DirectOutputGenerator : OutputByNumberGenerator
    {
        public string GenerateOutputByNumber(int number)
        {
            return number.ToString();
        }
    }
}