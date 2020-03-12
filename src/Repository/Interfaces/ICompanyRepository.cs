using Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ICompanyRepository: IRepository<Company>
    {
        Task<Company> GetCompanyAddress(Guid id);
        Task<Company> GetCompanyJobOffersAddress(Guid id);
    }

    public static class ICompanyRepositoryEx
    {
        public static IQueryable<Company> WithId(this IQueryable<Company> company, Guid? id)
        {
            if (!id.HasValue)
                return company;

            return company.Where(c => c.Id == id.Value);
        }
        public static IQueryable<Company> WithDocument(this IQueryable<Company> company, string document)
        {
            if (string.IsNullOrWhiteSpace(document))
                return company;

            return company.Where(c => c.Document == document);
        }
    }
}
