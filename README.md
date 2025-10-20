🕹️ Jump Adventure (Unity 2D)
🎮 Descripción del Juego

Jump Adventure es un videojuego 2D de plataformas desarrollado en Unity 2022.3.62f1.
El jugador controla a un personaje que debe saltar entre plataformas, evitar caer y recoger monedas hasta llegar al final del nivel, donde encontrará una bandera o portal de meta.

Es un proyecto educativo diseñado para practicar conceptos básicos de Unity, física 2D, animaciones, colisiones y lógica de juego mediante scripts en C#.

🚀 Características Principales

🎨 Escenario con fondo azul o imagen de cielo.

🧍‍♂️ Personaje jugable con movimiento horizontal y salto.

🪙 Monedas recolectables con sonido.

🚩 Bandera o portal al final del nivel que marca la victoria.

🔊 Sonidos de salto y recolección de monedas.

💻 Mecánicas simples ideales para principiantes.

⚙️ Tecnologías Utilizadas

Unity 2022.3.62f1 (LTS)

C# para la lógica del juego

Sprites PNG para el personaje y objetos

Audio Clips (.wav / .mp3) para efectos de sonido

🎯 Objetivo del Juego

Recoge todas las monedas y llega a la bandera final para completar el nivel.
¡Pero cuidado! Si caes fuera de las plataformas, pierdes y debes reiniciar el juego.

🕹️ Controles del Jugador
Acción	Tecla
Mover a la izquierda	⬅️ Flecha izquierda o A
Mover a la derecha	➡️ Flecha derecha o D
Saltar	⬆️ Flecha arriba o Espacio
📁 Estructura del Proyecto
JumpAdventure/
├── Assets/
│   ├── Scripts/
│   │   ├── PlayerController.cs
│   │   ├── Coin.cs
│   │   └── Goal.cs
│   ├── Sprites/
│   │   ├── Player.png
│   │   ├── Coin.png
│   │   ├── Flag.png
│   │   └── Background.png
│   ├── Audio/
│   │   ├── Jump.wav
│   │   └── Coin.wav
│   └── Scenes/
│       └── Level1.unity
├── ProjectSettings/
└── README.md

🧠 Conceptos Aprendidos

Uso del Rigidbody2D y Collider2D

Implementación de scripts C# en Unity

Manejo de inputs del teclado

Reproducción de efectos de sonido

Detección de colisiones y triggers

Organización básica de un proyecto Unity

🧩 Cómo Ejecutar el Proyecto

Abre Unity Hub y selecciona Add project from disk.

Busca la carpeta del proyecto JumpAdventure/.

Abre la escena Level1.unity.

Presiona ▶️ Play para probar el juego.

(Opcional) Exporta el juego como build para Windows o WebGL.
