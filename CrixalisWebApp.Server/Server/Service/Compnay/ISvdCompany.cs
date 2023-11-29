using Pantheon.Shared.BaseEntityModels;

namespace bwaCrixalis.Server._1._Master;
public interface ISvdCompany
{
	Task<pthT0Company> GetCompanyById(string idCompany);
	Task<IEnumerable<pthT0Company>> GetCompany();
	Task<string> InsertCompany(pthT0Company pthT0Company);
	Task<string> UpdateCompany(pthT0Company pthT0Company);
	Task<string> DeleteCompany(pthT0Company pthT0Company);
}
