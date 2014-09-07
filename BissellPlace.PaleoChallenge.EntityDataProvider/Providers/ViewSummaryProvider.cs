using System;
using System.Collections.Generic;
using System.Linq;
using BissellPlace.PaleoChallenge.Framework.DataAccess;
using BissellPlace.PaleoChallenge.Framework.DomainModel;
using BissellPlace.PaleoChallenge.Framework.Providers;

namespace BissellPlace.PaleoChallenge.EntityDataProvider.Providers
{
 
    public class ViewSummaryProvider : IViewSummaryProvider
    {
        private readonly IEntryRepository _entryRepository;
        private readonly IWeightEntryRepository _weightRepository;
        private readonly ICommentEntryRepository _commentRepository;
        private readonly IPointEntryRepository _pointRepository;

        public ViewSummaryProvider(IEntryRepository entryRepository, IWeightEntryRepository weightRepository, ICommentEntryRepository commentRepository, IPointEntryRepository pointRepository)
        {
            _entryRepository = entryRepository;
            _weightRepository = weightRepository;
            _commentRepository = commentRepository;
            _pointRepository = pointRepository;
        }

        public IEnumerable<ILinkEntry> GetWeekSummary()
        {
            var sevenDaysBack = DateTime.Now.AddDays(-7);
            var entries = _entryRepository.Query(n => n.TimeStamp > sevenDaysBack).Select(n => n.Id).ToList();

            var weights = _weightRepository.Query(n=>entries.Contains(n.Record.Id)).ToList<ILinkEntry>();
            var points = _pointRepository.Query(n=>entries.Contains(n.Record.Id)).ToList<ILinkEntry>();
            var comments = _commentRepository.Query(n=>entries.Contains(n.Record.Id)).ToList<ILinkEntry>();

            return weights.Concat(points).Concat(comments).OrderBy(n => n.Record.TimeStamp);
        }
    }
}