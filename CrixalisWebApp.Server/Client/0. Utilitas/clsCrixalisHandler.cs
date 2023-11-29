using Pantheon.Client.Utility;
using bwaCrixalis.Client._1._Master;
using static Pantheon.Client.Utility.modVariabel;
using Mapster;
using bwaCrixalis.Shared._1._Master;
using Microsoft.Ajax.Utilities;
using static bwaCrixalis.Shared._1._Master.svpMasterJabatan;
using Pantheon.Client.Services;
using Pantheon.Shared.BaseEntityModels;
using System.Reflection;

namespace bwaCrixalis.Client._0._Utilitas;
public class clsCrixalisHandler : clsPantheonHandler<uimT0DivisiPerusahaan, uimT1Provinsi, uimT2Kota, uimT3Kecamatan, uimT4Kelurahan, uimT0DivisiPerusahaan>
{
    private svpMasterJabatanClient _clientMasterJabatan { get; set; }
	private readonly svcKaryawan _svcKaryawan = new svcKaryawan();
	private readonly pthSvcForm _svcForm = new pthSvcForm();
	//private readonly svcJabatan _svcJabatan = new svcJabatan();
 //   private readonly svcJenisSupplier _svcJenisSupplier = new svcJenisSupplier();
 //   private readonly svcJenisVendor _svcJenisVendor = new svcJenisVendor();
 //   private readonly svcJenisCustomer _svcJenisCustomer = new svcJenisCustomer();
 //   private readonly svcSupplierInstansi _svcSupplierInstansi = new svcSupplierInstansi();
 //   private readonly svcCompany _svcCompany = new svcCompany();
 //   private readonly svcDivisiBarang _svcDivisiBarang = new svcDivisiBarang();
 //   private readonly svcKategoriBarang _svcKategoriBarang = new svcKategoriBarang();
 //   private readonly svcBarang _svcBarang = new svcBarang();
	//private readonly svcAkun _svcAkun = new svcAkun();
	private readonly pthSvcRekening _svcRekening = new pthSvcRekening();

	public clsCrixalisHandler()
    {
        _clientMasterJabatan = new svpMasterJabatanClient(ClientChannel);
    }
    public async Task<IList<dynamic>> Get_Jabatan(bool perbaruiMeskipunAda = false)
    {
        var data = await _clientMasterJabatan.GetJabatanAsync(new RqsJabatan(), Headers);
        return data.RpfJabatan.Adapt<List<dynamic>>();
    }
    public async Task<IList<dynamic>> Get_Form(bool perbaruiMeskipunAda = false)
    {
        var data = await _svcForm.GetDataForm();
        return data.Adapt<List<dynamic>>();
    }
 //   public async Task<IList<dynamic>> Get_JenisSupplier(bool perbaruiMeskipunAda = false)
 //   {
 //       var data = await _svcJenisSupplier.GetDataJenisSupplier();
 //       return data.Adapt<List<dynamic>>();
 //   }
 //   public async Task<IList<dynamic>> Get_JenisCustomer(bool perbaruiMeskipunAda = false)
 //   {
 //       var data = await _svcJenisCustomer.GetDataJenisCustomer();
 //       return data.Adapt<List<dynamic>>();
 //   }

 //   public async Task<IList<dynamic>> Get_JenisVendor(bool perbaruiMeskipunAda = false)
 //   {
 //       var data = await _svcJenisVendor.GetDataJenisVendor();
 //       return data.Adapt<List<dynamic>>();
 //   }

 //   public async Task<IList<dynamic>> Get_Supplier(bool perbaruiMeskipunAda = false)
 //   {
 //       var data = await _svcSupplierInstansi.GetDataSupplierInstansi();
 //       return data.Adapt<List<dynamic>>();
 //   }

 //   public async Task<IList<dynamic>> Get_Company(bool perbaruiMeskipunAda = false)
 //   {
 //       var data = await _svcCompany.GetDataCompany();
 //       return data.Adapt<List<dynamic>>();
 //   }

 //   public async Task<IList<uimT1Karyawan>> Get_Karyawan(string jabatan, bool denganTanpa = false, bool denganSemua = false, bool perbaruiMeskipunAda = false)
 //   {
 //       //var listjabatan = await _svcJabatan.GetDataJabatan();
 //       var listkaryawan= await _svcKaryawan.GetDataKaryawan();

 //  //     var list = listkaryawan
 //  //         .Join(listjabatan,
	//		//t1karyawan => t1karyawan.IdJabatan,
	//		//t0jabatan => t0jabatan.IdJabatan,
 //  //         (t0jabatan, t1karyawan) => new { T0Jabatan = t1karyawan, T1Karyawan = t0jabatan })
 //  //         .Select(t => new
 //  //         {
 //  //             t.T1Karyawan.IdJabatan,
 //  //             t.T0Jabatan.Jabatan,
 //  //             t.T1Karyawan.NamaPanggilan,
 //  //         }).Where(x => x.Jabatan == jabatan);
 //      return listkaryawan.ToList();
	//}
 //   public async Task<IList<T1SubDivisiBarang>> Get_SubDivisiBarangById(Guid idDivisiBarang)
 //   {
 //       var listSubDivisiBarang = await _svcDivisiBarang.GetDataSubDivisiBarangById(idDivisiBarang);
 //       return listSubDivisiBarang.Adapt<IEnumerable<T1SubDivisiBarang>>().ToList();
 //   }
 //   public async Task<IList<T0DivisiBarang>> Get_DivisiBarang(bool perbaruiMeskipunAda = false)
 //   {
 //       var listDivisiBarang = await _svcDivisiBarang.GetDataDivisiBarang();
 //       return listDivisiBarang.Adapt<IEnumerable<T0DivisiBarang>>().ToList();
 //   }
 //   public async Task<IList<T0KategoriBarang>> Get_KategoriBarang(bool perbaruiMeskipunAda = false)
 //   {
 //       var listKategoriBarang = await _svcKategoriBarang.GetDataKategoriBarang();
 //       return listKategoriBarang.Adapt<IEnumerable<T0KategoriBarang>>().ToList();
 //   }

 //   public async Task<IList<T1Warna>> Get_Warna(bool perbaruiMeskipunAda = false)
 //   {
 //       var listWarna = await _svcBarang.GetDataWarna();
 //       return listWarna.Adapt<IEnumerable<T1Warna>>().ToList();
 //   }

	//public async Task<IList<dynamic>> Get_Akun(bool perbaruiMeskipunAda = false)
	//{
	//	var data = await _svcAkun.GetDataAkun();
	//	return data.Adapt<List<dynamic>>();
	//}

	//public async Task<IEnumerable<dynamic>> Get_FieldTable(long idForm = 0)
	//{
	//	var namaTabel = DtForm.FirstOrDefault(x => x.IdForm == idForm)?.NamaTabel ?? "";
	//	var dtUim = AssemblyProject.ExportedTypes.Where(c => c.Name[..3] == "uim").ToList();
	//	var DtCmbWhereClauseField = dtUim.FirstOrDefault(x => x.Name.Contains(namaTabel))?.GetRuntimeProperties()?.Select(x => new { NamaKolom = x.Name });
 //       return DtCmbWhereClauseField;
	//}

	//public async Task<IList<pthT0Rekening>> Get_Rekening(bool perbaruiMeskipunAda = false)
	//{
	//	var listRekening = await _svcRekening.GetDataRekening();
	//	return listRekening.Adapt<IEnumerable<pthT0Rekening>>().ToList();
	//}

}
