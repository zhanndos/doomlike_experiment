
## Экспериментальное применение SOLID паттернов при разработке простого 3D-шутера.

## 🏗️ Архитектура

### SOLID принципы в коде

**Single Responsibility**
- `RayShooter` — только стрельба лучом
- `EnemyMover` — только движение врага
- `EnemyShooter` — только AI врага

**Open/Closed**
- Интерфейсы для расширяемости без изменения существующего кода

**Liskov Substitution**
- `IHittable`, `IDamageable`, `IKillable` позволяют подменять реализации

**Interface Segregation**
- Мелкие, специализированные интерфейсы вместо больших монолитных

**Dependency Inversion**
- `RayShooter` зависит от `IHittable`, не от конкретной реализации

### Событийная система (Observer Pattern)

```
SettingsPopup ─────┐
                   │
EnemyMover ◄────── Messenger ◄────── UIController
                   │
                   └─ RayShooter
```

Слабая связь через `Messenger`:
- `ENEMY_HIT` — сигнал о попадании по врагу
- `SPEED_CHANGED` — изменение скорости

### Структура классов

```
Core/
├── IDamageable      → TakeDamage(damage)
├── IHittable        → ReactToHit()
├── IKillable        → Die()
├── IEnemy           → SetAlive(bool)
├── IEnemySpawner    → Spawn()
└── GameEvent        → констаты событий

Player/
├── PlayerCharacter  : IDamageable
├── RayShooter       : MonoBehaviour
├── CrosshairView    : MonoBehaviour
└── HitIndicator     : MonoBehaviour

Enemy/
├── EnemyMover       : IEnemy, IKillable
├── EnemyShooter     : MonoBehaviour
├── FireBall         : MonoBehaviour
└── EnemySpawner     : IEnemySpawner

UI/
├── UIController     : MonoBehaviour (Observer)
└── SettingsPopup    : MonoBehaviour (Broadcaster)
```

## 📝 Заметки о коде

- **Messenger.cs** — реализация типобезопасного event bus'а
- Враги реагируют на `SPEED_CHANGED` через подписку в `OnEnable`/`OnDisable`
- Система попаданий использует Interface Segregation: `IHittable` отделен от `IDamageable`

## 🔄 Данные потоки

```
Input (Mouse Click)
    ↓
RayShooter.Raycast → IHittable.ReactToHit()
    ↓
Messenger.ENEMY_HIT
    ↓
UIController.OnEnemyHit() → Score++
```

---

*Educational project exploring SOLID principles in game development*
