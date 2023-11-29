global using static Pantheon.Shared.Utility.modBaseExtensions;
using bwaCrixalis.Shared._1._Master;
using Grpc.Core;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Pantheon.Shared.BaseEntityModels;
using Radzen;

namespace bwaCrixalis.Server._1._Master;
//[Authorize]
public class svsJabatan : svpMasterJabatan.svpMasterJabatanBase
{
    private readonly ILogger<svsJabatan> _logger;
    private readonly pthISvdMaster _svd;
    private readonly pthIServiceDraft _sdr;
    public svsJabatan(ILogger<svsJabatan> logger, pthISvdMaster svd, pthIServiceDraft sdr)
    {
        _logger = logger;
        _svd = svd;
        _sdr = sdr;
    }

    #region 'Views'
    public override async Task<RplJabatanById> GetJabatanById(RqsJabatanById request, ServerCallContext context)
    {
        var jabatan = await _svd.GetEntityById<pthT0Jabatan>(request.IdJabatan);
        if (jabatan is null) jabatan = new();
        return jabatan.Adapt<RplJabatanById>();
    }
    public override async Task<RplJabatan> GetJabatan(RqsJabatan request, ServerCallContext context)
    {
        var listJabatan = await _svd.GetEntities<pthT0Jabatan>();
        var reply = new RplJabatan();
        reply.RpfJabatan.AddRange(listJabatan.Adapt<IEnumerable<RplJabatanById>>());
		return reply;
    }
    #endregion
    
    #region 'Procedure'
    public override async Task<RplWriteJabatan> InsertJabatan(RqsInsertJabatan request, ServerCallContext context)
    {
        var hasil = await _svd.InsertMasterHeader<pthT0Jabatan, string, string, string, string, string>(request.Adapt<pthT0Jabatan>(), "IdJabatan");
        return new RplWriteJabatan { IsOK = true, Result = hasil };
    }
	public override async Task<RplWriteJabatan> UpdateJabatan(RqsUpdateJabatan request, ServerCallContext context)
    {
        var hasil = await _svd.UpdateMasterHeader<pthT0Jabatan, BaseModelMasterDetil, BaseModelMasterDetil, BaseModelMasterDetil, BaseModelMasterDetil, BaseModelMasterDetil>(request.Adapt<pthT0Jabatan>(), "IdJabatan");
		return new RplWriteJabatan { IsOK = true, Result = hasil };
    }
	public override async Task<RplWriteJabatan> DeleteJabatan(RqsDeleteJabatan request, ServerCallContext context)
    {
        var hasil = await _svd.DeleteMasterHeader<pthT0Jabatan>(request.Adapt<pthT0Jabatan>(), "IdJabatan");
		return new RplWriteJabatan { IsOK = true, Result = hasil };
    }

    public override async Task<RplJabatanById> GetDraftJabatan(RqsDraftJabatan request, ServerCallContext context)
    {
        var hasil = await _sdr.GetDraftRedisByIdPrimaryKey<pthT0Jabatan>(request.IdCreator, request.IdJabatan);
        return hasil.Adapt<RplJabatanById>();
    }

    public override async Task<RplWriteJabatan> SetDraftJabatan(RqsUpdateJabatan request, ServerCallContext context)
    {
        //await _sdr.HapusDraftRedis(request.IdCreator);
        var hasil = await _sdr.GetDraftRedisByIdPrimaryKey<pthT0Jabatan>(request.IdCreator, request.IdJabatan);
        var redisKey = await _sdr.SetDraftRedis<pthT0Jabatan>(request.Adapt<pthT0Jabatan>());
        return new RplWriteJabatan { IsOK = true, Result = redisKey };
    }

    //public override async Task<RplWriteJabatan> SetDraftJabatan(RqsUpdateJabatan request, ServerCallContext context)
    //{
    //    var redisKey = await _sdr.SetDraftRedis<T0Jabatan>(request.IdCreator, request.Adapt<T0Jabatan>());
    //    return new RplWriteJabatan { IsOK = true, Result = redisKey };
    //}
    #endregion
}
