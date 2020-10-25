using Microsoft.EntityFrameworkCore.Migrations;

namespace N_Tier.MiniApp.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Gorev tablosu
            migrationBuilder.Sql("INSERT INTO gorev (gorevadi, gorevtanimi) Values ('Yazılım Geliştirme','Mevcut yazılımların bakımı ve ihtiyaç halinde yeni yazılımlar geliştirilmesi.')");
            migrationBuilder.Sql("INSERT INTO gorev (gorevadi, gorevtanimi) Values ('Yazılım Test','Yazılımların iyileştirilmesi için test edilmesi ve raporlar oluşturulması.')");
            //Sirket tablosu
            migrationBuilder.Sql("INSERT INTO sirket (id,sirketadi,unvan,email,adres,logo ) Values (default, 'S360', 'S360 Sürdürülebilirlik Hizmetleri A.Ş.', 'info@s360.com.tr', 'Yeşilce Mah. Yunus Emre Cad. Nil" +
                " Ticaret Merkezi No: 8 Kat: 1 34418 4.Levent, İstanbul', default)");
            migrationBuilder.Sql("INSERT INTO sirket (id,sirketadi,unvan,email,adres,logo) Values (default,'SAKUSOFT','Sakusoft İş Zekası Çözümleri', 'info@sakusoft.com', 'Maslak Mh, Dereboyu 2 Cd No: 15 - A Ata " +
                "Center D: 81 Kat: 1 Sarıyer', default)");
            //Kullanici tablosu
            migrationBuilder.Sql("INSERT INTO kullanici (id, isim, soyisim, dogumtarihi, email, pasword, gorev, sirket) Values (default, 'Erme', 'Larok', '1996-11-07', 'erme@larok.com','136411f11a0ba1bfab8b97bbe5229216', default, default)");
            migrationBuilder.Sql("INSERT INTO kullanici (id, isim, soyisim, dogumtarihi, email, pasword, gorev, sirket) Values (default, 'Emre', 'Koral', '1996-11-07', 'emre@koral.com','8287458823facb8ff918dbfabcd22ccb', default, default)");
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM gorev");
            migrationBuilder.Sql("DELETE FROM kullanici");
            migrationBuilder.Sql("DELETE FROM sirket");
        }
    }
}
