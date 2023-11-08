namespace Eğitim_Portalı.Models
{
    public class Kullanıcı
    {
        [Key]
        public int kullanıcıId { get; set; }
        public required string kullanıcıAdı {  get; set; }
        public required string mailAdresi {  get; set; }
        public required string şifre { get; set; }
        public ICollection <AlınanEğitim>? alınanEğitimler { get; set; }
        public int aEğitimId { get; set; }
        public required Rol rol { get; set; }
        public int rolId {  get; set; }
        public DateTime oluşturmaTarihi { get; set; }
        public DateTime sonGiriş { get; set; }
    }

    public class AlınanEğitim
    {
        [Key]
        public int aEğitimId { get; set; }
        public required string aEğitimAdı { get; set; }
        public required string aEğitimDurumu { get; set; }
        public required DateTime alımTarihi { get; set; }
        public required DateTime güncellemeTarihi { get; set; }

    }
}
