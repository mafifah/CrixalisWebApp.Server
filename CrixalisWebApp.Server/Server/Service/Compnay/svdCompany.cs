global using Pantheon.Shared.BaseEntityModels;
global using Pantheon.Server.ServiceDomains;
global using Pantheon.Server.ServiceDraft;
global using Pantheon.Server.Repositories.RepoGeneric;
global using Pantheon.Server.DataAccess;
global using static Pantheon.Server.Utility.modExtensions;

namespace bwaCrixalis.Server._1._Master; 
public class svdCompany : pthSvdBaseMaster, ISvdCompany
{
	private readonly pthIUnitOfWork _uow;
	private readonly pthIRepoGeneric<pthT0Company> _repopthT0Company;

	public svdCompany(pthIUnitOfWork uow)
	{
		_uow = uow;
		_repopthT0Company = _uow.GetRepository<pthRepoGeneric<pthT0Company>>();
	}

	public async Task<pthT0Company> GetCompanyById(string idCompany) => await _repopthT0Company.GetById(idCompany);
	public async Task<IEnumerable<pthT0Company>> GetCompany() => await _repopthT0Company.GetAll();

	public async Task<string> InsertCompany(pthT0Company pthT0Company)
	{
		InsertHeader(pthT0Company);
		_repopthT0Company.Insert(pthT0Company);
		await _uow.Selesai();
		return pthT0Company.IdCompany.ToString();
	}
	public async Task<string> UpdateCompany(pthT0Company pthT0Company)
	{
		var DbpthT0Company = _repopthT0Company.GetById(pthT0Company.IdCompany.ToString()).Result;
		if (DbpthT0Company is not null)
		{
			pthT0Company.Adapt(DbpthT0Company);
			await _uow.Selesai();
		}
		return pthT0Company.IdCompany.ToString();
	}
	public async Task<string> DeleteCompany(pthT0Company pthT0Company)
	{
		_repopthT0Company.Delete(pthT0Company);
		await _uow.Selesai();
		return pthT0Company.IdCompany.ToString();
	}
}
