# Interaction System - [Tuğçe Pınarbaş]

> Ludu Arts Unity Developer Intern Case

## Proje Bilgileri

| Bilgi | Değer |
|-------|-------|
| Unity Versiyonu | 6000.0.52f1 |
| Render Pipeline | Built-in |
| Case Süresi | 12 saat |
| Tamamlanma Oranı | %XX | (Herhangi bir yüzdelik oran veremedim)

------------------------------------------------------------------------------------------------------------------------------------------------------------------

## Kurulum

1. Repository'yi klonlayın:
```bash
git clone https://github.com/tugcepinarbas/LuduArts_InteractionSystem_tugcepinarbas

```

2. Unity Hub'da projeyi açın
3. `Assets/LuduArts_InteractionSystem_tugcepinarbas/Scenes/TestScene.unity` sahnesini açın
4. Play tuşuna basın

------------------------------------------------------------------------------------------------------------------------------------------------------------------

## Nasıl Test Edilir

### Kontroller

| Tuş | Aksiyon |
|-----|---------|
| WASD | Hareket |
| Mouse | Bakış yönü |
| E | Etkileşim |


### Test Senaryoları

1. **Door Test:**
   - Kapıya yaklaşın, "Press E to Open" mesajını görün
   - E'ye basın, kapı açılsın
   - Tekrar basın, kapı kapansın

2. **Key + Locked Door Test:**
   - Kilitli kapıya yaklaşın, "Locked - Key Required" mesajını görün
   - Anahtarı bulun ve toplayın
   - Kilitli kapıya geri dönün, şimdi açılabilir olmalı

3. **Switch Test:**
   - Switch'e yaklaşın ve aktive edin
   - Bağlı nesnenin (kapı/ışık vb.) tetiklendiğini görün

4. **Chest Test:**
   - Sandığa yaklaşın
   - E'ye basılı tutun, progress bar dolsun
   - Sandık açılsın ve içindeki item alınsın

------------------------------------------------------------------------------------------------------------------------------------------------------------------

## Mimari Kararlar

### Interaction System Yapısı

```
[Mimari diyagram veya açıklama]
```

**Neden bu yapıyı seçtim:**
> [Açıklama]

**Alternatifler:**
> [Düşündüğünüz diğer yaklaşımlar ve neden seçmediniz]

**Trade-off'lar:**
> [Bu yaklaşımın avantaj ve dezavantajları]

### Kullanılan Design Patterns

| Pattern | Kullanım Yeri | Neden |
|---------|---------------|-------|
| [Observer] | [Event system] | [Açıklama] |
| [State] | [Door states] | [Açıklama] |
| [vb.] | | |

------------------------------------------------------------------------------------------------------------------------------------------------------------------

## Ludu Arts Standartlarına Uyum

### C# Coding Conventions

| Kural | Uygulandı | Notlar |
|-------|-----------|--------|
| m_ prefix (private fields) | [x] / [ ] | |
| s_ prefix (private static) | [ ] / [ ] | |
| k_ prefix (private const) | [ ] / [ ] | |
| Region kullanımı | [x] / [ ] | |
| Region sırası doğru | [x] / [ ] | |
| XML documentation | [x] / [ ] | |
| Silent bypass yok | [x] / [ ] | |
| Explicit interface impl. | [x] / [ ] | |

### Naming Convention

| Kural | Uygulandı | Örnekler |
|-------|-----------|----------|
| P_ prefix (Prefab) | [x] / [ ] | P_Door, P_Chest |
| M_ prefix (Material) | [x] / [ ] | M_Door_Wood |
| T_ prefix (Texture) | [ ] / [ ] | |
| SO isimlendirme | [ ] / [ ] | |

### Prefab Kuralları

| Kural | Uygulandı | Notlar |
|-------|-----------|--------|
| Transform (0,0,0) | [ ] / [ ] | |
| Pivot bottom-center | [ ] / [ ] | |
| Collider tercihi | [x] / [ ] | Box > Capsule > Mesh |
| Hierarchy yapısı | [x] / [ ] | |

### Zorlandığım Noktalar
> [Standartları uygularken zorlandığınız yerler]

------------------------------------------------------------------------------------------------------------------------------------------------------------------

## Tamamlanan Özellikler

### Zorunlu (Must Have)

- [x] / [ ] Core Interaction System
  - [x] / [ ] IInteractable interface
  - [x] / [ ] InteractionDetector
  - [x] / [ ] Range kontrolü

- [] / [ ] Interaction Types
  - [] / [ ] Instant
  - [] / [ ] Hold
  - [] / [ ] Toggle

- [] / [ ] Interactable Objects
  - [] / [ ] Door (locked/unlocked)
  - [] / [ ] Key Pickup
  - [] / [ ] Switch/Lever
  - [x] / [ ] Chest/Container

- [] / [ ] UI Feedback
  - [] / [ ] Interaction prompt
  - [] / [ ] Dynamic text
  - [] / [ ] Hold progress bar
  - [] / [ ] Cannot interact feedback

- [] / [ ] Simple Inventory
  - [] / [ ] Key toplama
  - [] / [ ] UI listesi

### Bonus (Nice to Have)

- [ ] Animation entegrasyonu
- [ ] Sound effects
- [ ] Multiple keys / color-coded
- [ ] Interaction highlight
- [ ] Save/Load states
- [ ] Chained interactions

------------------------------------------------------------------------------------------------------------------------------------------------------------------

## Bilinen Limitasyonlar

### Tamamlanamayan Özellikler
1. [Özellik] - [Neden tamamlanamadı]
2. [Özellik] - [Neden]

### Bilinen Bug'lar
1. [Bug açıklaması] - [Reproduce adımları]
2. [Bug]

### İyileştirme Önerileri
1. [Öneri] - [Nasıl daha iyi olabilirdi]
2. [Öneri]

------------------------------------------------------------------------------------------------------------------------------------------------------------------

## Ekstra Özellikler

Zorunlu gereksinimlerin dışında eklediklerim:

1. **[Özellik Adı]**
   - Açıklama: [Ne yapıyor]
   - Neden ekledim: [Motivasyon]

2. **[Özellik Adı]**
   - ...

------------------------------------------------------------------------------------------------------------------------------------------------------------------

## Dosya Yapısı

```
Assets/
├── [ProjectName]/ [ok]
│   ├── Scripts/    [ok]
│   │   ├── Runtime/     [ok]
│   │   │   ├── Core/    [ok]
│   │   │   │   ├── IInteractable.cs  [ok]
│   │   │   │   └── ...
│   │   │   ├── Interactables/  [ok]
│   │   │   │   ├── Door.cs   [ok]
│   │   │   │   └── ...
│   │   │   ├── Player/  [ok]
│   │   │   │   └── ...
│   │   │   └── UI/  [ok]
│   │   │       └── ...
│   │   └── Editor/  [ok]
│   ├── ScriptableObjects/ [ok]
│   ├── Prefabs/  [ok]
│   ├── Materials/  [ok]
│   └── Scenes/  [ok]
│       └── TestScene.unity  [ok]
├── Docs/ [ok]
│   ├── CSharp_Coding_Conventions.md  [ok]
│   ├── Naming_Convention_Kilavuzu.md [ok]
│   └── Prefab_Asset_Kurallari.md  [ok]
├── README.md [ok]
├── PROMPTS.md [ok]
└── .gitignore [ok]
```

------------------------------------------------------------------------------------------------------------------------------------------------------------------

## İletişim

| Bilgi | Değer |
|-------|-------|
| Ad Soyad | [Tuğçe Pınarbaş] |
| E-posta | [tugcepinarbas5@example.com] |
| LinkedIn | [https://www.linkedin.com/in/tugcepinarbas/] |
| GitHub | [github.com/tugcepinarbas] |

---

*Bu proje Ludu Arts Unity Developer Intern Case için hazırlanmıştır.*
