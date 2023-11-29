global using Grpc.Core;
using static Pantheon.Shared.Utility.ClsAes;

namespace bwaCrixalis.Server._1._Master;
public class svsCompany : svpMasterCompany.svpMasterCompanyBase
{
	private readonly ILogger<svsCompany> _logger;
	private readonly ISvdCompany _svdCompany;
	public svsCompany(ILogger<svsCompany> logger, ISvdCompany svdCompany)
	{
		_logger = logger;
		_svdCompany = svdCompany;
	}

	#region 'Views'
	public override async Task<RplCompanyById> GetCompanyById(RqsCompanyById request, ServerCallContext context)
	{
		var Company = await _svdCompany.GetCompanyById(request.IdCompany);
		return Company.Adapt<RplCompanyById>();
	}
	public override async Task<RplCompany> GetCompany(RqsCompany request, ServerCallContext context)
	{
		var listCompany = await _svdCompany.GetCompany();
		/*listCompany.ForEach(company =>
        {
            company.Nama = Decrypt(company.Nama);
            company.Inisial = Decrypt(company.Inisial);
		});*/
        var reply = new RplCompany();
		reply.RpfCompany.AddRange(listCompany.Adapt<IEnumerable<RplCompanyById>>());
		return reply;
	}
	#endregion

	#region 'Procedure'
	public override async Task<RplWriteCompany> InsertCompany(RqsInsertCompany request, ServerCallContext context)
	{
		request.Nama = Encrypt(request.Nama);
        request.Inisial = Encrypt(request.Inisial);
        var hasil = await _svdCompany.InsertCompany(request.Adapt<pthT0Company>());
		return new RplWriteCompany { IsOK = true, Result = hasil };
	}
	public override async Task<RplWriteCompany> UpdateCompany(RqsUpdateCompany request, ServerCallContext context)
    {
        request.Nama = Encrypt(request.Nama);
        request.Inisial = Encrypt(request.Inisial);
        var hasil = await _svdCompany.UpdateCompany(request.Adapt<pthT0Company>());
		return new RplWriteCompany { IsOK = true, Result = hasil };
	}
	public override async Task<RplWriteCompany> DeleteCompany(RqsDeleteCompany request, ServerCallContext context)
	{
		var hasil = await _svdCompany.DeleteCompany(request.Adapt<pthT0Company>());
		return new RplWriteCompany { IsOK = true, Result = hasil };
	}
	#endregion
}
