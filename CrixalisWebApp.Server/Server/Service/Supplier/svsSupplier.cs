global using Pantheon.Shared.Utility;
using bwaCrixalis.Shared._1._Master;
using Pantheon.Shared.BaseEntityModels;

namespace bwaCrixalis.Server._1._Master;

public class svsSupplier : svpMasterSupplier.svpMasterSupplierBase
{
	private readonly ILogger<svsKaryawan> _logger;
	private readonly pthISvdMaster _svd;
	private readonly pthIServiceDraft _sdr;

	public svsSupplier(ILogger<svsKaryawan> logger, pthISvdMaster svd, pthIServiceDraft sdr)
	{
		_logger = logger;
		_svd = svd;
		_sdr = sdr;
	}

	public override async Task<RplSupplier> GetSupplier(RqsSupplier request, ServerCallContext context)
	{
		var listSupplier = await _svd.GetEntities<T1Supplier>();
		var reply = new RplSupplier();
		reply.ListT1Supplier.AddRange(listSupplier.Adapt<IEnumerable<RplSupplierById>>());
		return reply;
	}

	public override async Task<RplSupplierById> GetSupplierById(RqsSupplierById request, ServerCallContext context)
	{
		var Supplier = await _svd.GetEntityById<T1Supplier>(request.IdSupplier);
		if (Supplier is null) Supplier = new();
		return Supplier.Adapt<RplSupplierById>();
	}

    public override async Task<RplAlamatSupplierById> GetAlamatSupplierById(RqsSupplierById request, ServerCallContext context)
    {
        var listAlamatSupplier = await _svd.GetEntitiesDenganSpec<T2AlamatSupplier>(x => x.IdSupplier == request.IdSupplier.ToGuid());
        var reply = new RplAlamatSupplierById();
        reply.ListT2AlamatSupplier.AddRange(listAlamatSupplier.Adapt<IEnumerable<PtmAlamatSupplier>>());
        return reply;
    }

    public override async Task<RplPenyeliaSupplierById> GetPenyeliaSupplierById(RqsSupplierById request, ServerCallContext context)
    {
        var listPenyeliaSupplier = await _svd.GetEntitiesDenganSpec<T2PenyeliaSupplier>(x => x.IdSupplier == request.IdSupplier.ToGuid());
        var reply = new RplPenyeliaSupplierById();
        reply.ListT2PenyeliaSupplier.AddRange(listPenyeliaSupplier.Adapt<IEnumerable<PtmPenyeliaSupplier>>());
        return reply;
    }

    public override async Task<RplVendorSupplierById> GetVendorSupplierById(RqsSupplierById request, ServerCallContext context)
    {
        var listVendorSupplier = await _svd.GetEntitiesDenganSpec<T5VendorSupplier>(x => x.IdSupplier == request.IdSupplier.ToGuid());
        var reply = new RplVendorSupplierById();
        reply.ListT5VendorSupplier.AddRange(listVendorSupplier.Adapt<IEnumerable<PtmVendorSupplier>>());
        return reply;
    }

    public override async Task<RplWriteSupplier> InsertSupplier(RqsInsertSupplier request, ServerCallContext context)
    {
        var hasil = await _svd.InsertMasterHeader<T1Supplier, T2AlamatSupplier, T2PenyeliaSupplier, string, string, string>(request.Adapt<T1Supplier>(), "IdSupplier");
        return new RplWriteSupplier { IsOK = true, Result = hasil };
	}

	public override async Task<RplWriteSupplier> UpdateSupplier(RqsUpdateSupplier request, ServerCallContext context)
    { 
        var hasil = await _svd.UpdateMasterHeader<T1Supplier, T2AlamatSupplier, T2PenyeliaSupplier, BaseModelMasterDetil, BaseModelMasterDetil, BaseModelMasterDetil>(request.Adapt<T1Supplier>(), "IdSupplier");
		return new RplWriteSupplier { IsOK = true, Result = hasil };
	}

	public override async Task<RplWriteSupplier> DeleteSupplier(RqsDeleteSupplier request, ServerCallContext context)
	{
		var hasil = await _svd.DeleteMasterHeader<T1Supplier>(request.Adapt<T1Supplier>(), "IdSupplier");
		return new RplWriteSupplier { IsOK = true, Result = hasil };
	}


    public override async Task<RplGetDraftSupplier> GetDraftSupplier(RqsGetDraftSupplier request, ServerCallContext context)
    {
        var dtSupplier = await _sdr.GetDraftRedisByIdPrimaryKey<T1Supplier>(request.IdUser, request.IdSupplier);

        // Tambah 2 baris ini jika ada Detil Grid lebih dari 1
        var dtAlamatSupplier = await _sdr.GetDraftRedisDetilByIdPrimaryKey<T1Supplier, T2AlamatSupplier>(request.IdUser, request.IdSupplier);
        _svd.SetPropertyValue(dtSupplier, $"List{nameof(T2AlamatSupplier)}", dtAlamatSupplier);

        var dtPenyeliaSupplier = await _sdr.GetDraftRedisDetilByIdPrimaryKey<T1Supplier, T2PenyeliaSupplier>(request.IdUser, request.IdSupplier);
        _svd.SetPropertyValue(dtSupplier, $"List{nameof(T2PenyeliaSupplier)}", dtPenyeliaSupplier);

        /*var dtVendorSupplier = await _sdr.GetDraftRedisDetilByIdPrimaryKey<T1Supplier, T5VendorSupplier>(request.IdUser, request.IdSupplier);
        _svd.SetPropertyValue(dtSupplier, $"List{nameof(T5VendorSupplier)}", dtVendorSupplier);*/

        return dtSupplier.Adapt<RplGetDraftSupplier>();
    }

    public override async Task<RplSetDraftSupplier> SetDraftSupplier(RqsSetDraftSupplier request, ServerCallContext context)
    {
        var redisKey = await _sdr.SetDraftRedis<T1Supplier>(request.Adapt<T1Supplier>());
        return new RplSetDraftSupplier { IsOK = true, Result = redisKey };
    }

}
