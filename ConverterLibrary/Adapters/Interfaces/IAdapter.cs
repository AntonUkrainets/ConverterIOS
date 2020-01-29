using System.Threading.Tasks;

namespace Converter.Adapters.Interfaces
{
    public interface IAdapter
    {
        Task<string> GetRate(string curFrom, string curTo, string input);
    }
}