<h1>Kitap Uygulaması Web API</h1>
<p>Bu C# Web API uygulaması, kitap, yazar, tür ve kullanıcı kayıtlarını yönetmek için tasarlanmıştır.</p>
<h2>API Kullanımı</h2>
<p>API'ye erişmek için, API ana URL'sini kullanarak HTTP istekleri göndermelisiniz. Örneğin, kitapları listelemek için <code>GET</code> isteği göndermeniz gerekmektedir:</p>
<pre><code>GET https://localhost:5001/api/books
</code></pre>
<p>Bir kitap eklemek için <code>POST</code> isteği göndermeniz gerekmektedir:</p>
<pre><code>POST https://localhost:5001/api/books
Content-Type: application/json

{
    "title": "Harry Potter and the Philosopher's Stone",
    "author": "J.K. Rowling",
    "genre": 1
}
</code></pre>
<p>Bir kitabı güncellemek için <code>PUT</code> isteği göndermeniz gerekmektedir:</p>
<pre><code>PUT https://localhost:5001/api/books/1
Content-Type: application/json

{
    "title": "Harry Potter and the Sorcerer's Stone",
    "author": "J.K. Rowling",
    "genre": 2
}
</code></pre>
<p>Bir kitabı silmek için <code>DELETE</code> isteği göndermeniz gerekmektedir:</p>
<pre><code>DELETE https://localhost:5001/api/books/1
</code></pre>
<p>Diğer kayıt türleri (yazar, tür, kullanıcı) için de benzer istekler gönderebilirsiniz.</p>
<h2>API Belgeleri</h2>
<p>API belgeleri, API'nin kullanımı hakkında ayrıntılı bilgi sağlar. API belgelerinde, API'nin kullanımı, özellikleri ve örnekleri yer alır.</p>
<p>API belgelerine erişmek için, API'nin ana URL'sine "/swagger" ekleyebilirsiniz. Örneğin, "https://localhost:5001/swagger" adresi API belgelerine yönlendirir.</p>
<h2>API Lisansı</h2>
<p>API'nin lisansı, API'nin kullanımı hakkında bilgi sağlar. API'nin lisansı, kullanıcıların API'yi nasıl kullanabileceğini belirler.</p>
<p>API'nin lisansı, API belgelerinde yer almaktadır. Kullanıcıların API'yi kullanmadan önce lisansı okumaları ve kabul etmeleri gerekmektedir.</p>
<h2>Kurulum</h2>
<p>Bu uygulamayı çalıştırmak için aşağıdaki adımları izleyin:</p>
<ol>
<li>Bu repo'yu klonlayın.</li>
<li>.NET Core 6 SDK yükleyin</li>
<li>Visual Studio veya bir metin düzenleyici kullanarak proje dosyalarını açın.</li>
<li>Uygulamanın çalıştırılması için gerekli olan bağımlılıkları yüklemek için NuGet Paket Yöneticisi'ni kullanın.</li>
<li>Uygulamayı çalıştırmak için, "IIS Express" veya "localhost" sunucusunu kullanarak uygulama çalıştırılabilir.</li>
<li>API'ye erişmek için, uygun URL'leri kullanarak HTTP istekleri gönderin.</li>
</ol>
<h2>Katılımcılar</h2>
<p>Bu proje açık kaynaklıdır ve katkıda bulunmak isteyenler tarafından geliştirilmiştir. Her türlü katkı, öneri ve geri bildirimler hoş karşılanmaktadır.</p>
<p>Katkıda bulunmak isteyenler, projeyi çatallayabilir, geliştirebilir ve özellikle hata ayıklama, belgeleme ve testler konusunda yardımcı olabilir.</p>
<p>Lütfen katkıda bulunmadan önce CONTRIBUTING.md dosyasını okuyunuz ve proje ile ilgili sorularınızı veya önerilerinizi GitHub Issues bölümünde paylaşınız.</p>
<h2>Lisans</h2>
<p>Bu proje MIT Lisansı ile lisanslanmıştır. Daha fazla bilgi için LICENSE dosyasını okuyunuz.</p>
