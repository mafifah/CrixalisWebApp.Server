using bwaCrixalis.Client._0._Utilitas;
using bwaCrixalis.Shared._1._Master;
using DevExpress.Blazor;
using DevExpress.XtraCharts.Native;
using Mapster;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.JSInterop;
using Pantheon.Shared.BaseEntityModels;
using Pantheon.Client.Container;
using Pantheon.Client.CustomControls;
using Pantheon.Client.Utility;
using System.Dynamic;
using System.Linq.Dynamic.Core;
using static Pantheon.Client.Utility.modVariabel;
using FocusEventArgs = Microsoft.AspNetCore.Components.Web.FocusEventArgs;

namespace bwaCrixalis.Client._1._Master;
public partial class RcpKaryawan : ConMaster_1<uimT1Karyawan, svcKaryawan>
{
    #region Inject
    [Inject]
    IJSRuntime _js { get; set; }
    #endregion

    public DxFormLayoutItem FliNamaLengkap { get; set; }
    public DxFormLayoutItem FliNamaPanggilan { get; set; }
    public DxFormLayoutItem FliJenisKelamin { get; set; }
    public DxFormLayoutItem FliTempatLahir { get; set; }
    public DxFormLayoutItem FliTanggalLahir { get; set; }
    public DxFormLayoutItem FliTanggalRekrut { get; set; }
    public DxFormLayoutItem FliUsia { get; set; }
    public DxFormLayoutItem FliNoIdentitas1 { get; set; }
    public DxFormLayoutItem FliNoIdentitas2 { get; set; }
    public DxFormLayoutItem FliLamaKerja { get; set; }
    public DxFormLayoutItem FliAlamatDaerahAsal { get; set; }
    public DxFormLayoutItem FliKotaAsal { get; set; }
    public DxFormLayoutItem FliKecamatanAsal { get; set; }
    public DxFormLayoutItem FliKelurahanAsal { get; set; }
    public DxFormLayoutItem FliKodePosDaerahAsal { get; set; }
    public DxFormLayoutItem FliProvinsiAsal { get; set; }
    public DxFormLayoutItem FliAlamatDaerahTinggal { get; set; }
    public DxFormLayoutItem FliKotaTinggal { get; set; }
    public DxFormLayoutItem FliKecamatanTinggal { get; set; }
    public DxFormLayoutItem FliKelurahanTinggal { get; set; }
    public DxFormLayoutItem FliKodePosDaerahTinggal { get; set; }
    public DxFormLayoutItem FliProvinsiTinggal { get; set; }
    public DxFormLayoutItem FliTelepon { get; set; }
    public DxFormLayoutItem FliSeluler1 { get; set; }
    public DxFormLayoutItem FliSeluler2 { get; set; }
    public DxFormLayoutItem FliEmail { get; set; }
    public DxFormLayoutItem FliLainnya { get; set; }
    public DxFormLayoutItem FliNamaKerabat { get; set; }
    public DxFormLayoutItem FliHubunganKerabat { get; set; }
    public DxFormLayoutItem FliAlamatKerabat { get; set; }
    public DxFormLayoutItem FliTeleponKerabat { get; set; }
    public DxFormLayoutItem FliRekening { get; set; }
    public DxFormLayoutItem FliBPJS { get; set; }
    public DxFormLayoutItem FliNPWP { get; set; }
    public DxFormLayoutItem FliDokJaminan { get; set; }
    public DxFormLayoutItem FliKeterangan { get; set; }
    public DxFormLayoutItem FliNIK { get; set; }
    public DxFormLayoutItem FliDivisi { get; set; }
    public DxFormLayoutItem FliJabatan { get; set; }
    public DxFormLayoutItem FliJadwalKerja { get; set; }
    public DxFormLayoutItem FliStatusLogin { get; set; }
    public DxFormLayoutItem FliUserName { get; set; }
    public DxFormLayoutItem FliUserPassword { get; set; }
    public DxFormLayoutItem FliStatus { get; set; }
    public DxFormLayoutItem FliTanggalBerhenti { get; set; }
    public DxFormLayoutItem FlJabatan { get; set; }
    public DxFormLayoutItem FliPrefix { get; set; }
    public DxFormLayoutItem FliCode { get; set; }
    public DxFormLayoutItem FliSuffix { get; set; }
    public DxFormLayoutItem FliSeparator { get; set; }

    public DxTextBox TxbNamaLengkap { get; set; }
	public DxTextBox TxbNamaPanggilan { get; set; }
	public DxTextBox TxbTempatLahir { get; set; }
	public DxDateEdit<DateTime?> DteTanggalLahir { get; set; }
	public DxDateEdit<DateTime?> DteTanggalRekrut { get; set; }
	public DxTextBox TxbUsia { get; set; }
	public DxTextBox TxbNoIdentitas1 { get; set; }
	public DxTextBox TxbNoIdentitas2 { get; set; }
	public DxTextBox TxbLamaKerja { get; set; }

	public DxTextBox TxbAlamatDaerahAsal { get; set; }
	public DxComboBox<uimT2Kota, uimT2Kota> CmbKotaAsal { get; set; }
    public DxComboBox<uimT3Kecamatan, uimT3Kecamatan> CmbKecamatanAsal { get; set; }
	public DxComboBox<uimT4Kelurahan, uimT4Kelurahan> CmbKelurahanAsal { get; set; }
	public DxTextBox TxbKodePosDaerahAsal { get; set; }
	public DxTextBox TxbProvinsiAsal { get; set; }

	public DxTextBox TxbAlamatDaerahTinggal { get; set; }
	public DxComboBox<IList<uimT2Kota>, uimT2Kota> CmbKotaTinggal { get; set; }
	public DxComboBox<IList<uimT3Kecamatan>, uimT3Kecamatan> CmbKecamatanTinggal { get; set; }
	public DxComboBox<IList<uimT4Kelurahan>, uimT4Kelurahan> CmbKelurahanTinggal { get; set; }
	public DxTextBox TxbKodePosDaerahTinggal { get; set; }
	public DxTextBox TxbProvinsiTinggal { get; set; }

	public DxMaskedInput<string> MsiTelepon { get; set; }
	public DxMaskedInput<string> MsiSeluler1 { get; set; }
	public DxMaskedInput<string> MsiSeluler2 { get; set; }
	public DxTextBox TxbEmail { get; set; }
	public DxMemo MmoLainnya { get; set; }

	public DxTextBox TxbNamaKerabat { get; set; }
	public DxTextBox TxbHubunganKerabat { get; set; }
	public DxMemo MmoAlamatKerabat { get; set; }
	public DxMaskedInput<string> MsiTeleponKerabat { get; set; }

	public DxMemo MmoRekening { get; set; }
	public DxTextBox TxbBPJS { get; set; }
	public DxTextBox TxbNPWP { get; set; }
	public DxTextBox TxbDokJaminan { get; set; }
	public DxMemo MmoKeterangan { get; set; }

	public DxTextBox TxbNIK { get; set; }
	//public DxComboBox<IList<uimT0DivisiBarang>, uimT0DivisiBarang> CmbDivisi { get; set; }
	public DxComboBox<dynamic, object> CmbJabatan { get; set; }
    //public DxComboBox<IList<uimT1JadwalKerjaKaryawan>, uimT1JadwalKerjaKaryawan> CmbJadwalKerja { get; set; }
    string JenisKelaminTerpilih { get; set; }
    IEnumerable<string> DtJenisKelamin = new[] { "Pria", "Wanita"};
    public DxCheckBox<bool?> ChbStatusLogin { get; set; }
	public DxTextBox TxbUserName { get; set; }
	public DxTextBox TxbUserPassword { get; set; }
	public DxCheckBox<bool?> ChbStatus { get; set; }
	public DxDateEdit<DateTime?> DteTanggalBerhenti { get; set; }

	public IGrid GrdJabatanKaryawan { get; set; }
    //public DxComboBox<dynamic, object> CmbJabatan_GrdJabatanKaryawan { get; set; }
    public DxTextBox TxbPrefix { get; set; }
	public DxTextBox TxbCode { get; set; }
	public DxTextBox TxbSuffix { get; set; }
	public DxTextBox TxbSeparator { get; set; }

    public int ActiveTabIndex { get; set; } = 0;
	string _teleponText = "";

	List<T5Gambar> _gambar = new();

    private readonly clsCrixalisHandler ch = new clsCrixalisHandler();
    public IList<uimT2Kota> DtT2Kota { get; set; }
    public IList<uimT3Kecamatan> DtT3KecamatanAsal { get; set; }
    public IList<uimT4Kelurahan> DtT4KelurahanAsal { get; set; }
    public IList<uimT3Kecamatan> DtT3KecamatanTinggal { get; set; }
    public IList<uimT4Kelurahan> DtT4KelurahanTinggal { get; set; }
    //public IList<uimT0DivisiPerusahaan> DtT0DivisiPerusahaan { get; set; }
    public IList<dynamic> DtJabatan { get; set; }
    //public IEnumerable<uimT1JadwalKerjaKaryawan> DtT1JadwalKerja { get; set; }
    public IList<dynamic> DtGrdJabatanKaryawan { get; set; }
    public string Lfc_Detil { get; set; } //Last focused column
    public object DrJabatan { get; set; }
    public Guid? DrJabatan_GrdJabatanKaryawan { get; set; } = Guid.NewGuid();

    protected override void OnInitialized()
	{
		base.OnInitialized();
    }
	protected override void OnAfterRender(bool firstRender)
	{
		//if (firstRender)
		//{
		//	var components = Assembly.GetExecutingAssembly().ExportedTypes.Where(t => t.IsSubclassOf(typeof(ComponentBase))).ToList().Where(c => c.Name.Substring(0, 3) == "Rcp");

		//	var component = components?.FirstOrDefault(r => r.Name.Substring(3) == DataForm?.Form.Replace(" ", ""));
		//	var properties = component?.GetProperties().Where(p => !p.DeclaringType.Namespace.Contains("Pantheon"));
		//	foreach (var prop in properties ?? new List<PropertyInfo>())
		//	{
		//		if (prop.PropertyType.Name.Contains("DxComboBox"))
		//		{
		//			System.Type type = System.Type.GetType(prop.PropertyType.Name);
		//			DxComboBox<uimT2Kota, uimT2Kota> c = new();
		//			var control = (DxComboBox<uimT2Kota, uimT2Kota>)prop.GetValue(this);
		//			if (control == null) continue;
  //                  control.InputId = prop.Name;
		//			//ListCmb.Add(new BaseCmb() { Cmb = control });
		//		}
		//	}
		//}
		base.OnAfterRender(firstRender);
    }
	#region Rekapitulasi
	public override void ProsesPerbarui_Rekapitulasi(string namaMethod = null, object[] parameters = null)
	{
		PrimaryText = "NamaPanggilan";
		base.ProsesPerbarui_Rekapitulasi();
    }

	public override async void ProsesSeleksiData(object data)
	{
		base.ProsesSeleksiData(data);
        //DrJabatan = DtJabatan.FirstOrDefault(x => x.IdJabatan == DtRekapitulasi_Terseleksi.IdJabatan);
        DtJabatan = await ch.Get_Jabatan();
        DtT3KecamatanAsal = await ch.Get_KecamatanByIdKota(DtRekapitulasi_Terseleksi.IdKotaAsal);
        DtT4KelurahanAsal = await ch.Get_KelurahanByIdKecamatan(DtRekapitulasi_Terseleksi.IdKecamatanAsal);
        DtT3KecamatanTinggal = await ch.Get_KecamatanByIdKota(DtRekapitulasi_Terseleksi.IdKotaTinggal);
        DtT4KelurahanTinggal = await ch.Get_KelurahanByIdKecamatan(DtRekapitulasi_Terseleksi.IdKecamatanTinggal);
        var drT2KotaAsal = DtT2Kota.FirstOrDefault(t => t.IdKota == (DtRekapitulasi_Terseleksi.IdKotaAsal ?? 0));
		if (drT2KotaAsal is not null)
			DtRekapitulasi_Terseleksi.ProvinsiAsal = $"{drT2KotaAsal.Provinsi}, {drT2KotaAsal.Negara}";
        var drT2KotaTinggal = DtT2Kota.FirstOrDefault(t => t.IdKota == (DtRekapitulasi_Terseleksi.IdKotaTinggal ?? 0));
        if (drT2KotaTinggal is not null)
            DtRekapitulasi_Terseleksi.ProvinsiTinggal = $"{drT2KotaTinggal.Provinsi}, {drT2KotaTinggal.Negara}";

        //DtT0DivisiPerusahaan = await ch.Get_DivisiPerusahaan();

        await InvokeAsync(StateHasChanged);
    }
    #endregion

    #region Detil
    public override async Task ProsesMuat_Detil()
    {
        ListTxb.AddRange(new BaseTxb[] {
            new BaseTxb() { Txb = TxbUsia, HanyaBaca = true },
            new BaseTxb() { Txb = TxbLamaKerja, HanyaBaca = true },
            new BaseTxb() { Txb = TxbProvinsiAsal, HanyaBaca = true },
            new BaseTxb() { Txb = TxbProvinsiTinggal, HanyaBaca = true }});
        ListCmb.AddRange(new BaseCmb[]
        {
            new BaseCmb() { Cmb = CmbJabatan }
        });
        ListGrd.AddRange(new BaseGrd[]
        {
            new BaseGrd() { Grd = GrdJabatanKaryawan, NamaGrid = "GrdJabatanKaryawan" }
        });
        ListLompatForm.AddRange(new string[] { "Jabatan" });
        await base.ProsesMuat_Detil();		
		DtT2Kota = await ch.Get_Kota();
        //DtT0DivisiPerusahaan = await ch.Get_DivisiPerusahaan();
        DtJabatan = await ch.Get_Jabatan();
        //DtT1JadwalKerja = await _svcJadwalKerja.GetDataJadwalKerjaKaryawan();
        //await _js.InvokeVoidAsync("changePasswordVisibility", "PasswordKaryawan", false);
    }
    protected async void KotaAsal_ValueChanged(long? val)
	{
		if (val is null) return;
		DtRekapitulasi_Terseleksi.IdKotaAsal = val;
        DtT3KecamatanAsal = await ch.Get_KecamatanByIdKota(DtRekapitulasi_Terseleksi.IdKotaAsal);
		var dr = DtT2Kota.FirstOrDefault(t => t.IdKota == (val ?? 0));
        DtRekapitulasi_Terseleksi.ProvinsiAsal = $"{dr.Provinsi}, {dr.Negara}";
        await InvokeAsync(StateHasChanged);
    }
    protected async void KecamatanAsal_ValueChanged(long? val)
    {
        DtRekapitulasi_Terseleksi.IdKecamatanAsal = val;
        DtT4KelurahanAsal = await ch.Get_KelurahanByIdKecamatan(DtRekapitulasi_Terseleksi.IdKecamatanAsal);
        await InvokeAsync(StateHasChanged);
    }
    protected async void KotaTinggal_ValueChanged(long? val)
    {
        if (val is null) return;
        DtRekapitulasi_Terseleksi.IdKotaTinggal = val;
        DtT3KecamatanTinggal = await ch.Get_KecamatanByIdKota(DtRekapitulasi_Terseleksi.IdKotaTinggal);
        var dr = DtT2Kota.FirstOrDefault(t => t.IdKota == (val ?? 0));
        DtRekapitulasi_Terseleksi.ProvinsiTinggal = $"{dr.Provinsi}, {dr.Negara}";
        await InvokeAsync(StateHasChanged);
    }
    protected async void KecamatanTinggal_ValueChanged(long? val)
    {
        DtRekapitulasi_Terseleksi.IdKecamatanTinggal = val;
        DtT4KelurahanTinggal = await ch.Get_KelurahanByIdKecamatan(DtRekapitulasi_Terseleksi.IdKecamatanTinggal);
        await InvokeAsync(StateHasChanged);
    }
    protected async void CmbJabatan_DropDownVisibleChanged(bool val)
    {
        if (val == true) 
        {
            DtJabatan = await ch.Get_Jabatan();
            await InvokeAsync(StateHasChanged);
        }
    }
    protected async void CmbJabatan_GrdJabatanKaryawan_DropDownVisibleChanged(bool val)
    {
        if (val == true)
        {
            DtJabatan = await ch.Get_Jabatan();
            await InvokeAsync(StateHasChanged);
        }
    }
    protected async void GrdJabatanKaryawan_RowClick(GridRowClickEventArgs e)
    {
        Lfc_Detil = ((DxGridDataColumn)e.Column).FieldName;
        await e.Grid.StartEditRowAsync(e.VisibleIndex);
    }
    protected void GrdJabatanKaryawan_CustomizeEditModel(GridCustomizeEditModelEventArgs e)
    {
        if (e.IsNew)
        {
            //var newDetil = (uimT5JabatanKaryawan)e.EditModel;
            //newDetil.IdJabatan = Guid.Empty;
            //newDetil.IdKaryawan = DtRekapitulasi_Terseleksi.IdKaryawan;
            //newDetil.IsDefault = false;
        }
    }
    protected void GrdJabatanKaryawan_CustomizeElement(GridCustomizeElementEventArgs e)
    {
        e.CssClass = "font_0";
    }
    public void ProsesGeneratePassword(ChangeEventArgs e)
	{
        string text = e.Value?.ToString() ?? "";
		if (string.IsNullOrEmpty(text)) { DtRekapitulasi_Terseleksi.Password = ""; return; }
		DtRekapitulasi_Terseleksi.Password = char.ToUpper(text[0]) + text.Substring(1).ToLower().Replace(" ", "");

    }
    //Proses Pilih Gambar
    async Task ProsesPilihGambar(InputFileChangeEventArgs e)
	{
		var files = e.GetMultipleFiles(); // get the files selected by the users
		foreach (var file in files)
		{
			var resizedFile = await file.RequestImageFileAsync(file.ContentType, 640, 480); // resize the image file
			var buf = new byte[resizedFile.Size]; // allocate a buffer to fill with the file's data
			using (var stream = resizedFile.OpenReadStream())
			{
				await stream.ReadAsync(buf); // copy the stream to the buffer
			}
			_gambar.Add(new T5Gambar { base64data = Convert.ToBase64String(buf), contentType = file.ContentType, fileName = file.Name }); // convert to a base64 string!!
		}
	}

    private async void ProsesTabDipilih()
    {

        //await JsRuntime.InvokeVoidAsync("OnScrollEvent");
        await _js.InvokeVoidAsync("autoScrollKetikaPindahTab");
    }

    #endregion

    #region Navigasi
    public override async Task ProsesDataBaru()
    {
        await base.ProsesDataBaru();
    }
    public override void ProsesUpdateDatabase()
	{
        //var value = DtRekapitulasi_Terseleksi.JenisKelamin;
		base.ProsesUpdateDatabase();

		//var h = DtRekapitulasi.FirstOrDefault().IdJabatan;
		//var i = DtRekapitulasi.FirstOrDefault(x => x.IdJabatan == DtRekapitulasi_Terseleksi.IdJabatan);

		//var dataDiupdate = DtRekapitulasi.FirstOrDefault(x => x.IdJabatan == DtRekapitulasi_Terseleksi.IdJabatan);
		//DtRekapitulasi_Terseleksi.Adapt(dataDiupdate);
		//InvokeAsync(StateHasChanged);
	}
	#endregion

	public class T5Gambar
	{
		public string base64data { get; set; }
		public string contentType { get; set; }
		public string fileName { get; set; }
		public string Kategori { get; set; }
		public string Keterangan { get; set; }
	}
}
