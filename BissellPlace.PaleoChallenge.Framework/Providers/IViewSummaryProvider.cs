using System.Collections.Generic;
using BissellPlace.PaleoChallenge.Framework.DomainModel;

namespace BissellPlace.PaleoChallenge.Framework.Providers
{
    public interface IViewSummaryProvider
    {
        IEnumerable<ILinkEntry> GetWeekSummary();
    }
}