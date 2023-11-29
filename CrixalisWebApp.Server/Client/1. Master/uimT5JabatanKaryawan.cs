namespace bwaCrixalis.Client._1._Master;
public class uimT5JabatanKaryawan : pthT5JabatanKaryawan
{
    public string Jabatan_Kode { get; set; }

    private string? _jabatan = null;
    public string? Jabatan
    {
        get => _jabatan ?? (T1Karyawan?.T0Jabatan.Jabatan);
        set { _jabatan = value; }
    }

    private string? _namaLengkap = null;
    public string? NamaLengkap
    {
        get => _namaLengkap ?? (T1Karyawan?.NamaLengkap);
        set { _namaLengkap = value; }
    }
}