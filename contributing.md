# Unity2dRogueLike
Repositorio juego unity2d Roguelike 


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


  <h3 align="center">Unity2DRogueLike</h3>

  <p align="center">
    Proyecto autodidacta de aprendizaje en unity2D
    <br />
    <a href="https://github.com/github_username/repo_name"><strong>Explore the docs »</strong></a>
    <br />
    <br />
  </p>
</p>





<!-- Sobre el proyecto -->
## Sobre el proyecto

Inicio este proyecto personal de aprendizaje en Unity, con objetivo de trabajar todo el ciclo de desarrollo de principio a fin de un videojuego.
El genero a explorar es el roguelike, en la experiencia mas pequeña posible, pero poder practicar y diseñar mecanicas de este genero de forma práctica.


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


<!-- BoardManager.cs -->
### BoardManager.cs
Genera el mapa que sirve de fondo para el juego.
Genera el tablero de de ese nivel, ajustando la dificultad de forma dinámica, segun las acciones del jugador en el nivel actual( cuantos intentos realiza, cuantos monstruos ha matado, el poder de ataque)
Los parametros que se modifican para la dificultad son: parejas para ganar, intentos fallidos para recibir daño, cartas de cada tipo que aparecen.


<!-- Enemy.cs -->
### Enemy.cs
Representación grafica en la vista de mazmorra, del enemigo invocado por las cartas.
Activa una animación que representa la muerte del enemigo encontrado.


<!-- GameManager.cs -->
### GameManager.cs
Gestiona la comunicación entre los distintos sistemas del juego(interfaz y controles, boardManager, jugador, vista de mazmorra, generación de niveles, ).
Inicializa el nivel, comprueba las parejas descubiertas.
Activa la opción de avanzar al siguiente nivel.


<!-- HealthManager.cs -->
### HealthManager.cs

<!-- MenuScript.cs -->
### MenuScript.cs

<!-- Player.cs -->
### Player.cs

<!-- SoundManager.cs -->
### SoundManager.cs

<!-- TimeScript.cs -->
### TimeScript.cs

<!-- Utilities.cs -->
### Utilities.cs


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
