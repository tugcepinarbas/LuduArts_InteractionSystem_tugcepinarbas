# LUDU ARTS - UNITY DEVELOPER INTERN CASE STUDY 
## Tuğçe Pınarbaş
## 30.01.2026 10:30 


 Bilgi | Değer |
|-------|-------|
| Toplam prompt sayısı | X |
| Kullanılan araçlar | ChatGPT / Claude / Copilot |
| En çok yardım alınan konular | [liste] |
| Tahmini LLM ile kazanılan süre | X saat |

## Prompt 1: [Gidişat]

**Araç:** [Gemini]
**Tarih/Saat:** 2026-01-30 10:30

**Prompt:**
```
[Sana dokümanları attım bana bir özet geç]
```

**Alınan Cevap (Özet):**
```
[Tüm dokümanları inceledim. Ludu Arts gerçekten çok disiplinli bir yapı istiyor. 
Özellikle CSharp_Coding_Conventions.md dosyasındaki Region sıralaması ve prefix (m_, s_, k_) kullanımı hayati önem taşıyor.Hiç vakit kaybetmeden 1.Saat: Core System aşamasına geçiyoruz.

Yapılacaklar Listesi:

Klasörleri Hazırla: Daha önce konuştuğumuz hiyerarşiyi Unity'de kurdun mu? Kurmadıysan hemen Assets/[ProjeAdın]/Scripts/Runtime/Core gibi ilerle.

IInteractable Arayüzü: Bu bizim kalbimiz. Diğer tüm nesneler (Kapı, Sandık vb.) bu dili konuşacak.]

**Nasıl Kullandım:**
- [ ] Direkt kullandım (değişiklik yapmadan)
- [x] Adapte ettim (değişiklikler yaparak)
- [ ] Reddettim (kullanmadım)

**Açıklama:**
> [Bu prompt ile karmaşık dosya yapılarının içerisinde boğulmadan, özetle bir yol haritası çıkarmış oldum. 
ilk ne yapmalıyım? nereden başlamalıyım? gibi soru işaretlerimin kaybolmasında yardımcı oldu.]

**Yapılan Değişiklikler (adapte ettiyseniz):**
> [Plane,Character,Chest, Door ve Light Switchleri oluşturduktan sonra position,scale vs kendimce ayarladım.İsimleri dosyaya göre uyarladım.]

---

## Prompt 2: [Interaction Detector]

**Araç:** [Gemini]
**Tarih/Saat:** 2026-01-30 12:40

**Prompt:**
```
[interaction detector ne için yazıyoruz]
```

**Alınan Cevap (Özet):**
```
[InteractionDetector, oyuncunun dünyayı "görmesini" ve objelerle iletişim kurmasını sağlayan merkezi bir mekanizmadır. 
Ludu Arts case dökümanındaki "Modülerlik" ve "Genişletilebilirlik" hedeflerine ulaşmak için bu script hayati önem taşır.İşte bu scripti yazma amaçlarımız:

1. "Kiminle" Etkileşime Girileceğini Belirlemek
Oyuncu dünyada bir sürü objeye bakar (zemin, duvar, gökyüzü). Bu script, Raycast (görünmez bir ışın) kullanarak sadece Interactable layer'ındaki (katmanındaki) objeleri filtreler. 
Bu, sistemin performanslı çalışmasını sağlar.

2. İletişim Köprüsü Kurmak (Interface Kullanımı)
Detector, baktığı şeyin bir "Kapı" mı yoksa "Sandık" mı olduğunu bilmez. Sadece baktığı objede IInteractable arayüzünün (interface) olup olmadığına bakar.
Eğer arayüz varsa, nesneye "Seninle etkileşime giriyorum!" mesajını gönderir.Bu sayede yeni bir obje eklediğinizde (örneğin bir 'Lamba'), Detector kodunda hiçbir değişiklik yapmanıza gerek kalmaz.

3. Girdi Yönetimi (Input Management)
Oyuncu "E" tuşuna bastığında ne olacağına bu script karar verir.
OnInteract: Tuşa basıldığı an tetiklenir. OnInteractionStart/End: Tuşa basılı tutma (Hold) gibi durumları yönetmek için temel hazırlar.

4. Kullanıcı Deneyimi (UI/Prompt)
İlerleyen aşamalarda, ekranda "Kapıyı açmak için E'ye bas" yazısını bu script sayesinde göstereceğiz. 
Çünkü Detector, o an hangi objeye baktığımızı biliyor ve o objeden GetInteractionPrompt() bilgisini çekebiliyor.]


**Nasıl Kullandım:**
- [ ] Direkt kullandım (değişiklik yapmadan)
- [x] Adapte ettim (değişiklikler yaparak)
- [ ] Reddettim (kullanmadım)

**Açıklama:**
> []

**Yapılan Değişiklikler (adapte ettiyseniz):**
> []

---

# Prompt 3: [Interaction Detector/Interaction]

**Araç:** [Gemini]
**Tarih/Saat:** 2026-01-30 13:30

**Prompt:**
```
[İkisi arasındaki fark nedir kısaca anlat]
```

**Alınan Cevap (Özet):**
```
[Interaction Detector (Göz/Beyin): Oyuncunun neye baktığını bulan mekanizmadır./Sadece P_Player (Oyuncu) üzerindedir./Raycast ile "Interactable" objeleri arar./Sürekli çalışır (Her karede etrafı tarar).
Interaction (Eylem/Sonuç): Nesneyle kurulan iletişimin kendisidir./Door, Chest veya Light gibi nesnelerin içindedir./"E"ye basıldığında ne olacağını (kapı açılması vb.) belirler./Sadece sen tuşa bastığında bir kez çalışır.]
```

**Nasıl Kullandım:**
- [x] Direkt kullandım
- [ ] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> [İki kritik noktada takıldığım konulardı.İlk başta kafam karıştığı için ayırt edemedim.Sonrasında Interecation ve Interactor detector arasındaki farkı sorarak kafamda oturmuş oldu.]

---

# Prompt 4: [Interaction Detector Kodları]

**Araç:** [Gemini]
**Tarih/Saat:** 2026-01-30 14:30

**Prompt:**
```
[Sırada hangi kodları nasıl yazmalıyım her satırını tek tek açıkla]
```

**Alınan Cevap (Özet):**
```
[

using UnityEngine;
using InteractionSystem.Runtime.Core; // IInteractable arayüzünü kullanmak için

namespace InteractionSystem.Runtime.Interactions
{
    public class Door : MonoBehaviour, IInteractable
    {
        [Header("Door Settings")]
        [SerializeField] private bool m_IsOpen = false;         // Kapı açık mı kapalı mı?
        [SerializeField] private float m_OpenAngle = 90f;       // Açılınca kaç derece dönsün?


        // Oyuncu 'E'ye bastığında burası çalışır
        public void OnInteract()
        {
            m_IsOpen = !m_IsOpen;          // Kapı açıksa kapat, kapalıysa aç
            
           
            float targetAngle = m_IsOpen ? m_OpenAngle : 75f;                 // Kapıyı kendi ekseninde (Y ekseninde) döndür
            
            transform.localEulerAngles = new Vector3(0, targetAngle, 0);

            Debug.Log(m_IsOpen ? "Kapı açıldı!" : "Kapı kapandı!");         //kapı hareketi yazısı
        }
        
        //Interface istediği diğer zorunlu kısımlar
        public bool CanInteract() => true;
        public string GetInteractionPrompt() => m_IsOpen ? "Kapat (E)" : "Aç (E)";   // E tuşuna bastığında açma kapama işlemi yapar 
        public void OnInteractionStart() { }
        public void OnInteractionEnd() { }

    }
}]
```

**Nasıl Kullandım:**
- [x] Direkt kullandım
- [ ] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> [Açıkçası bu alanda çok yeniyim ve aşırı temeldeyim C# dilini daha yeni öğreniyorum.BTK Akademi'den eğitim alıyorum.Henüz çok başındayım eğitimim bitmedi.
Gemini sorduğumda farkettim ki bu yapıların hiçbirini kullanmaya başlamadım.Bu yüzden AI bana açıklama yaparak kod yazmasını istedim.En çok sorun yaşadığım kısımlar kodlardı sanırım.
Sürekli bir hatayla karşılaşıp durdum.Elimden geleni yapmaya çalıştım.Yukarıdaki kodları da tek seferde AI vermedi her sorun yaşadığım satırda düzelterek nedenini yazdı.]

---

# Prompt 5: [IInteractable]

**Araç:** [Gemini]
**Tarih/Saat:** 2026-01-30 14:30

**Prompt:**
```
[Sırada hangi kodları nasıl yazmalıyım her satırını tek tek açıkla]
```

**Alınan Cevap (Özet):**
```
[

using UnityEngine;

namespace InteractionSystem.Runtime.Core // Kodun adresini belirler. Diğer kodlar bu klasöre "InteractionSystem.Runtime.Core" diyerek ulaşır.

{
    public interface IInteractable   // "IInteractable" adında bir arayüz tanımlar. Başındaki 'I' harfi, bunun bir Interface olduğunu belirtir.
    {
    {
        void OnInteract();              // Etkileşim anını temsil eder. "E"ye basıldığında ne olacağını buraya yazarız.
        void OnInteractionStart();      // Işın nesneye ilk çarptığında çalışır. Örneğin nesneyi parlatmak için kullanılabilir.
        void OnInteractionEnd();        // Işın nesneden ayrıldığında çalışır. Parlamayı kapatmak için kullanılabilir.
        string GetInteractionPrompt();  // Ekranda görünecek yazıyı döndürür. (Örn: "Kapıyı açmak için E'ye bas")
        bool CanInteract();             // Nesneyle o an etkileşime girilip girilemeyeceğini kontrol eder. (Örn: Kapı kilitliyse 'false' döndürür)
    }
}
]

```

**Nasıl Kullandım:**
- [x] Direkt kullandım
- [ ] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> [Açıkçası bu alanda çok yeniyim ve aşırı temeldeyim C# dilini daha yeni öğreniyorum.BTK Akademi'den eğitim alıyorum.Henüz çok başındayım eğitimim bitmedi.
Gemini sorduğumda farkettim ki bu yapıların hiçbirini kullanmaya başlamadım.Bu yüzden AI bana açıklama yaparak kod yazmasını istedim.En çok sorun yaşadığım kısımlar kodlardı sanırım.
Sürekli bir hatayla karşılaşıp durdum.Elimden geleni yapmaya çalıştım.Yukarıdaki kodları da tek seferde AI vermedi her sorun yaşadığım satırda düzelterek nedenini yazdı.]

---

# Prompt 5: [Door Kodu]

**Araç:** [Gemini]
**Tarih/Saat:** 2026-01-30 14:30

**Prompt:**
```
[Sırada hangi kodları nasıl yazmalıyım her satırını tek tek açıkla]
```

**Alınan Cevap (Özet):**
```
[

using UnityEngine;
using InteractionSystem.Runtime.Core; // IInteractable arayüzünü kullanmak için

namespace InteractionSystem.Runtime.Interactions
{
    public class Door : MonoBehaviour, IInteractable
    {
        [Header("Door Settings")]
        [SerializeField] private bool m_IsOpen = false;         // Kapı açık mı kapalı mı?
        [SerializeField] private float m_OpenAngle = 90f;       // Açılınca kaç derece dönsün?


        // Oyuncu 'E'ye bastığında burası çalışır
        public void OnInteract()
        {
            m_IsOpen = !m_IsOpen;          // Kapı açıksa kapat, kapalıysa aç
            
           
            float targetAngle = m_IsOpen ? m_OpenAngle : 75f;                 // Kapıyı kendi ekseninde (Y ekseninde) döndür
            transform.localEulerAngles = new Vector3(0, targetAngle, 0);

            Debug.Log(m_IsOpen ? "Kapı açıldı!" : "Kapı kapandı!");         //kapı hareketi yazısı
        }
        
        // Arayüzün (Interface) istediği diğer zorunlu kısımlar
        public bool CanInteract() => true;
        public string GetInteractionPrompt() => m_IsOpen ? "Kapat (E)" : "Aç (E)";
        public void OnInteractionStart() { }
        public void OnInteractionEnd() { }

    }
}

]

```

**Nasıl Kullandım:**
- [x] Direkt kullandım
- [ ] Adapte ettim
- [ ] Reddettim

**Açıklama:**
> [Açıkçası bu alanda çok yeniyim ve aşırı temeldeyim C# dilini daha yeni öğreniyorum.BTK Akademi'den eğitim alıyorum.Henüz çok başındayım eğitimim bitmedi.
Gemini sorduğumda farkettim ki bu yapıların hiçbirini kullanmaya başlamadım.Bu yüzden AI bana açıklama yaparak kod yazmasını istedim.En çok sorun yaşadığım kısımlar kodlardı sanırım.
Sürekli bir hatayla karşılaşıp durdum.Elimden geleni yapmaya çalıştım.Yukarıdaki kodları da tek seferde AI vermedi her sorun yaşadığım satırda düzelterek nedenini yazdı.]

---



