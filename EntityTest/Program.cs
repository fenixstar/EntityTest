using EntityTest.config;

namespace EntityTest
{
class Program
{
    static void Main(string[] args)
        {
            ConfigParser config = new ConfigParser(args[0]);
            Dictionary<string, Parameters> parameters = config.GetAllValue();
        }
}
}