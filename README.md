# MyShooterGame

Juego shooet 3d en donde podremos manejar un personaje first person controller
el cual puede disparar, recargar y recoger municiones y atacar a zombies que estarán dentro de un
mapa 3d, el cual contiene distintos elementos y renderizados 3d los cuales servirán como punto
de enganche para que el personaje escape de los zombies a puntos elevados, que por cierto, los zombies
persigen al jugador.

Contamos con scripts para:

- El movimiento del personaje
- Movimiento de los zombies enemigos, los zombies siguen al jugador
- Los zombies tienen movimiento aleatorio hasta que el jugador entre en el rango para la persecución
- Generación y detección de raycast
- Generación de objetos 3d con instantiate
- Generación de daño por parte de los enemigos
- Contabilidad de puntos (suma y resta)
- Generación de enemigos mediante spawner
- Puntos para dispensar puntos de vida
- Puntos para dispensar balas
- Guardar y cargar los puntajes, nombre de jugador y fecha en un json y mostrar los best scores
- Menú de pausa que congela totalmente el tiempo
- Cambio y navegación entre escenas
