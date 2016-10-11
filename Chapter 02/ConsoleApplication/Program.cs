
using Chapter02;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonDomain pd = new PersonDomain();
            pd.RegenerateData(1000);
        }
    }
}
