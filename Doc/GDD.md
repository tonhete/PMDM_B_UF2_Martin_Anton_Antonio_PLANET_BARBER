# <PLANET BARBER>

## GAME DESIGN DOCUMENT

Creado por: < ANTONIO MARTIN ANTON >

Versión del documento: < 0.1 >

## HISTORIAL DE REVISIONES

| Versión | Fecha | Comentarios |
| --- | --- | --- |
| 1.00 | < 03/05/2024 > | 03/05/2024 |




## RESUMEN

### Concepto
Un soldado atrapado en una serie de planetas hostiles debe sobrevivir a oleadas de esferas enemigas mientras busca un monolito para avanzar al siguiente planeta. Cada nuevo planeta presenta desafíos mayores con enemigos más rápidos y numerosos, en un entorno que se expande y se vuelve más peligroso.


### Puntos Clave

Supervivencia Dinámica: El juego combina elementos de acción con un enfoque en la supervivencia contra enemigos que incrementan en velocidad y número.
Progresión Escalable: Cada nuevo planeta ofrece un mayor desafío, aumentando tanto en tamaño como en dificultad para encontrar el monolito.
Capacidad de Ataque: El personaje puede disparar a las esferas enemigas, permitiendo estrategias ofensivas y defensivas.
Ambientes Generativos(En proceso)
Los planetas y sus características seran generados aleatoriamente, ofreciendo una experiencia única en cada partida y aumentando la intensidad de la partida cuando grandes grupos de enemigos se acumulan.
### Género
Acción con elementos de shooter y supervivencia.
### Público Objetivo
Dirigido a jugadores de ambos sexos, principalmente entre 15 y 35 años, que disfruten de juegos desafiantes y dinámicos. Los jugadores interesados en títulos como "Enter the Gungeon", que mezclan acción con elementos roguelike, encontrarán este juego atractivo.
### Experiencia de Juego

El jugador se sumerge en un entorno hostil donde el sonido de las esferas enemigas acercándose crea una atmósfera tensa. Visualmente, los planetas varían en colores y terrenos(en desarollo), mientras que el diseño de los enemigos es simple pero amenazante. Durante el juego, el jugador experimentará una mezcla de tensión por la supervivencia y satisfacción al eliminar enemigos y encontrar el monolito. La jugabilidad es rápida y requiere tanto reflejos rápidos para avanzar de un planeta a otro.

## DISEÑO

### Metas de Diseño

Inmersión Total: Crear un ambiente que sumerja al jugador en cada planeta hostil a través de gráficos detallados, efectos de sonido inmersivos y una banda sonora que se adapte al nivel de amenaza.
Desafío Progresivo: Asegurar que cada nuevo planeta ofrezca un desafío mayor, manteniendo al jugador comprometido y probando sus habilidades de manera continua. Esto se logrará aumentando la velocidad y número de enemigos y expandiendo el tamaño del mapa.
Jugabilidad Rejugable: Fomentar que los jugadores quieran volver a jugar mediante niveles generados procedimentalmente. Cada partida será única, ofreciendo nuevos desafíos y configuraciones de enemigos.

## MECÁNICAS DE JUEGO

### Núcleo de Juego

Supervivencia: Los jugadores deben evitar ser abrumados por enemigos mientras buscan el monolito para escapar del planeta.
Navegación: los jugadores deben explorar para encontrar el monolito que se genera de forma aleatoria en cada planeta.
Combate: Los jugadores pueden disparar a las esferas enemigas. Los enemigos varían en velocidad y número, y los jugadores deben usar tanto estrategias ofensivas como defensivas.

### Flujo de Juego

Inicio: El jugador comienza en un planeta pequeño.
Exploración: El jugador explora el planeta, evadiendo o combatiendo esferas enemigas.
Descubrimiento: El jugador encuentra el monolito después de sobrevivir un tiempo determinado.
Transición: Una vez que el jugador activa el monolito, se transporta al siguiente planeta.
Repetición: El ciclo se repite con aumentos en la dificultad.

### Fin de Juego

Derrota: El jugador pierde si pierde las 3 vidas al ser alcanzado por los enemigos.
Victoria: Al ser fases generadas procedimentalmente no esta prevista una fase final.
Abandono: El jugador puede optar por salir del juego en cualquier momento, lo cual guarda su progreso hasta el último planeta completado.

### Física de Juego

Movimiento: Los jugadores pueden moverse en todas direcciones utilizando una vista cenital del planeta. La gravedad afecta mínimamente, permitiendo un movimiento fluido y constante.
Rotación y Disparo: La rotación del personaje se controla con el ratón, lo que permite apuntar en cualquier dirección mientras se mueve de forma independiente. El disparo también se controla con el ratón, lo que implica una mecánica de apuntado precisa.

### Controles

| Acción            | Teclado   | Ratón               |
|-------------------|-----------|---------------------|
| Moverse           | WASD      | N/A                 |
| Rotar/Apuntar     | N/A       | Movimiento del ratón|
| Disparar          | N/A       | Botón izquierdo     |
| Salir             | Esc       | N/A                 |
| Pausa             | p         | N/A                 |

## MUNDO DEL JUEGO

### Descripción General

Descripción General
El mundo del juego se ambienta en una serie de planetas alienígenas, cada uno con características únicas, pero unidos por un tema oscuro y espacial. La apariencia es una mezcla de terrenos rocosos y formaciones irregulares, con una paleta de colores fríos predominantes que incluyen azules, grises y negros. El ambiente es hostil y solitario, lo que refuerza la sensación de aislamiento y desafío. El jugador debe navegar por este entorno en busca de un monolito que permite la transición a nuevos planetas cada vez más desafiantes.

### Personajes

Jugables:

El Soldado: El único personaje jugable, vestido con un traje espacial avanzado que permite la supervivencia en ambientes hostiles. Equipado con un arma para defenderse de las amenazas alienígenas. Ágil y capaz de disparar en todas direcciones.
Enemigos:

Esferas Enemigas: Criaturas alienígenas que parecen esferas con texturas que brillan en colores fríos. Son los principales adversarios del juego y varían en velocidad y agresividad. Su única misión es perseguir y destruir al jugador.

### Objetos

Objetos
Monolito: El objeto clave en cada nivel. Aparece de manera aleatoria en el planeta y es necesario encontrarlo para avanzar al siguiente mundo. Su apariencia es de una estructura alta, oscura y con símbolos alienígenas lumínicos.

### Flujo de Pantallas

Pantalla de Inicio: Menú principal con opciones de iniciar juego, configuración y salir.
Pantalla de Juego: La vista principal del juego donde el jugador navega por el planeta.
Pantalla de Pausa: Accesible durante el juego con opciones para continuar o salir.
Pantalla de Fin de Juego: Muestra resultados y permite reiniciar o regresar al menú principal.

### HUD
El HUD muestra información esencial para el jugador:

Número de Vidas: En la esquina superior izquierda, indica cuántas vidas quedan.
Nivel Actual: En el centro superior, muestra el nivel en que se encuentra el jugador.
Puntuación Actual (Score): En la esquina superior derecha, refleja los puntos acumulados.
Puntuación Máxima (Max Score): Al centro en la parte inferior, muestra la puntuación más alta alcanzada.



## ARTE

### Metas de Arte

El objetivo del arte en el juego es crear un ambiente espacial futurista y misterioso que realmente sumerja al jugador. Se busca un equilibrio entre lo atractivo visualmente y lo funcional, con un estilo que mezcla lo realista y lo fantástico.

Estilo de Arte: Se utilizan texturas realistas con iluminación dramática, empleando colores fríos y oscuros para dar un toque sombrío, pero se destacan elementos clave como enemigos y objetos importantes con colores vivos para captar la atención.
Concepto Visual: Se quiere que el jugador se sienta pequeño y vulnerable en un gran universo, pero también poderoso al enfrentar desafíos. Los escenarios son grandes y abiertos, con un cielo estrellado que añade belleza al entorno peligroso.
Escenarios: Se presentan terrenos áridos y rocosos con estructuras alienígenas antiguas como el monolito, que añaden un toque de misterio.
Personajes: El 'player' luce equipado con tecnología avanzada, mientras que los enemigos, las esferas, tienen un look alienígena con texturas que brillan, mostrando una mezcla de lo orgánico y lo tecnológico.

### Assets de Arte

> *Indica, en forma de lista ordenada, todas las imágenes y animaciones incluidas en el juego. Agrupa los assets por contenido relacionado. Por ejemplo, un personaje puede contener animaciones de salto, reposo, ataque, etc*

## AUDIO

### Metas de Audio

> *Explica el enfoque musical y sonoro del juego. Indica el objetivo general del audio dentro del juego y cómo se piensa alcanzarlo. También se debe describir, por separado, el concepto general de la música y los efectos de sonido del juego, incluyendo el silencio, en caso de haber un uso intencional de él*

### Assets de Audio

> *Indica, en forma de lista ordenada, todos los audios incluidos en el juego. Se debe agrupar los assets en dos grupos, Música y Sonidos. En el grupo Sonidos, internamente se debe agrupar en base al contenido en el cual es usado. Por ejemplo, un personaje puede contener sonidos de salto, golpe, muerte, etc*

## DETALLES TÉCNICOS

### Plataformas Objetivo

> *Indica las plataformas en las cuales sería publicado el juego. También se debe agregar cualquier especificación técnica que deba tener la plataforma para la normal ejecución del videojuego*

### Herramientas de Desarrollo

> *Indica todas las herramientas de desarrollo utilizadas para la creación del juego. Incluye el motor del juego y sus complementos, los programas usados en el arte y la música y cualquier otro programa usado durante su desarrollo*
