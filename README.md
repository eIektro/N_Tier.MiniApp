# N_Tier.MiniApp

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
