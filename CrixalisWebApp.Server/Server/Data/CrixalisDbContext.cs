using bwaCrixalis.Shared._2._Transaksi;
using Microsoft.EntityFrameworkCore;
using Pantheon.Server.DataAccess;

namespace bwaCrixalis.Server.Data;
public class CrixalisDbContext : pthDbContext
{
	public CrixalisDbContext(DbContextOptions<CrixalisDbContext> options) : base(options) { }

	public DbSet<T0DivisiBarang> T0DivisiBarang { get; set; }
	public DbSet<T0KategoriBarang> T0KategoriBarang { get; set; }
	public DbSet<T0BBM> T0BBM { get; set; }
	public DbSet<T0JenisArmada> T0JenisArmada { get; set; }
	public DbSet<T0DivisiServis> T0DivisiServis { get; set; }
	public DbSet<T0Gudang> T0Gudang { get; set; }
	public DbSet<T0JenisCustomer> T0JenisCustomer { get; set; }
	public DbSet<T0JenisSupplier> T0JenisSupplier { get; set; }
	public DbSet<T0JenisVendor> T0JenisVendor { get; set; }
	public DbSet<T0JenisWarna> T0JenisWarna { get; set; }
	public DbSet<T0KategoriJadwalKerjaKaryawan> T0KategoriJadwalKerjaKaryawan { get; set; }
	public DbSet<T0KategoriServis> T0KategoriServis { get; set; }
	public DbSet<T1Armada> T1Armada { get; set; }
	public DbSet<T1Warna> T1Warna { get; set; }
	public DbSet<T1Customer> T1Customer { get; set; }
	public DbSet<T1JadwalKerjaKaryawan> T1JadwalKerjaKaryawan { get; set; }
	public DbSet<T1SubDivisiBarang> T1SubDivisiBarang { get; set; }
	public DbSet<T1SubKategoriBarang> T1SubKategoriBarang { get; set; }
	public DbSet<T1SubDivisiServis> T1SubDivisiServis { get; set; }
	public DbSet<T1SubKategoriServis> T1SubKategoriServis { get; set; }
	public DbSet<T1Supplier> T1Supplier { get; set; }
    public DbSet<T1Vendor> T1Vendor { get; set; }
	public DbSet<T1Aset> T1Aset { get; set; }
	public DbSet<T2AlamatSupplier> T2AlamatSupplier { get; set; }
	public DbSet<T2AlamatVendor> T2AlamatVendor { get; set; }	
	public DbSet<T2Barang> T2Barang { get; set; }
	public DbSet<T2Servis> T2Servis { get; set; }
    public DbSet<T2PenyeliaSupplier> T2PenyeliaSupplier { get; set; }
	public DbSet<T2PenyeliaVendor> T2PenyeliaVendor { get; set; }
	public DbSet<T3Satuan> T3Satuan { get; set; }
	public DbSet<T4DiskonBarang> T4DiskonBarang { get; set; }
	public DbSet<T4HargaBarang> T4HargaBarang { get; set; }
	public DbSet<T4HargaBBM> T4HargaBBM { get; set; }
	public DbSet<T4NopolArmada> T4NopolArmada { get; set; }
    public DbSet<T5ArmadaCustomer> T5ArmadaCustomer { get; set; }
    public DbSet<T5ArmadaSopir> T5ArmadaSopir { get; set; }
	public DbSet<T5CompanyGudang> T5CompanyGudang { get; set; }
    public DbSet<T5CompanySatuan> T5CompanySatuan { get; set; }
    public DbSet<T5Gambar> T5Gambar { get; set; }
    public DbSet<T5KaryawanCustomer> T5KaryawanCustomer { get; set; }
    public DbSet<T5SupplierSatuan> T5SupplierSatuan { get; set; }
    public DbSet<T5StokGudang> T5StokGudang { get; set; }
    public DbSet<T5VendorSupplier> T5VendorSupplier { get; set; }
	public DbSet<T6OrderPembelian> T6OrderPembelian { get; set; }
	public DbSet<T6OrderPenjualan> T6OrderPenjualan { get; set; }
	public DbSet<T6HutangUsaha> T6HutangUsaha { get; set; }
	public DbSet<T6PelunasanHutangUsaha> T6PelunasanHutangUsaha { get; set; }
	public DbSet<T6PiutangUsaha> T6PiutangUsaha{ get; set; }
	public DbSet<T6PelunasanPiutangUsaha> T6PelunasanPiutangUsaha { get; set; }
	public DbSet<T6HutangGiro> T6HutangGiro { get; set; }
	public DbSet<T6PencairanHutangGiro> T6PencairanHutangGiro { get; set; }
	public DbSet<T6PiutangGiro> T6PiutangGiro { get; set; }
	public DbSet<T6PencairanPiutangGiro> T6PencairanPiutangGiro { get; set; }
	public DbSet<T6PembelianAset> T6PembelianAset { get; set; }
	public DbSet<T6PenerimaanBarang> T6PenerimaanBarang { get; set; }
	public DbSet<T6PiutangKaryawan> T6PiutangKaryawan { get; set; }
	public DbSet<T6PelunasanPiutangKaryawan> T6PelunasanPiutangKaryawan { get; set; }
	public DbSet<T7OrderPembelian> T7OrderPembelian { get; set; }
	public DbSet<T7OrderPenjualan> T7OrderPenjualan { get; set; }
	public DbSet<T7PelunasanHutangUsaha> T7PelunasanHutangUsaha { get; set; }
	public DbSet<T7PelunasanPiutangUsaha> T7PelunasanPiutangUsaha { get; set; }
	public DbSet<T7PencairanHutangGiro> T7PencairanHutangGiro { get; set; }
	public DbSet<T7PencairanPiutangGiro> T7PencairanPiutangGiro { get; set; }
	public DbSet<T7PembelianAset> T7PembelianAset { get; set; }
	public DbSet<T7PenerimaanBarang> T7PenerimaanBarang { get; set; }
	public DbSet<T7PelunasanPiutangKaryawan> T7PelunasanPiutangKaryawan { get; set; }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<T0Jabatan>()
        //    .HasMany(e => e.ListT1Karyawan)
        //    .WithMany(e => e.ListT0Jabatan)
        //    .UsingEntity<T5JabatanKaryawan>(
        //        l => l.HasOne<T1Karyawan>().WithMany(e => e.ListT5JabatanKaryawan),
        //        r => r.HasOne<T0Jabatan>().WithMany(e => e.ListT5JabatanKaryawan));

        modelBuilder.Entity<T5ArmadaCustomer>(t =>
		{
			t.HasKey(e => new { e.IdArmada, e.IdCustomer });
		});

		modelBuilder.Entity<T5ArmadaSopir>(t =>
		{
			t.HasKey(e => new { e.IdArmada, e.IdKaryawan_Sopir });
		});
		modelBuilder.Entity<T5CompanyGudang>(t =>
		{
			t.HasKey(e => new { e.IdCompany, e.IdGudang });
		});
        modelBuilder.Entity<T5CompanySatuan>(t =>
        {
            t.HasKey(e => new { e.IdCompany, e.IdSatuan });
        });
        modelBuilder.Entity<T5KaryawanCustomer>(t =>
        {
            t.HasKey(e => new { e.IdCustomer, e.IdKaryawan });
        });
        modelBuilder.Entity<T5StokGudang>(t =>
        {
            t.HasKey(e => new { e.IdSatuan, e.IdGudang });
        });
        modelBuilder.Entity<T5VendorSupplier>(t =>
		{
			t.HasKey(e => new { e.IdVendor, e.IdSupplier });
		});
		modelBuilder.Entity<T5SupplierSatuan>(t =>
		{
			t.HasKey(e => new { e.IdSupplier, e.IdSatuan });
		});
		// ignore a property that is not mapped to a database column
		//modelBuilder.Entity<T0Company>()
		//	.Ignore(p => p.IdCompany);
	}
}
