using bwaCrixalis.Server.Data;
using bwaCrixalis.Shared._1._Master;
using Pantheon.Server.RedisCache;
using Pantheon.Shared.Redis;
using System.Reflection;

namespace bwaCrixalis.Server._1._Master;

public class svdKaryawan : pthSvdMaster<CrixalisDbContext, CrixalisDbContext_Log>, ISvdKaryawan
{
	public svdKaryawan(
		CrixalisDbContext dbContext,
		CrixalisDbContext_Log dbContext_Log,
		pthIRedisCacheService redisCache,
		IStreamPublisher streamPublisher,
		pthIServiceDraft sdr)
		: base(dbContext, dbContext_Log, redisCache, streamPublisher, sdr)
	{
	}

	public async Task<IEnumerable<pthT1Karyawan>> GetKaryawan()
	{
		//var dtKaryawan = await RedisCache.GetDataRedis<IEnumerable<pthT1Karyawan>>($"{NamaDatabase}~{typeof(pthT1Karyawan).Name}");
		//if (dtKaryawan is null)
		//{
		//	dtKaryawan = await GetEntitiesDenganPredicate<pthT1Karyawan>(x => x.IdKaryawan != Auto, nameof(pthT1Karyawan.ListT5JabatanKaryawan));
		//foreach (var item in dtKaryawan)
		//{
		//	var listpthT5JabatanKaryawan = await GetEntitiesDenganPredicate<pthT5JabatanKaryawan>(x => x.IdKaryawan == item.IdKaryawan);
		//	if (listpthT5JabatanKaryawan is not null) item.ListT5JabatanKaryawan = listpthT5JabatanKaryawan.ToList();
		//}
		//	await RedisCache.SetDataRedis($"{NamaDatabase}~{typeof(pthT1Karyawan).Name}", dtKaryawan);
		//}
		var dtKaryawan = await GetEntitiesDenganPredicate<pthT1Karyawan>(x => x.IdKaryawan != Auto, nameof(pthT1Karyawan.ListT5JabatanKaryawan));
		dtKaryawan = GetListDataById(dtKaryawan.ToList(), "Synchronise", "deleted", "!=");
		foreach (var item in dtKaryawan)
		{
			//var listpthT5JabatanKaryawan = new List<PtmJabatanKaryawan>();
			var listpthT5JabatanKaryawan = dtKaryawan.FirstOrDefault(x => x.IdKaryawan == item.IdKaryawan)?
											.ListT5JabatanKaryawan;
			if (listpthT5JabatanKaryawan is not null) 
				item.ListT5JabatanKaryawan?.ToList().AddRange(listpthT5JabatanKaryawan);
		}
		return dtKaryawan;
	}

	public async Task<string> WriteJabatanKaryawan(pthT5JabatanKaryawan t5JabatanKaryawan)
	{
		string hasil = $"Berhasil~{t5JabatanKaryawan.IdKaryawan}";
		var dtJabatanKaryawan = (await GetEntitiesDenganPredicate<pthT5JabatanKaryawan>(x => x.IdKaryawan == t5JabatanKaryawan.IdKaryawan)).ToList();

		var drJabatanKaryawan = dtJabatanKaryawan.FirstOrDefault(x => x.IdJabatan == t5JabatanKaryawan.IdJabatan);

		dtJabatanKaryawan.Add(t5JabatanKaryawan);
		await UpdateRedisDetil<pthT1Karyawan, pthT5JabatanKaryawan>(dtJabatanKaryawan, $"{NamaDatabase}~{typeof(pthT1Karyawan).Name}", t5JabatanKaryawan.IdKaryawan);

		if (t5JabatanKaryawan.Synchronise == "Delete")
			Delete(drJabatanKaryawan);
		else if (drJabatanKaryawan is null)
			Insert(t5JabatanKaryawan);
		else
			UpdateRow(drJabatanKaryawan, t5JabatanKaryawan);
		try
		{
			var transaction = await BeginTransactionAsync();

			var t0Form = (await GetEntityByPredicate<pthT0Form>(x => x.NamaTabel == typeof(pthT1Karyawan).Name && (x.Kategori == "2. Master" || x.Kategori == "3. Transaksi")));

			await _dbContext.SaveChangesAsync();
			transaction.Commit();
		}
		catch (Exception ex)
		{
			await UpdateRedisDetil<pthT1Karyawan, pthT5JabatanKaryawan>(dtJabatanKaryawan.ToList(), $"{NamaDatabase}~{typeof(pthT1Karyawan).Name}", t5JabatanKaryawan.IdKaryawan);
			await StreamPublisher.PublishAsync($"{NamaDatabase}~{typeof(pthT1Karyawan).Name}", t5JabatanKaryawan);
			try
			{
				await RollbackTransactionAsync();
			}
			catch (Exception)
			{
				hasil = $"Gagal~{t5JabatanKaryawan.IdKaryawan}";
			}
			hasil = $"Gagal~{t5JabatanKaryawan.IdKaryawan}";
		}
		return hasil;
	}


	private async Task UpdateRedisDetil<THeader, TDetil>(List<TDetil> entityDetil, string keyRedis, object idPK)
		where THeader : class
		where TDetil : class
	{
		var data = await RedisCache.GetDataRedis<List<THeader>>(keyRedis);
		if (data is not null)
		{
			var namaPK = typeof(THeader).GetRuntimeProperties().FirstOrDefault(x => !x.Name.Contains("List"))?.Name;
			var dataRedisLama = GetDataById(data, namaPK, idPK);
			SetPropertyValue(dataRedisLama, $"List{typeof(TDetil).Name}", entityDetil);
			await RedisCache.SetDataRedis(keyRedis, data);
		}
	}
}
