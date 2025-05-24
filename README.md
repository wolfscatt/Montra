# 📝 Montra - Oyun Sistemi Raporu

Bu proje, **Unity 2D** ortamında geliştirilmekte olan, **kart tabanlı, turn-based savaş oyunu** sistemini içerir.  
Oyuncular karakter seçip kartlarını (skillerini) oynayarak düşmanlara saldırır veya müttefiklerini iyileştirir.

---

## 🚀 Şu Ana Kadarki İlerleme

- **Temel savaş mekaniği kuruldu**: karakter seçimi, skill seçimi, hedef seçimi, saldırı/iyileştirme.
- **HealthBar sistemi** hazır ve her karakterde çalışıyor.
- **UI Skill Paneli** (kartlar) aktif: karakter seçilince skiller buton olarak listeleniyor.
- **Tıklama sistemi** çalışıyor: karakterlere tıklayarak seçim yapılabiliyor.

---

## 🏗️ Dosya ve Script Yapısı

### 🗂️ Scriptable Objects (Veri Katmanı)

- **BaseCharacterData.cs**  
  Soyut sınıf, tüm karakterlerin temel verilerini tutar:  
  `characterName`, `maxHP`, `attackPower`, `characterSprite`.

- **AllyData.cs**  
  BaseCharacterData’dan türeyen, **oyuncu karakteri özel verileri**:  
  `skills`, `characterClass`.

- **EnemyData.cs**  
  BaseCharacterData’dan türeyen, **düşman karakteri özel verileri**:  
  `skills`, `aiPattern`, `rewardGold`.

- **SkillData.cs**  
  Skill (kart) verilerini tutar:  
  `skillName`, `power`, `type (Attack, Heal, Buff, Debuff)`, `skillIcon`.

---

### 🗂️ Savaş Sistemi

- **IBattleCharacter.cs**  
  Tüm karakterlerin (Ally ve Enemy) uygulaması gereken arayüz.  
  Örn: `Name`, `CurrentHP`, `AttackPower`, `GetSkills()`, `IsEnemy()`.

- **BaseBattleCharacter.cs**  
  Soyut sınıf, temel karakter davranışları: HP yönetimi, saldırı/iyileştirme.        
  **Ally** ve **Enemy** bu sınıftan türetilir.

- **Ally.cs**  
  BaseBattleCharacter'den türeyen oyuncu karakteri. `IsEnemy() == false`. `GetSkills()` AllyData’dan döner.

- **Enemy.cs**  
  BaseBattleCharacter'den türeyen düşman karakteri. `IsEnemy() == true`. `GetSkills()` EnemyData’dan döner. (Şu an saldırı yapmıyor.)

---

### 🗂️ UI Yönetimi

- **HealthBar.cs**  
  Karakterlerin üstünde sağlık barı gösterir. DOTween ile animasyonlu.

- **UIManager.cs**  
  Skill butonlarını (kartları) listeler. Butonlara basıldığında TurnManager’a seçim iletir.


---

### 🗂️ Turn Yönetimi

- **TurnManager.cs**  
  Oyunun akışını kontrol eder.  
  - Karakter, skill, hedef seçimi ve saldırı/iyileştirme.  
  - Enemy turn basit AI (şimdilik saldırı yapmıyor).

- **TurnState Enum**  
  `PlayerSelect`, `ActionSelect`, `TargetSelect`, `ActionResolve`, `EnemyTurn` durumlarını belirler.

---

### 🗂️ Tıklama Algılama

- **CharacterClickHandler.cs**  
  Physics2D Raycast ile sahne üzerindeki karakterlere tıklamayı algılar.  
  Tıklama sonrası TurnManager’a bildirim yapar.

---

### 🗂️ Prefablar ve Sahne

- **AllyPrefab**  
  AllyData atanmış, BoxCollider2D ve HealthBar içerir.

- **EnemyPrefab**  
  EnemyData atanmış, BoxCollider2D ve HealthBar içerir.

- **Canvas**  
  UI içerikleri (Skill Panel) burada.

- **SkillPanel**  
  Seçilen karakterin skill butonlarının listelendiği panel.

- **TurnManager**  
  Savaş akışını yönetir (sahne objesi).

- **CharacterClickHandler**  
  Tıklama algılar (sahne objesi).

---

## 📌 Durum Özeti

✅ Oyuncu karakter seçip, skill (kart) seçip, düşmana saldırabiliyor.  
✅ Sağlık barları güncelleniyor, animasyonlu.  
✅ Skill seçim paneli çalışıyor.  
✅ Düşmanların AI ve skilleri henüz yok (eklenecek).  
✅ SOLID prensiplerine uygun, modüler bir yapı kuruldu.  

---

## 📚 Devam Edilecek Noktalar
- **Düşman AI ve skill kullanımı** geliştirilecek.  
- **Skill ikonları ve UI tasarımı** iyileştirilecek.  
- **Özel animasyonlar ve efektler** eklenecek.  
- **Gelişmiş turn sistemi (buff, debuff, durum efektleri)** hazırlanacak.

---

## 👾 Katkıda Bulunacak Kişilere Not
Projeye başlamadan önce bu README’yi inceleyin.  
Kod yapısı SOLID ve modüler tasarlandı, yeni özellikleri eklerken prensiplere dikkat edin.  

---

🎉 Projeye katkılarınız için teşekkürler!
