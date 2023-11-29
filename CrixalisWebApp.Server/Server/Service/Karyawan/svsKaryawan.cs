using bwaCrixalis.Shared._1._Master;
using DevExpress.DataProcessing;
using Mapster;
using System.Reflection;

namespace bwaCrixalis.Server._1._Master;
public class svsKaryawan : svpMasterKaryawan.svpMasterKaryawanBase
{
	private readonly ILogger<svsKaryawan> _logger;
	private readonly ISvdKaryawan _svd;
	public svsKaryawan(ILogger<svsKaryawan> logger, ISvdKaryawan svd)
	{
		_logger = logger;
		_svd = svd;
	}

	#region 'Views'
	public override async Task<RplKaryawanById> GetKaryawanById(RqsKaryawanById request, ServerCallContext context)
	{
		var karyawan = await _svd.GetEntityById<pthT1Karyawan>(request.IdKaryawan);
		return karyawan.Adapt<RplKaryawanById>();
	}
	public override async Task<RplKaryawan> GetKaryawan(RqsKaryawan request, ServerCallContext context)
	{
		var data = await _svd.GetKaryawan();
		var reply = new RplKaryawan();
		reply.ListT1Karyawan.AddRange(data.Adapt<IEnumerable<RplKaryawanById>>());
		return reply;
		
		//pthIRepoGeneric<pthT1Karyawan> repo = _svd.Uow.GetRepository<pthRepoGeneric<pthT1Karyawan>>();
		//pthIRepoGeneric<pthT5JabatanKaryawan> repopthT5JabatanKaryawan = _svd.Uow.GetRepository<pthRepoGeneric<pthT5JabatanKaryawan>>();
		//var dtKaryawan = await _svd.RedisCache.GetDataRedis<IEnumerable<pthT1Karyawan>>($"{NamaDatabase}~{typeof(pthT1Karyawan).Name}");
		//if (dtKaryawan is null)
		//{
		//	dtKaryawan = await repo.CariDenganPredicate(x => x.IdKaryawan != Auto);
		//	foreach (var item in dtKaryawan)
		//	{
		//		var listpthT5JabatanKaryawan = await repopthT5JabatanKaryawan.CariDenganPredicate(x => x.IdKaryawan == item.IdKaryawan);
		//		if (listpthT5JabatanKaryawan is not null) item.ListT5JabatanKaryawan = listpthT5JabatanKaryawan.ToList();
		//	}
		//	await _svd.RedisCache.SetDataRedis($"{NamaDatabase}~{typeof(pthT1Karyawan).Name}", dtKaryawan);
		//}
		//dtKaryawan = _svd.GetListDataById(dtKaryawan.ToList(), "Synchronise", "deleted", "!=");
		//var rplKaryawan = new RplKaryawan();
		//rplKaryawan.ListT1Karyawan.AddRange(dtKaryawan.Adapt<IList<RplKaryawanById>>());
		//foreach (var item in rplKaryawan.ListT1Karyawan)
		//{
		//	var listpthT5JabatanKaryawan = new List<PtmJabatanKaryawan>();
		//	listpthT5JabatanKaryawan = dtKaryawan.FirstOrDefault(x => x.IdKaryawan == Guid.Parse(item.IdKaryawan))?.ListT5JabatanKaryawan?.Adapt<List<PtmJabatanKaryawan>>();
		//	if (listpthT5JabatanKaryawan is not null) item.ListT5JabatanKaryawan.AddRange(listpthT5JabatanKaryawan);
		//}
		//return rplKaryawan;
	}

	public override async Task<RplKaryawan> Get_Karyawan(RqsKaryawan request, ServerCallContext context)
	{
		var data = await _svd.GetEntities<pthT1Karyawan>();
		var reply = new RplKaryawan();
		reply.ListT1Karyawan.AddRange(data.Adapt<IEnumerable<RplKaryawanById>>());
		return data.Adapt<RplKaryawan>();
	}
	public override async Task<RplJabatanKaryawanByIdKaryawan> GetJabatanKaryawanByIdKaryawan(RqsJabatanKaryawanByIdKaryawan request, ServerCallContext context)
	{
		var listJabatanKaryawan = await _svd.GetEntitiesDenganSpec<pthT5JabatanKaryawan>(
						x => x.IdJabatan != null,
						$"T1Karyawan.T0Jabatan");
		var reply = new RplJabatanKaryawanByIdKaryawan();
		reply.ListT5JabatanKaryawan.AddRange(listJabatanKaryawan.Adapt<IEnumerable<PtmJabatanKaryawan>>());
		return reply;
		//pthIRepoGeneric<pthT5JabatanKaryawan> repo = _svd.Uow.GetRepository<pthRepoGeneric<pthT5JabatanKaryawan>>();
		//var listJabatanKaryawan = await repo.CariDenganPredicate(x => x.IdKaryawan == Guid.Parse(request.IdKaryawan));
		//var rplJabatanKaryawan = new RplJabatanKaryawanByIdKaryawan();
		//rplJabatanKaryawan.ListT5JabatanKaryawan.AddRange(listJabatanKaryawan.Adapt<IEnumerable<PtmJabatanKaryawan>>());
		//return rplJabatanKaryawan;
	}
	#endregion

	#region 'Procedure'
	public override async Task<RplWriteKaryawan> InsertKaryawan(RqsInsertKaryawan request, ServerCallContext context)
	{
		var hasil = await _svd.InsertMasterHeader<pthT1Karyawan, string, string, string, string, string>(request.Adapt<pthT1Karyawan>(), "IdKaryawan");
		return new RplWriteKaryawan { IsOK = true, Result = hasil };
	}
	public override async Task<RplWriteKaryawan> UpdateKaryawan(RqsUpdateKaryawan request, ServerCallContext context)
	{
		var hasil = await _svd.UpdateMasterHeader<pthT1Karyawan, BaseModelMasterDetil, BaseModelMasterDetil, BaseModelMasterDetil, BaseModelMasterDetil, BaseModelMasterDetil>(request.Adapt<pthT1Karyawan>(), "IdKaryawan");
		return new RplWriteKaryawan { IsOK = true, Result = hasil };
	}
	public override async Task<RplWriteKaryawan> DeleteKaryawan(RqsDeleteKaryawan request, ServerCallContext context)
	{
		var hasil = await _svd.DeleteMasterHeader<pthT1Karyawan>(request.Adapt<pthT1Karyawan>(), "IdKaryawan");
		return new RplWriteKaryawan { IsOK = true, Result = hasil };
	}

	public override async Task<RplWriteJabatanKaryawan> WriteJabatanKaryawan(RqsWriteJabatanKaryawan request, ServerCallContext context)
	{
		var hasil = await _svd.WriteJabatanKaryawan(request.Adapt<pthT5JabatanKaryawan>());
		return new RplWriteJabatanKaryawan { IsOK = true, Result = hasil };
		//string hasil = $"Berhasil~{request.IdKaryawan}";
		////pthIRepoGeneric<pthT5JabatanKaryawan> repo = _svd.Uow.GetRepository<pthRepoGeneric<pthT5JabatanKaryawan>>();
		//var dtJabatanKaryawan = (await _svd.GetEntitiesDenganPredicate<pthT5JabatanKaryawan>(x => x.IdKaryawan == Guid.Parse(request.IdKaryawan))).ToList();

		//var drJabatanKaryawan = dtJabatanKaryawan.FirstOrDefault(x => x.IdJabatan == Guid.Parse(request.IdJabatan));

		//var rqsJabatanKaryawan = request.Adapt<pthT5JabatanKaryawan>();
		//dtJabatanKaryawan.Add(rqsJabatanKaryawan);
		//await UpdateRedisDetil<pthT1Karyawan, pthT5JabatanKaryawan>(dtJabatanKaryawan.ToList(), $"{NamaDatabase}~{typeof(pthT1Karyawan).Name}", request.IdKaryawan);

		//if (request.Synchronise == "Delete")
		//    _svd.Delete(drJabatanKaryawan);
		//else if (drJabatanKaryawan is null)
		//    repo.Insert(rqsJabatanKaryawan);
		//else
		//    repo.Update(rqsJabatanKaryawan);
		//try
		//{
		//    var transaction = _svd.Uow.BeginTransaction();

		//    pthIRepoGeneric<pthT0Form> repoT0From = _svd.Uow.GetRepository<pthRepoGeneric<pthT0Form>>();
		//    var t0Form = (await repoT0From.CariDenganPredicate(x => x.NamaTabel == typeof(pthT1Karyawan).Name && (x.Kategori == "2. Master" || x.Kategori == "3. Transaksi")))?.FirstOrDefault();

		//    await _svd.Uow.Selesai();
		//    transaction.Commit();
		//}
		//catch (Exception ex)
		//{
		//    await UpdateRedisDetil<pthT1Karyawan, pthT5JabatanKaryawan>(dtJabatanKaryawan.ToList(), $"{NamaDatabase}~{typeof(pthT1Karyawan).Name}", request.IdKaryawan);
		//    await _svd.StreamPublisher.PublishAsync($"{NamaDatabase}~{typeof(pthT1Karyawan).Name}", rqsJabatanKaryawan);
		//    try
		//    {
		//        _svd.Uow.RollbackTransaction();
		//    }
		//    catch (Exception)
		//    {
		//        hasil = $"Gagal~{request.IdKaryawan}";
		//    }
		//    hasil = $"Gagal~{request.IdKaryawan}";
		//}
		//return new RplWriteJabatanKaryawan { IsOK = true, Result = hasil };
	}
	//private async Task UpdateRedisDetil<THeader, TDetil>(List<TDetil> entityDetil, string keyRedis, object idPK)
	//	where THeader : class
	//	where TDetil : class
	//{
	//	var data = await _svd.RedisCache.GetDataRedis<List<THeader>>(keyRedis);
	//	if (data is not null)
	//	{
	//		var namaPK = typeof(THeader).GetRuntimeProperties().FirstOrDefault(x => !x.Name.Contains("List"))?.Name;
	//		var dataRedisLama = GetDataById(data, namaPK, idPK);
	//		_svd.SetPropertyValue(dataRedisLama, $"List{typeof(TDetil).Name}", entityDetil);
	//		await _svd.RedisCache.SetDataRedis(keyRedis, data);
	//	}
	//}
	//public override async Task<RplWriteJabatanKaryawan> InsertJabatanKaryawan(RqsInsertJabatanKaryawan request, ServerCallContext context)
	//{
	//    var hasil = await InsertMasterDetil<pthT5JabatanKaryawan>(request.Adapt<pthT5JabatanKaryawan>(), "IdJabatanKaryawan");
	//    return new RplWriteJabatanKaryawan { IsOK = true, Result = hasil };
	//}
	//async Task<string> InsertMasterDetil<TEntity>(TEntity entityToInsert, string namaId, bool updateRedisCache = true)
	//    where TEntity : class
	//{
	//    string idPK = "";
	//    pthIRepoGeneric<TEntity> repo = _svd.Uow.GetRepository<pthRepoGeneric<TEntity>>();
	//    var entityToInsertLama = entityToInsert;
	//    if (updateRedisCache)
	//    {
	//        await _svd.SetPropertyValue(entityToInsert, namaId, NewId.NextGuid());
	//        await InsertRedis(repo, entityToInsert, namaId);
	//    }
	//    repo.Insert(entityToInsert);

	//    try
	//    {
	//        var transaction = _svd.Uow.BeginTransaction();

	//        pthIRepoGeneric<pthT0Form> repoT0From = _svd.Uow.GetRepository<pthRepoGeneric<pthT0Form>>();
	//        var t0Form = (await repoT0From.CariDenganPredicate(x => x.NamaTabel == typeof(TEntity).Name && (x.Kategori == "2. Master" || x.Kategori == "3. Transaksi")))?.FirstOrDefault();

	//        //var logHeader = _svd.InsertPropertyLogHeader(entityToInsert, t0Form);
	//        //var logDetil = _svd.InsertPropertyLogDetil(entityToInsert, t0Form);
	//        //logDetil.IdLogHeader = logHeader.IdLogHeader;
	//        //logDetil.Aktivitas = $"Menambahkan {typeof(TEntity).Name.Substring(2)}: {_svd.GetPropertyValue(entityToInsert, typeof(TEntity).Name.Substring(2))}, pada Master {t0Form?.Inisial}";

	//        //if (await _svd.Uow.Selesai(logHeader, logDetil))
	//        //{
	//        //Uow_Log.UseTransaction(transaction.GetDbTransaction());
	//        await _svd.Uow_Log.Selesai();
	//        transaction.Commit();
	//        //}
	//    }
	//    catch (Exception ex)
	//    {
	//        idPK = _svd.GetPropertyValue(entityToInsert, namaId); //ambil IdPK
	//        await _svd.UpdateRedis(entityToInsert);
	//        //await _streamPublisher.PublishAsync($"{NamaDatabase}~Insert~{typeof(TEntity).Name}", entityToInsert);
	//        await _streamPublisher.PublishAsync($"{NamaDatabase}~{typeof(TEntity).Name}", entityToInsert);
	//        try
	//        {
	//            _svd.Uow.RollbackTransaction();
	//        }
	//        catch (Exception)
	//        {
	//            return $"Gagal~{idPK}";
	//        }
	//        return $"Gagal~{idPK}";
	//    }
	//    idPK = _svd.GetPropertyValue(entityToInsert, namaId);
	//    entityToInsert.State = $"Berhasil~{idPK}";
	//    await UpdateRedis(entityToInsert);
	//    if (updateRedisCache) await _streamPublisher.PublishAsync($"{NamaDatabase}~{typeof(TEntity).Name}", entityToInsert);
	//    return $"Berhasil~{idPK}";
	//}
	//public override async Task<RplWriteJabatanKaryawan> UpdateJabatanKaryawan(RqsUpdateJabatanKaryawan request, ServerCallContext context)
	//{
	//    var hasil = await _svd.UpdateMasterDetil<pthT5JabatanKaryawan>(request.Adapt<pthT5JabatanKaryawan>(), "IdJabatanKaryawan");
	//    return new RplWriteJabatanKaryawan { IsOK = true, Result = hasil };
	//}
	//public override async Task<RplWriteJabatanKaryawan> DeleteJabatanKaryawan(RqsDeleteJabatanKaryawan request, ServerCallContext context)
	//{
	//    var hasil = await _svd.DeleteMasterDetil<pthT5JabatanKaryawan>(request.Adapt<pthT5JabatanKaryawan>(), "IdJabatanKaryawan");
	//    return new RplWriteJabatanKaryawan { IsOK = true, Result = hasil };
	//}
	//private async Task InsertRedis<TEntity>(pthIRepoGeneric<TEntity> repo, TEntity entityToInsert, string namaPK) where TEntity : class
	//{
	//    var dtRedis = await _svd.RedisCache.GetDataRedis<List<TEntity>>($"{NamaDatabase}~{typeof(TEntity).Name}");
	//    if (dtRedis is not null)
	//    {
	//        var idPK = _svd.GetPropertyValue(entityToInsert, namaPK);
	//        entityToInsert.State = $"Gagal~{idPK}"; // set default redis ke Gagal dulu
	//        dtRedis.Add(entityToInsert);
	//        await RedisCache.SetDataRedis($"{NamaDatabase}~{typeof(TEntity).Name}", dtRedis);
	//    }
	//    else
	//    {
	//        var dtDatabase = await repo.GetAll();
	//        await RedisCache.SetDataRedis($"{NamaDatabase}~{typeof(TEntity).Name}", dtDatabase);
	//    }
	//}
	#endregion
}
