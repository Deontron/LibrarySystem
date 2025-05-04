Kütüphane Yönetim Sistemi (Library Management System)
Proje Hakkında
Bu proje, bir Kütüphane Yönetim Sistemi'ni simüle eder. Sistemde kullanıcılar kitap ekleyebilir, güncelleyebilir, listeleyebilir ve silebilir. Kullanıcılar aynı zamanda kitap ödünç alma ve iade işlemleri gerçekleştirebilir. Mikroservis mimarisiyle tasarlanmış olan bu sistemde her modül bağımsız bir mikroservis olarak çalışmaktadır.

Proje, ASP.NET Core, Docker ve PostgreSQL kullanılarak geliştirilmiştir.

Kullanılan Teknolojiler
ASP.NET Core 8.0: Web API'lerin geliştirilmesi için kullanıldı.

Docker: Her bir mikroservis için ayrı konteynerler oluşturulmuş ve sistem Docker üzerinde çalıştırılmaktadır.

PostgreSQL: Veritabanı yönetim sistemi olarak kullanıldı. Her mikroservisin kendi veritabanı vardır.

Entity Framework Core: Veritabanı işlemleri ve ORM (Object Relational Mapping) için kullanıldı.

Swagger: API dokümantasyonu ve test aracı olarak kullanıldı.

Proje Yapısı
Bu projede 4 ana mikroservis bulunmaktadır:

User Service: Kullanıcı işlemleri (kayıt, giriş, kullanıcı yönetimi) ile ilgilidir.

Book Catalog Service: Kitapların yönetimi (ekleme, silme, güncelleme) ile ilgilidir.

Loan Service: Kitap ödünç alma işlemleri ile ilgilidir.

Notification Service: Kullanıcılara bildirim gönderilmesi işlemleri ile ilgilidir.

Her mikroservisin kendi bağımsız veritabanı ve yapılandırması vardır. Bu mikroservisler Docker üzerinde çalıştırılmaktadır.

Kurulum
Prerequisites (Gereksinimler)
Docker: Docker kurulu olmalıdır. Docker'ı buradan indirebilirsiniz.

.NET SDK 8.0: .NET SDK'yı buradan indirip kurmalısınız.

Adımlar
Depoyu Klonlayın

git clone https://github.com/Deontron/LibrarySystem.git

Docker Compose ile Servisleri Başlatın

Docker Compose dosyasını kullanarak tüm mikroservisleri ve PostgreSQL veritabanını başlatabilirsiniz:

docker-compose up --build
Bu komut, her servisi bağımsız olarak Docker konteynerlerinde çalıştıracaktır. PostgreSQL veritabanı da ilgili mikroservislerle eşleşerek başlatılır.

Mikroservislere Erişim

User Service: http://localhost:5001

Book Catalog Service: http://localhost:5002

Loan Service: http://localhost:5003

Notification Service: http://localhost:5004

Bu adreslerden API'lere erişebilirsiniz.

Swagger UI'yi Kullanma

Her mikroservis, otomatik olarak Swagger ile API dokümantasyonunu oluşturur. API'yi test etmek ve dökümantasyon üzerinde gezmek için aşağıdaki URL'lere gidin:

User Service Swagger UI: http://localhost:5001/swagger

Book Catalog Service Swagger UI: http://localhost:5002/swagger

Loan Service Swagger UI: http://localhost:5003/swagger

Notification Service Swagger UI: http://localhost:5004/swagger

Çalıştırma
Projeyi çalıştırmak için Docker Compose dosyasını kullanarak servisleri başlatmalısınız. Servislerin her biri bağımsız olarak çalışır ve ilgili portlar üzerinden API'lere erişilebilir.

Docker Compose ile Servisleri Çalıştırma

docker-compose up
Uygulamayı Ziyaret Edin

Web API'leriniz Swagger UI üzerinden test edilebilir ve her servisin kendi portu üzerinden erişilebilir.

Veritabanı Yapılandırması
Veritabanı, PostgreSQL ile yönetilmektedir. Veritabanı yapılandırması docker-compose.yml dosyasında bulunmaktadır.

PostgreSQL Veritabanı Bağlantısı:

Host=postgres;Port=5432;Database=library;Username=postgres;Password=postgres
PostgreSQL veritabanı library adında oluşturulmuş olup, her mikroservisin bağımsız veritabanı bulunmaktadır.

Test ve Hata Ayıklama
Test Edilecek API'ler: Swagger UI üzerinde API'ler test edilebilir.

Hata Ayıklama: Docker konteynerlerinde hata ayıklamak için aşağıdaki komutu kullanarak servis loglarına erişebilirsiniz:

docker-compose logs <service-name>
Örneğin, book-service için:

docker-compose logs book-service

Proje, mikroservis mimarisini kullanarak modern ve esnek bir kütüphane yönetim sistemi inşa etmenizi sağlar.