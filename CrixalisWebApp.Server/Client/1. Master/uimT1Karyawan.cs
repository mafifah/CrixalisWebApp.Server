using Pantheon.Shared.BaseEntityModels;

namespace bwaCrixalis.Client._1._Master;
public class uimT1Karyawan : pthT1Karyawan
{
	public string Usia { get => TanggalLahir == null ? "" : (DateTime.Now.Year - TanggalLahir.Value.Year).ToString() + " Tahun"; }
    public string LamaKerja { get => TanggalRekrut == null ? "" : ((TanggalBerhenti == null ? DateTime.Now.Year : TanggalBerhenti.Value.Year) - TanggalRekrut.Value.Year).ToString() + " Tahun"; }
    public string ProvinsiAsal { get; set; }
    public string ProvinsiTinggal { get; set; }
    public string Password { get; set; }
	public string Jabatan { get; set; }
}