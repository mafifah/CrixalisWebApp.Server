namespace bwaCrixalis.Client._1._Master;

public class uimT5VendorSupplier : T5VendorSupplier
{
    public uimT1Vendor T1Vendor { get; set; }

    public string Vendor => T1Vendor?.Nama;
    public string Prefix => T1Vendor?.Prefix;
    public string Inisial => T1Vendor?.Inisial;
    public string Alamat => T1Vendor?.Alamat;
    public string Kota => T1Vendor?.Kota;

}
