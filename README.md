# Jump Adventure (Unity 2D)

## Descripción del Juego
Jump Adventure es un videojuego 2D de plataformas desarrollado en Unity 2022.3.62f1 (LTS).

El jugador controla a un personaje que debe saltar entre plataformas, evitar peligros, recolectar monedas y llegar a la meta para completar el nivel.
El proyecto incluye sistemas reales de producción: gestión de victoria/derrota, pausa automática, UI funcional y un GameManager centralizado.

Es ideal para aprender conceptos de Unity como física 2D, colisiones, animación, triggers, gestión de escenas y lógica con C#.

---

## Características Principales
* Movimiento fluido del jugador (caminar + salto).
* Monedas recolectables con sonido.
* Meta con sistema de “Nivel Completado”.
* Zona de caída que activa Game Over.
* Sistemas centralizados en GameManager:
*   * Pantalla de Game Over
    * Pantalla de Victoria
    * Control de pausa con Time.timeScale
* Sonidos de salto y recolección.
* Sprites simples para escenarios y objetos.
* UI integrada (Canvas, Panels, Buttons).

---

## Tecnologías Utilizadas
* Unity 2022.3.62f1 (LTS)
* C#
* Canvas UI
* Sprites PNG
* Audio Clips (.wav / .mp3)

---

## Objetivo del Juego
Recolecta monedas y llega a la bandera/portal final.
Si el jugador cae fuera del escenario, se activa la pantalla de Game Over.
Si llega a la meta, se activa la pantalla de Victoria o se carga el siguiente nivel.

---

##  Controles del Jugador

| Acción               |           Tecla          |
|----------------------|--------------------------|
| Mover a la izquierda | Flecha izquierda o **A** |
| Mover a la derecha   | Flecha derecha o **D**   |
| Saltar               | Flecha arriba o **W**    |
| Atacar               | Tecla de espacio         |
| Escudo               | Flecha arriba o **R**    |

---

## Estructura del Proyecto

- JumpAdventure/
- ├── Assets/
- │   ├── Scripts/
- │   │   ├── PlayerController.cs
- │   │   ├── Coin.cs
- │   │   ├── ExitGoal.cs
- │   │   ├── GameManager.cs
- │   │   └── DeathZone.cs
- │   ├── Sprites/
- │   │   ├── Player.png
- │   │   ├── Coin.png
- │   │   ├── Flag.png
- │   │   └── Background.png
- │   ├── Audio/
- │   │   ├── Jump.wav
- │   │   └── Coin.wav
- │   ├── UI/
- │   │   ├── Canvas.prefab
- │   │   ├── VictoryUI.prefab
- │   │   └── GameOverUI.prefab
- │   └── Scenes/
- │       └── Level1.unity
- ├── ProjectSettings/
- └── README.md

---

## Conceptos Aprendidos

* Rigidbody2D y colisiones 2D
* Triggers para detección de meta
* Uso de Canvas, Panels y Buttons
* Scripts modulares y patrón Singleton
* Gestión de escenas con SceneManager
* Control del flujo del juego (victoria/derrota)
* Manejo de Time.timeScale para pausar el juego

---

## Cómo Ejecutar el Proyecto
1. Abre **Unity Hub** y selecciona **Add project from disk**.  
2. Busca la carpeta del proyecto `JumpAdventure/`.
3. Abre la escena **Level1.unity**.
4. Presiona ▶️ **Play** para probar el juego.
5. (Opcional) Exporta el juego como build para **Windows** o **WebGL**.

