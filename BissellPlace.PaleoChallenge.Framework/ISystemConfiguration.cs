using System.Security.Cryptography.X509Certificates;

namespace BissellPlace.PaleoChallenge.Framework
{
    public interface ISystemConfiguration
    {
        bool CreateNewDatabase { get; }
    }
}