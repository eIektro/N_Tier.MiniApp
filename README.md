# N_Tier.MiniApp

## Veritabanı Bağlantısı İçin

**N-Tier.MiniApp.WebAPI** yoluna **appsettings.json** ve **appsettings.Development.json** dosyalarını oluşturun ve içerisine aşağıdaki json'a **bağlantı dizenizi** ekleyin.

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
