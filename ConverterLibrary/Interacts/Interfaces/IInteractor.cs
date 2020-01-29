using System.Threading.Tasks;

namespace Converter.Interacts.Implements
{
    public interface IInteractor
    {
        Task<decimal> GetRate(string curFrom, string curTo, string input);
    }
}