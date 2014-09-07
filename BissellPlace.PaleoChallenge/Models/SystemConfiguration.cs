using System.Configuration;
using BissellPlace.PaleoChallenge.Framework;

namespace BissellPlace.PaleoChallenge.Models
{
    public class SystemConfiguration : ISystemConfiguration
    {
        public SystemConfiguration()
        {
            CreateNewDatabase = bool.Parse(ConfigurationManager.AppSettings["CreateNewDatabase"]);          
        }

        public bool CreateNewDatabase { get; private set; }
    }
}