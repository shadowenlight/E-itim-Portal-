using Eğitim_Portalı.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace Eğitim_Portalı.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new EğitimPortalıDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<EğitimPortalıDbContext>>()))
            {

                if (context.eğitimler.Any() == false)
                {
                    context.eğitimler.AddRange(
                            new Eğitim
                            {
                                kategori = "Yapay Zeka",
                                eğitmenBilgisi = "Ömer Işık",
                                kontenjan = 3,
                                günlükFiyat = 19,
                                eğitimSüresiGün = 20,
                                oluşturmaTarihi = DateTime.Now,
                                güncellemeTarihi = DateTime.Now
                            }
                            );
                    context.SaveChanges();
                }
                if (context.roller.Any() == false)
                {
                    var rol = new Rol
                    {
                        rolAdı = "Eğitmen",
                        rolTanımı = "Eğitim planı oluşturma, eğitim video kayıt yükleme ve canlı yayın açma.",
                        oluşturmaTarihi = DateTime.Now,
                        güncellemeTarihi = DateTime.Now,
                        yetkiler = null,
                        kullanıcılar = null
                    };
                    context.roller.Add(rol);
                    context.SaveChanges();
                }
                if (context.yetkiler.Any() == false)
                {
                    var yetki = new Yetki
                    {
                        yetkiAdı = "Öğrenci ekleme",
                        yetkiTanımı = "Öğrenci ekleme",
                        oluşturmaTarihi = DateTime.Now,
                        güncellemeTarihi = DateTime.Now,
                        roller = null
                    };
                    context.yetkiler.Add(yetki);
                    context.roller.First().yetkiler = context.yetkiler.ToList();
                    context.yetkiler.First().roller = context.roller.Where(x => x.rolAdı == "Eğitmen").ToList();
                    context.SaveChanges();
                }
                if (context.kullanıcılar.Any() == false)
                {
                    var kullanıcı = new Kullanıcı
                    {
                        kullanıcıAdı = "Oğuz",
                        mailAdresi = "1000tl@gmail.com",
                        şifre = "1000-150=850",
                        rol = context.roller.First(),
                        oluşturmaTarihi = DateTime.Now,
                        sonGiriş = DateTime.Now,
                    };
                    context.kullanıcılar.Add(kullanıcı);
                    context.kullanıcılar.First().rol = context.roller.First();
                    context.roller.First().kullanıcılar = context.kullanıcılar.Where(x => x.rol == context.roller.First()).ToList();
                    context.SaveChanges();
                }
                if (context.alınanEğitimler.Any() == false)
                {
                    var aEğitim = new AlınanEğitim
                    {
                        aEğitimAdı = "Yapay Zeka",
                        aEğitimDurumu = "Tamamlanmadı",
                        alımTarihi = DateTime.Now,
                        güncellemeTarihi = DateTime.Now
                    };
                    context.alınanEğitimler.Add(aEğitim);
                    context.kullanıcılar.First().alınanEğitimler = context.alınanEğitimler.ToList();
                    context.SaveChanges();
                }
            }
        }
    }
}
