global using Pantheon.Services;
global using Mapster;
using static bwaCrixalis.Shared._1._Master.svpMasterSupplier;
using Pantheon.Client.Services;
using static Pantheon.Client.Utility.modVariabel;
using bwaCrixalis.Shared._1._Master;

namespace bwaCrixalis.Client._1._Master;
public class svcSupplierInstansi : pthBaseService
{
	private svpMasterSupplierClient _client { get; set; }

	public svcSupplierInstansi()
	{
		_client = new svpMasterSupplierClient(ClientChannel);
	}

	public async Task<IEnumerable<uimT1SupplierInstansi>> GetDataSupplierInstansi()
	{
		var rplSupplier = await _client.GetSupplierAsync(new RqsSupplier(), Headers);
		return rplSupplier.ListT1Supplier.Adapt<IEnumerable<uimT1SupplierInstansi>>();
	}
	public async Task<uimT1SupplierInstansi> GetDataSupplierInstansiById(Guid idSupplier)
	{
		if (idSupplier == Guid.Empty) return new();
		var rplSupplier = await _client.GetSupplierByIdAsync(new RqsSupplierById() { IdSupplier = idSupplier.ToString() }, Headers);
		if (!string.IsNullOrEmpty(rplSupplier.IdSupplier)) return rplSupplier.Adapt<uimT1SupplierInstansi>();
		return new();
	}
	public async Task<IList<dynamic>> GetDataAlamatSupplierById(Guid idSupplier)
	{
		var rplAlamatSuppliersByIdSupplier = await _client.GetAlamatSupplierByIdAsync(new RqsSupplierById() { IdSupplier = idSupplier.ToString() }, Headers);
		return rplAlamatSuppliersByIdSupplier.ListT2AlamatSupplier.Adapt<List<dynamic>>() ?? new List<dynamic>();
    }
    public async Task<IList<dynamic>> GetDataPenyeliaSupplierById(Guid idSupplier)
    {
        var rplPenyeliaSuppliersByIdSupplier = await _client.GetPenyeliaSupplierByIdAsync(new RqsSupplierById() { IdSupplier = idSupplier.ToString() }, Headers);
        return rplPenyeliaSuppliersByIdSupplier.ListT2PenyeliaSupplier.Adapt<List<dynamic>>() ?? new List<dynamic>();
    }

    public async Task<IList<dynamic>> GetDataVendorSupplierById(Guid idSupplier)
    {
        var rplVendorSuppliersByIdSupplier = await _client.GetVendorSupplierByIdAsync(new RqsSupplierById() { IdSupplier = idSupplier.ToString() }, Headers);
        return rplVendorSuppliersByIdSupplier.ListT5VendorSupplier.Adapt<List<dynamic>>() ?? new List<dynamic>();
    }
    public async Task<string> InsertSupplierInstansi(uimT1SupplierInstansi drSupplier)
	{
		var rqsSupplier = drSupplier.Adapt<RqsInsertSupplier>();
        rqsSupplier.IdCreator = Pantheon.Client.Utility.modVariabel.IdUser.ToString();
        var rplSupplier = await _client.InsertSupplierAsync(rqsSupplier, Headers);
		return rplSupplier.Result;
	}
	public async Task<string> UpdateSupplierInstansi(uimT1SupplierInstansi drSupplier)
	{
		var rqsSupplier = drSupplier.Adapt<RqsUpdateSupplier>();
        rqsSupplier.IdOperator = Pantheon.Client.Utility.modVariabel.IdUser.ToString();
        var rplSupplier = await _client.UpdateSupplierAsync(rqsSupplier, Headers);
		return rplSupplier.Result;
    }
    public async Task<string> DeleteSupplierInstansi(Guid idSupplier)
    {
        var rqsSupplier = new RqsDeleteSupplier { IdSupplier = idSupplier.ToString(), IdOperator = Pantheon.Client.Utility.modVariabel.IdUser.ToString() };
        var rplSupplier = await _client.DeleteSupplierAsync(rqsSupplier, Headers);
        return rplSupplier.Result;
    }

	public async Task<uimT1SupplierInstansi> GetDraftSupplierInstansi(string idSupplier)
	{
		var request = new RqsGetDraftSupplier { IdUser = Pantheon.Client.Utility.modVariabel.IdUser.ToString(), IdSupplier = idSupplier };
		var reply = await _client.GetDraftSupplierAsync(request, Headers);
		return reply.Adapt<uimT1SupplierInstansi>();
	}

	public async Task<string> SetDraftSupplierInstansi(uimT1SupplierInstansi drSupplier)
	{
		var request = drSupplier.Adapt<RqsSetDraftSupplier>();
		var reply = await _client.SetDraftSupplierAsync(request, Headers);
		return reply.Result;
	}
}
