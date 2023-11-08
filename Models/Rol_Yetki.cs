global using System.ComponentModel.DataAnnotations;

namespace Eğitim_Portalı.Models
{
    public class Rol
    {
        [Key]
        public int rolId { get; set; }
        public ICollection<Kullanıcı>? kullanıcılar {  get; set; }
        public ICollection<Yetki>? yetkiler{ get; set; }
        public required string rolAdı { get; set; }
        public required string rolTanımı { get; set; }
        public required DateTime oluşturmaTarihi { get; set; }
        public required DateTime güncellemeTarihi { get; set; } 

    }

    public class Yetki
    {
        [Key]
        public int yetkiId { get; set; }
        public required string yetkiAdı { get; set; }
        public required string yetkiTanımı { get; set; }
        public ICollection<Rol>? roller { get; set; }
        public required DateTime oluşturmaTarihi { get; set; }
        public required DateTime güncellemeTarihi { get; set; }
    }
}
