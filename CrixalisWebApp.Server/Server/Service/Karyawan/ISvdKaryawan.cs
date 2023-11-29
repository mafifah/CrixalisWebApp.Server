using bwaCrixalis.Shared._1._Master;

namespace bwaCrixalis.Server._1._Master;

public interface ISvdKaryawan : pthISvdMaster
{
	Task<IEnumerable<pthT1Karyawan>> GetKaryawan();
	Task<string> WriteJabatanKaryawan(pthT5JabatanKaryawan t5JabatanKaryawan);
}
