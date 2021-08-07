#Super Dungeon Puzzle Crawler Ultimate Ex
Repositorio juego Super Dungeon Puzzle Crawler Ultimate Ex 


<!--
*** Thanks for checking out the Best-README-Template. If you have a suggestion
*** that would make this better, please fork the repo and create a pull request
*** or simply open an issue with the tag "enhancement".
*** Thanks again! Now go create something AMAZING! :D
***
***
***
*** To avoid retyping too much info. Do a search and replace for the following:
*** github_username, repo_name, twitter_handle, email, project_title, project_description
-->



<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->


<!-- PROJECT LOGO -->
<br />
<p align="center">


  <h3 align="center">Super Dungeon Puzzle Crawler Ultimate Ex</h3>

  <p align="center">
    Proyecto Super Dungeon Puzzle Crawler Ultimate Ex
    <br />
    <a href="https://github.com/github_username/repo_name"><strong>Explore the docs »</strong></a>
    <br />
    <br />
  </p>
</p>





<!-- Sobre el proyecto -->
## Sobre el proyecto

Proyecto para la Blackthornprod gamejam #3 con el tema "menos es más".

El juego tratará sobre un juego de cartas de encuentra las parejas, ambientado en un "dungeon crawler". Las parejas que vayas destapando, decidiran las acciones del jugador mientras avanza por la mazmorra: Cartas de monstruos: matas a un enemigo de la mazmorra, pero no siempre es buena idea. Cartas de mejora: curar al jugador, aumentar su poder de ataque. Cartas de desventaja: el jugador pierde vida o ataque.

Necesitas llegar al final de la mazmorra para derrotar al poderoso Liche, pero cuanto más tardes o mas monstruos mates, el Liche se volverá más poderoso. La dificultad del juego escala en cada nivel por las acciones en los niveles anteriores, en resumen cuando mejor seas jugando, evitarás mayores contratiempos.

<!-- Diagrama de sistemas -->
## Diagrama de sistemas
![image](https://user-images.githubusercontent.com/4136363/128594107-a8bbceba-f3c7-4c8e-ba19-fc7d9e743af3.png)

<!-- Diagrama de clases -->
## Diagrama de clases
Resumen de las funciones realizadas en el proyecto


<!-- CardScript.cs -->
### CardScript.cs
Clase abstracta que implemente la logica basica de las cartas del juego.
Asigna las imagenes de ambos lados de las cartas.
Girar la carta pausa y vuelta automatica al fallar hacer una pareja.
Cartas implementadas: goblin, orco, subir y bajar ataque, ganar o perder vida, filactereas de liche jefe final.
Las distintas implementaciones, tienen efectos de sonido, textos descriptivos e invocan animaciones en la pantalla de mazmorra.

![image](https://user-images.githubusercontent.com/4136363/112855381-07d4df80-90af-11eb-997a-0d20a27b1da8.png)


<!-- Player.cs -->
### Player.cs
Centraliza la info de vida y ataque del jugador y su representación.

![image](https://user-images.githubusercontent.com/4136363/112855432-11f6de00-90af-11eb-98f3-728e40dd87fb.png)


<!-- Enemy.cs -->
### Enemy.cs
Representación grafica en la vista de mazmorra, del enemigo invocado por las cartas.
Activa una animación que representa la muerte del enemigo encontrado.

![image](https://user-images.githubusercontent.com/4136363/112855628-48ccf400-90af-11eb-9556-f2339be2f353.png)


<!-- BoardManager.cs -->
### BoardManager.cs
Genera el mapa que sirve de fondo para el juego.
Genera el tablero de de ese nivel, ajustando la dificultad de forma dinámica, segun las acciones del jugador en el nivel actual( cuantos intentos realiza, cuantos monstruos ha matado, el poder de ataque)
Los parametros que se modifican para la dificultad son: parejas para ganar, intentos fallidos para recibir daño, cartas de cada tipo que aparecen.

![image](https://user-images.githubusercontent.com/4136363/112855741-639f6880-90af-11eb-81ff-d71b0bc02bc6.png)


<!-- GameManager.cs -->
### GameManager.cs
Gestiona la comunicación entre los distintos sistemas del juego(interfaz y controles, boardManager, jugador, vista de mazmorra, generación de niveles, ).
Inicializa el nivel, comprueba las parejas descubiertas.
Activa la opción de avanzar al siguiente nivel.

<!-- HealthManager.cs -->
### HealthManager.cs
Actualiza a nivel de UI la vida y el poder de ataque del jugador, recibiendo las acciones de las cartas activadas.

<!-- MenuScript.cs -->
### MenuScript.cs
Gestion de escena de menu y lanzar el juego.

<!-- SoundManager.cs -->
### SoundManager.cs
Clase para con los metodos necesarios para implementar sonidos y musica al juego.

<!-- TimeScript.cs -->
### TimeScript.cs
Contador de tiempo de partida.

![image](https://user-images.githubusercontent.com/4136363/112855790-731eb180-90af-11eb-8378-4dbd2ccc2b35.png)


<!-- Utilities.cs -->
### Utilities.cs
Libreria con varios metodos para facilitar el trabajo en el proyecto(busqueda por tag, busqueda de hijos,obtener enumerables de objetos de tipo generico,etc).



<!-- CONTACT -->
## Contact

Clovis - [@Clovisindo](https://twitter.com/clovisindo) 




<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/github_username/repo.svg?style=for-the-badge
[contributors-url]: https://github.com/github_username/repo/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/github_username/repo.svg?style=for-the-badge
[forks-url]: https://github.com/github_username/repo/network/members
[stars-shield]: https://img.shields.io/github/stars/github_username/repo.svg?style=for-the-badge
[stars-url]: https://github.com/github_username/repo/stargazers
[issues-shield]: https://img.shields.io/github/issues/github_username/repo.svg?style=for-the-badge
[issues-url]: https://github.com/github_username/repo/issues
[license-shield]: https://img.shields.io/github/license/github_username/repo.svg?style=for-the-badge
[license-url]: https://github.com/github_username/repo/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/github_username
