using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSystem
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public IList<int> SeqNum { get; private set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize, List<int> seqNum)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            SeqNum = seqNum;
            this.AddRange(items);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        public static async Task<PaginatedList<T>> CreateAsync(
            IQueryable<T> source, int pageIndex, int pageSize)
        {
            if (pageIndex > 0 && pageIndex <= Math.Ceiling((double)source.ToList().Count / (double)pageSize))
            {
                var count = await source.CountAsync();
                var items = await source.Skip(
                    (pageIndex - 1) * pageSize)
                    .Take(pageSize).ToListAsync();

                var seqNum = Enumerable.Range(1, count).Skip(
                    (pageIndex - 1) * pageSize)
                    .Take(pageSize).ToList();

                return new PaginatedList<T>(items, count, pageIndex, pageSize, seqNum);
            }
            else
            {
                var count = await source.CountAsync();
                var items = await source
                    .Take(pageSize).ToListAsync();

                var seqNum = Enumerable.Range(1, count)
                    .Take(pageSize).ToList();

                return new PaginatedList<T>(items, count, pageIndex, pageSize, seqNum);
            }
        }

        public static PaginatedList<T> CreateFromList(
            IList<T> source, int pageIndex, int pageSize)
        {
            if (pageIndex > 0 && pageIndex <= Math.Ceiling((double)source.Count / (double)pageSize))
            {
                var count = source.Count();
                var items = source.Skip(
                    (pageIndex - 1) * pageSize)
                    .Take(pageSize).ToList();

                var seqNum = Enumerable.Range(1, count).Skip(
                    (pageIndex - 1) * pageSize)
                    .Take(pageSize).ToList();

                return new PaginatedList<T>(items, count, pageIndex, pageSize, seqNum);
            }
            else
            {
                var count = source.Count();
                var items = source
                    .Take(pageSize).ToList();

                var seqNum = Enumerable.Range(1, count)
                    .Take(pageSize).ToList();

                return new PaginatedList<T>(items, count, pageIndex, pageSize, seqNum);
            }
        }
    }
}
