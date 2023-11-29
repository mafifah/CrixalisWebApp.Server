using bwaCrixalis.Shared._1._Master;

namespace bwaCrixalis.Client._1._Master;
public class uimT1SupplierInstansi : T1Supplier
{
    public string Supplier => Nama + (!string.IsNullOrEmpty(Prefix) ? $", {Prefix}" : "");
    public string Kota => T2Kota?.Kota;
    public string IdCompany { get; set; }
    public bool StatusTerapkanSemuaCabang { get; set; } = false;
}
