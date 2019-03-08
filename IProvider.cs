using System.Threading.Tasks;

namespace NameChk.CLI
{
    interface IProvider
    {
        Task<(string, bool)>[] CheckAvailability(string[] names);
    }
}