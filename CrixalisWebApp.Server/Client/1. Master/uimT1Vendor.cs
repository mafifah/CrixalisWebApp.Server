namespace bwaCrixalis.Client._1._Master;
public class uimT1Vendor : T1Vendor
{
	public string Vendor => Nama + (!string.IsNullOrEmpty(Prefix) ? $", {Prefix}" : "");
	public string Kota => T2Kota?.Kota;
}
