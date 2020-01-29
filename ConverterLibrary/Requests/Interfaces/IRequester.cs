using System.Threading.Tasks;

namespace Converter
{
    public interface IRequester
    {
        Task<decimal> GetRate(int fromCur, int toCur);
    }
}