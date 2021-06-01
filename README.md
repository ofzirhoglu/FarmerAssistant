# Farmer Assistant


> :bulb: Bu proje bildiğim ve kullandığım teknoloji ve yaklaşımların bir kısmına örnek teşkil etmesi amacı ile Cv'im için hazırlanmıştır.

## Genel proje yapısı

```text
src/
|
├── Business ---------------------------> İş mantığının gerçekleşeceği katman
|   ├── Abstract -----------------------> Service Interfacelerinin tanımlandığı yer
|   ├── Concrete -----------------------> Service Interfacelerinin implemende edildiği yer
|   ├── Constants ----------------------> Proje (Business) sabitlerinin tanımlandığı yer
|   ├── DependencyResolvers ------------> Bağımlılık çözücülerin tanımlandığı yer 
|   |   └── Autofac --------------------> Autofac ile bağımlılıkların çözüldüğü yer
|   └── ValidationRules ----------------> Doğrulama kurallarının yazıldığı yer
|       └── FluentValidation ----------------> FluentValidation ile doğrulama kurallarının yazıldığı yer
|  
├── Core -------------------------------> Proje genelinde kullanılacak altyapı katmanı
|   ├── Aspects ------------------------> Aspectlerin tanımlandığı yer
|   |   └── Autofac --------------------> Autofac ile aspect'lerin tanımlandığı yer
|   |       └── Validation -------------> Doğrulama aspect'inin tanımlandığı yer 
|   ├── CrossCuttingConcerns -----------> Cross cutting concern'lerin tanımlandığı yer
|   |   └── Validation -----------------> CCC'de doğrulama tanımlamasının yapıldığ yer
|   ├── DataAccess ---------------------> DataAccess katmanı için tanımlamaların yapıldığı yer
|   |   └── EntityFaramework -----------> DataAccess'de EntityFramework için tanımlamaların yapıldığı yer
|   ├── Entities -----------------------> Entities katmanı için tanımlamaların yapıldığı yer
|   |   ├── Abstract -------------------> Entities için interface'lerin tanımlandığı yer
|   |   └── Concrete -------------------> Entities için concrete'lerin tanımlandığı yer
|   └── Utilities ----------------------> Yardımcı araçların tanımlandığ yer
|       ├── Business -------------------> Business için yardımcı araçların tanımlandiğı yer
|       ├── Interceptors ---------------> Interceptor'lar için yardımcı araçların tanımlandığı yer
|       ├── Messages -------------------> Core genelinde kullanılacak sabit mesajların tanımlandığı yer
|       ├── Results --------------------> Result'lar için yardımcı araçların tanımlandiğı yer
|       └── Security -------------------> Security için yardımcı araçların tanımlandığı yer
|           ├── Encryption -------------> Encryption için yardımcı araçların tanımlandiğı yer      
|           ├── Hashing ----------------> Hashing için yardımcı araçların tanımlandiğı yer      
|           └── JWT --------------------> JWT için yardımcı araçların tanımlandiğı yer      
|
├── DataAccess -------------------------> Veritabanı işlemlerinin gerçekleşeceği katman  
|   ├── Abstract -----------------------> Veritabanı için interface'lerin tanımlandığı yer 
|   └── Concrete -----------------------> Veritabanı işlemleri için concrete'lerin tanımlandığı yer
|
├── Entities ---------------------------> Veritabanı tablolarını temsil eden katman
|   ├── Concrete -----------------------> Veritabanındaki tabloları temsil eden tanımlamaların yapıldığı yer
|   └── DTOs ---------------------------> Data Transfer Objects'lerin tanımlandığı yer 
|
└── WebApi -----------------------------> Api katmanı
    └── Controllers --------------------> Controller'in tanımlandığı yer
```
