Bu projede, ASP.NET Core 8 platformunda onion architecture (soğan mimarisi) kullanarak geliştirme yapmaya çalıştım.

HomeController'ında iki tane metodumuz var: Index ve Detail. 

Web sayfası açıldığında Index metodu çalışarak Ana Sayfamıza verilerimizi getirmekte.

Index metodu, Mediator aracılığıyla Application katmanına istek göndermekte. 

Application katmanında business (iş) işlemlerini gerçekleştirdim. 

Data okuma işlemi yapılacağında CQRS'e uygun olarak Application > Features > HomePage > Queries katmanında, 

Services katmanında işlemleri gerçekleştirdim.

İstenen data dış kaynaklı bir veri olduğundan, 

Infrastructure katmanında HttpClient ile dışarıdaki bir JSON datasını çekme işlemi gerçekleştirdim. 

Bu verinin modellerini Domain > Entities katmanında oluşturdum.

Datanın en son aynı adımları geri gelerek gelmesiyle HomeController altındaki Index metodunda küçük bir sayfalama (pagination) işlemi gerçekleştirerek verileri ekranda gösterdim.