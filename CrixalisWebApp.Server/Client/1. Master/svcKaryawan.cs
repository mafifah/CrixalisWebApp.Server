global using Mapster;
using bwaCrixalis.Shared._1._Master;
using Pantheon.Client.Services;
using static bwaCrixalis.Shared._1._Master.svpMasterKaryawan;
using static Pantheon.Client.Utility.modVariabel;

namespace bwaCrixalis.Client._1._Master;
public class svcKaryawan : pthBaseService
{
    private svpMasterKaryawanClient _client { get; set; }
    public svcKaryawan()
    {
        _client = new svpMasterKaryawanClient(ClientChannel);
    }

    public async Task<IEnumerable<uimT1Karyawan>> GetDataKaryawan()
    {
        var rplKaryawan = await _client.GetKaryawanAsync(new RqsKaryawan(), Headers);
        return rplKaryawan.ListT1Karyawan.Adapt<IEnumerable<uimT1Karyawan>>();
    }

    public async Task<IEnumerable<uimT1Karyawan>> Get_Karyawan()
    {
        var rplKaryawan = await _client.Get_KaryawanAsync(new RqsKaryawan(), Headers);
		return rplKaryawan.ListT1Karyawan.Adapt<IEnumerable<uimT1Karyawan>>();
	}

    public async Task<uimT1Karyawan> GetDataKaryawanById(Guid idKaryawan)
    {
        uimT1Karyawan drKaryawan;
        var rplKaryawan = await _client.GetKaryawanByIdAsync(new RqsKaryawanById() { IdKaryawan = idKaryawan.ToString() }, Headers);
        if (string.IsNullOrEmpty(rplKaryawan.IdKaryawan)) drKaryawan = new();
        else drKaryawan = rplKaryawan.Adapt<uimT1Karyawan>();
        return drKaryawan;
    }
    public async Task<IList<uimT5JabatanKaryawan>> GetDataJabatanKaryawanById(Guid idKaryawan)
    {
        var rplJabatanKaryawan = await _client.GetJabatanKaryawanByIdKaryawanAsync(new RqsJabatanKaryawanByIdKaryawan() { IdKaryawan = idKaryawan.ToString() }, Headers);
        return rplJabatanKaryawan.ListT5JabatanKaryawan.Adapt<IList<uimT5JabatanKaryawan>>() ?? new List<uimT5JabatanKaryawan>();
    }

    public async Task<IList<uimT5JabatanKaryawan>> GetDataJabatanKaryawan()
    {
        var rplJabatanKaryawan = await _client.GetJabatanKaryawanByIdKaryawanAsync(new RqsJabatanKaryawanByIdKaryawan(), Headers);
        return rplJabatanKaryawan.ListT5JabatanKaryawan.Adapt<IList<uimT5JabatanKaryawan>>() ?? new List<uimT5JabatanKaryawan>();
    }

    public async Task<string> InsertKaryawan(uimT1Karyawan karyawan)
    {
        var rqsKaryawan = karyawan.Adapt<RqsInsertKaryawan>();
        var rplKaryawan = await _client.InsertKaryawanAsync(rqsKaryawan, Headers);
        return rplKaryawan.Result;
    }
    public async Task<string> UpdateKaryawan(uimT1Karyawan karyawan)
    {
        var request = karyawan.Adapt<RqsUpdateKaryawan>();
        var rplKaryawan = await _client.UpdateKaryawanAsync(request, Headers);
        return rplKaryawan.Result;
    }
    public async Task<string> DeleteKaryawan(Guid idKaryawan)
    {
        var rqsKaryawan = new RqsDeleteKaryawan { IdKaryawan = idKaryawan.ToString() };
        var rplKaryawan = await _client.DeleteKaryawanAsync(rqsKaryawan, Headers);
        return rplKaryawan.Result;
    }

    public async Task<string> WriteJabatanKaryawan(uimT5JabatanKaryawan jabatanKaryawan)
    {
        var rqsJabatanKaryawan = jabatanKaryawan.Adapt<RqsWriteJabatanKaryawan>();
        var rplJabatanKaryawan = await _client.WriteJabatanKaryawanAsync(rqsJabatanKaryawan, Headers);
        return rplJabatanKaryawan.Result;
    }
}