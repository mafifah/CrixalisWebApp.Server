using bwaCrixalis.Client._0._Utilitas;
using Microsoft.AspNetCore.Components;
using Pantheon.Client.Container;
using Radzen.Blazor;
using System.Collections.ObjectModel;
using static Pantheon.Client.Utility.modVariabel;

namespace bwaCrixalis.Client._1._Master;

public partial class RcpSupplierInstansi : ConMaster_1<uimT1SupplierInstansi, svcSupplierInstansi>
{
    DateTime value;
    public RadzenDropDown<string> CmbPrefix { get; set; }
    public RadzenTextBox TxbNama { get; set; }
    public RadzenDropDown<object> CmbJenisSupplier { get; set; }
    public RadzenTextBox TxbKode { get; set; }
    public RadzenTextBox TxbInisial { get; set; }
    public RadzenCheckBox<bool?> ChbStatus { get; set; }
    public RadzenDropDownDataGrid<long?> CmbKota { get; set; }
    public RadzenDropDown<uimT3Kecamatan> CmbKecamatan { get; set; }
    public RadzenDropDown<uimT4Kelurahan> CmbKelurahan { get; set; }
    public RadzenTextBox TxbAlamat { get; set; }
    public RadzenTextBox TxbKodePos { get; set; }
    public RadzenTextBox TxbKoordinat { get; set; }
    public RadzenTextBox TxbPortOfCharge { get; set; }
    public RadzenTextBox TxbFreightOnBoard { get; set; }
    public RadzenTextBox TxbWebsite1 { get; set; }
    public RadzenTextBox TxbWebsite2 { get; set; }
    public RadzenTextBox TxbEmail1 { get; set; }
    public RadzenTextBox TxbEmail2 { get; set; }
    public RadzenTextBox TxbPhone1 { get; set; }
    public RadzenTextBox TxbPhone2 { get; set; }
    public RadzenTextBox TxbPhone3 { get; set; }
    public RadzenTextBox TxbPhone4 { get; set; }
    public RadzenTextBox TxbPhone5 { get; set; }
    public RadzenTextBox TxbFaxPhone1 { get; set; }
    public RadzenTextBox TxbFaxPhone2 { get; set; }
    public RadzenTextBox TxbFaxPhone3 { get; set; }
    public RadzenTextBox TxbFaxPhone4 { get; set; }
    public RadzenTextBox TxbFaxPhone5 { get; set; }
    public RadzenTextArea MmoRekening { get; set; }
    public RadzenTextArea MmoKeterangan { get; set; }
    //public RadzenDropDown<uimT9DataOption> CmbJenisPPN { get; set; }
    //public RadzenDropDown<uimT9DataOption> CmbJenisPembelian { get; set; }
    //public RadzenDropDown<uimT9DataOption> CmbReturPembelian { get; set; }
    //public RadzenDropDown<uimT9DataOption> CmdJadwalPenagihan { get; set; }
    public RadzenNumeric<decimal?> SpeTermin { get; set; }
    public RadzenNumeric<decimal?> SpeBatasHutangGiro { get; set; }
    public RadzenNumeric<decimal?> SpeBatasHutangUsaha { get; set; }
    public RadzenDropDown<uimT0Company> CmbCompany { get; set; }
    public RadzenCheckBox<bool?> ChbStatusTerapkanSemuaCabang { get; set; }
   
    //public ObservableCollection<uimT9DataOption> DtCmbPrefix { get; set; }
    //public ObservableCollection<uimT0JenisSupplier> DtCmbJenisSupplier { get; set; }

    public IList<uimT2Kota> DtT2Kota { get; set; }
    public IList<uimT3Kecamatan> DtT3Kecamatan { get; set; }
    public IList<uimT4Kelurahan> DtT4Kelurahan { get; set; }
    public string DrCmbPrefix { get; set; }
    public object DrCmbJenisSupplier { get; set; }
    public IList<dynamic> DtGrdAlamatSupplier { get; set; }
    public IList<dynamic> DtGrdPenyeliaSupplier { get; set; }
    public IList<dynamic> DtGrdVendorSupplier { get; set; }
    //public IEnumerable<uimT9DataOption> DtJenisPPN { get; set; }
    //public IEnumerable<uimT9DataOption> DtJenisPembelian { get; set; }
    //public IEnumerable<uimT9DataOption> DtJenisReturPembelian { get; set; }
    //public IEnumerable<uimT9DataOption> DtJadwalPenagihan { get; set; }
    //public IEnumerable<uimT0Company> DtCompany { get; set; }
    //public IEnumerable<uimT1Vendor> DtVendor { get; set; }

    private readonly clsCrixalisHandler ch = new clsCrixalisHandler();
    //private readonly svcCompany _svcCompany = new svcCompany();
    //private readonly svcVendor _svcVendor = new svcVendor();

    protected override async void OnInitialized()
    {
        base.OnInitialized();
        PrimaryText = nameof(uimT1SupplierInstansi.Supplier);
        //DtCmbPrefix =  (await ch.Get_DataOption("Prefix Supplier")).Adapt<ObservableCollection<uimT9DataOption>>();
        //DtCmbJenisSupplier =  (await ch.Get_JenisSupplier()).Adapt<ObservableCollection<uimT0JenisSupplier>>();
        DtT2Kota = await ch.Get_Kota();
        //DtJenisPPN = (await ch.Get_DataOption("Jenis PPN"))?.Adapt<IEnumerable<uimT9DataOption>>();
        //DtJenisPembelian = (await ch.Get_DataOption("Jenis Pembelian"))?.Adapt<IEnumerable<uimT9DataOption>>();
        //DtJenisReturPembelian = (await ch.Get_DataOption("Jenis Retur Pembelian"))?.Adapt<IEnumerable<uimT9DataOption>>();
        //DtJadwalPenagihan = (await ch.Get_DataOption("Jenis Jadwal Penagihan"))?.Adapt<IEnumerable<uimT9DataOption>>();
        //DtCompany = (await _svcCompany.GetDataCompany()).ToList();
        //DtVendor = (await _svcVendor.GetDataVendor()).ToList();
    }

    //protected override async Task OnInitializedAsync()
    //{
    //    DtJenisPPN = (await ch.Get_DataOption("Jenis PPN"))?.Adapt<IEnumerable<uimT9DataOption>>().OrderBy(x => x.Parameter);
    //    DtJenisPembelian = (await ch.Get_DataOption("Jenis Pembelian"))?.Adapt<IEnumerable<uimT9DataOption>>().OrderBy(x => x.Parameter);
    //    DtJenisReturPembelian = (await ch.Get_DataOption("Jenis Retur Pembelian"))?.Adapt<IEnumerable<uimT9DataOption>>().OrderBy(x => x.Parameter);
    //    DtJadwalPenagihan = (await ch.Get_DataOption("Jenis Jadwal Penagihan"))?.Adapt<IEnumerable<uimT9DataOption>>().OrderBy(x => x.Parameter);
    //    DtCompany = (await _svcCompany.GetDataCompany()).ToList();
    //    DtVendor = (await _svcVendor.GetDataVendor()).ToList();
    //}
    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);
    }

    #region Rekapitulasi
    public override void ProsesPerbarui_Rekapitulasi(string namaMethod = null, object[] parameters = null)
    {
        base.ProsesPerbarui_Rekapitulasi();
    }

    public override async void ProsesSeleksiData(object data)
    {
        base.ProsesSeleksiData(data);
        //DtT2Kota = await ch.Get_Kota();
        DtT3Kecamatan = await ch.Get_KecamatanByIdKota(DtRekapitulasi_Terseleksi.IdKota);
        DtT4Kelurahan = await ch.Get_KelurahanByIdKecamatan(DtRekapitulasi_Terseleksi.IdKecamatan);
        var drT2Kota = DtT2Kota.FirstOrDefault(t => t.IdKota == (DtRekapitulasi_Terseleksi.IdKota ?? 0));
        if (drT2Kota is not null)
            DtRekapitulasi_Terseleksi.T2Kota = drT2Kota;

        DtGrdAlamatSupplier = (Svc.GetDataAlamatSupplierById(DtRekapitulasi_Terseleksi.IdSupplier)).Adapt<IList<dynamic>>();
        DtGrdPenyeliaSupplier = (Svc.GetDataPenyeliaSupplierById(DtRekapitulasi_Terseleksi.IdSupplier)).Adapt<IList<dynamic>>();
        DtGrdVendorSupplier = (Svc.GetDataVendorSupplierById(DtRekapitulasi_Terseleksi.IdSupplier)).Adapt<IList<dynamic>>();
        await CmbPrefix.FocusAsync();
    }

    public void ProsesSimpan_DraftCmb(dynamic data)
    {

    }
    #endregion

    #region Detil
    public override async Task ProsesMuat_Detil()
    {
        //ListTxb.AddRange(new BaseTxb[] {
        //    new BaseTxb() { Txb = TxbNama, Wajib = true, Unik = true },
        //    new BaseTxb() { Txb = TxbKode, Wajib = true, Unik = true }});

        //ListChb.AddRange(new BaseChb[] {
        //    new BaseChb() { Chb = ChbStatus },
        //});

        await base.ProsesMuat_Detil();

        DtT2Kota = await ch.Get_Kota();
    }
    public override async void ProsesPerbarui_Control(string namaControl, object dtCmb, bool perbaruiMeskipunAda = false)
    {
        if (namaControl == nameof(CmbPrefix))
        {
            dtCmb = await ch.Get_DataOption("Prefix Supplier");
        }
        else if (namaControl == nameof(CmbJenisSupplier))
        {
            //dtCmb = await ch.Get_JenisSupplier();
        }
        base.ProsesPerbarui_Control(namaControl, dtCmb, perbaruiMeskipunAda);
    }
    protected async void CmbJenisSupplier_DropDownVisibleChanged(bool val)
    {
        //if (val == true)
        //{
        //    DtCmbJenisSupplier = (await _svcJenisSupplier.GetDataJenisSupplier()).Adapt<ObservableCollection<uimT0JenisSupplier>>();
        //    await InvokeAsync(StateHasChanged);
        //}
        //else
        //{
        //    await ProsesSimpan_Draft("IdJenisSupplier", DrCmbJenisSupplier?.Adapt<uimT0JenisSupplier>().IdJenisSupplier);
        //}
    }

    public override void ProsesPerbarui_Detil(BaseGv x, CancellationToken ct)
    {
        base.ProsesPerbarui_Detil(x, ct);
    }

    protected async void Kota_ValueChanged(object val)
    {
        var kota = val as uimT2Kota;
        if (val is null) return;
        DtRekapitulasi_Terseleksi.IdKota = kota.IdKota;
        DtT3Kecamatan = await ch.Get_KecamatanByIdKota(DtRekapitulasi_Terseleksi.IdKota);
        var dr = DtT2Kota.FirstOrDefault(t => t.IdKota == (kota.IdKota));
        await InvokeAsync(StateHasChanged);
    }
    protected async void Kecamatan_ValueChanged(object val)
    {
        var kecamatan = val as uimT3Kecamatan;
        DtRekapitulasi_Terseleksi.IdKecamatan = kecamatan.IdKecamatan;
        DtT4Kelurahan = await ch.Get_KelurahanByIdKecamatan(DtRekapitulasi_Terseleksi.IdKecamatan);
        await InvokeAsync(StateHasChanged);
    }
    #endregion

    #region Navigasi
    public override async Task ProsesDataBaru()
    {
        await base.ProsesDataBaru();
    }
    public override void ProsesUpdateDatabase()
    {
        //SetDetil_SebelumUpdateDatabase<T2AlamatSupplier>();
        //SetDetil_SebelumUpdateDatabase<T2PenyeliaSupplier>();

        base.ProsesUpdateDatabase();
    }
    #endregion
}
