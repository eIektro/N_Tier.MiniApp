# N_Tier.MiniApp

## Nedir?

**N_Tier.MiniApp**, katmanlı mimari yapısında oluşturulmuş; **Unit Of Work** ve **Repository** tasarım desenlerini kullanan servisler aracılığıyla veritabanı işlemlerini (Okuma, Yazma, Silme, Güncelleme) gerçekleştiren bir uygulama örneğidir.

### Kullanılan Teknolojiler

* Entity Framework Core (WebAPI katmanında)
* Npgsql (Data katmanında, Postgres veritabanına erişim için)
* AutoMapper (WebAPI)
* FluentValudation (WebAPI)
* Swagger (WebAPI)

### Bağımlılık Bulunan .NET Paketleri

* .NET Framework 4.7.2 (Presentation.WebUI katmanı)
* .NET Core 3.1 (WebAPI katmanı)
* .NET Standart 2.0 (Class Library olan katmanlar için)


## Veritabanı Bağlantısı

**N-Tier.MiniApp.WebAPI** yoluna **appsettings.json** ve **appsettings.Development.json** dosyalarını oluşturun ve içerisine aşağıdaki json'a **bağlantı dizenizi** ekleyerek, kopyalayıp yapıştırın.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "PostgresConnection": "**Bağlantı Dizesi**"
  }
}
```

## Projeyi Başlatma

**Presentation.WebUI** katmanı verilere **WebAPI** aracılığı ile ulaşır. Bu nedenle projeyi çalıştırken bu iki projeyi aynı anda ayağa kaldırmanız gerekecektir. Örnekteki gibi yapabilirsiniz:

![image](https://drive.google.com/uc?export=view&id=1kQRHXqpJQ1d5VNaOq_eZSoxJkwtesqXq)

## Presentation.WebUI - WebAPI Bağlantısı

**Presentation.WebUI\web.config** dosyasının içerisine **apiBaseAdress** kısmına **WebAPI**'ın bağlantısını tanımlamalısınız. Örnekteki gibi localhost altında çalıştığı portu yazmanız yeterli olacaktır:

![image](https://drive.google.com/uc?export=view&id=1_eVFSbEsRndnF8mTmPDfed1GPxnBT3GT)

## Ekran Görüntüleri

### Swagger UI

![image](https://drive.google.com/uc?export=view&id=1c5xmCToi5hNIuz3t1uXcH8SNgaY2uyjv)
