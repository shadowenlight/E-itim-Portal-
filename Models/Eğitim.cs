namespace Eğitim_Portalı.Models
{
    public class Eğitim
    {
        [Key]
        public int eğitimId { get; set; }
        public required string kategori {  get; set; }
        public required string eğitmenBilgisi { get; set; }
        public int kontenjan {  get; set; }
        public decimal günlükFiyat { get; set; }
        public int eğitimSüresiGün { get; set; }
        public DateTime oluşturmaTarihi { get; set; }
        public DateTime güncellemeTarihi { get; set; }
    }
}
