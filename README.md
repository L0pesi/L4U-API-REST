<a name="readme-top"></a>

<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Issues][issues-shield]][issues-url]
[![License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]



<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://github.com/L0pesi/L4U-API-REST">
    <img src="images/HatchfulExport-All/logo_transparent.png" alt="Logo" width="180" height="180">
  </a>

  <h3 align="center">L4U - Lockers for You</h3>

  <p align="center">
    Trabalho Prático 2 de ISI - Grupo 16 - LESI-IPCA
    <br />
    <br />
    Sérgio Lopes - 8390
    <br />
    Diogo Rocha - 18855
    <br />
    Sérgio Ribeiro - 18858
    <br />
    <br />
    <a href="https://github.com/L0pesi/L4U-API-REST"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/L0pesi/L4U-API-REST">View Demo</a>
    ·
    <a href="https://github.com/L0pesi/L4U-API-REST/issues">Report Bug</a>
    ·
    <a href="https://github.com/L0pesi/L4U-API-REST/issues">Request Feature</a>
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

<br />
<div align="center">
  <a href="https://github.com/L0pesi/L4U-API-REST">
    <img src="images/HatchfulExport-All/twitter_header_photo_2.png" alt="Logo">
  </a>
  </div>
  <br />

O L4U é um serviço de entrega de encomendas através de cacifos temporários providenciando uma alternativa à recepção na própria residência.
Pretendemos desenvolver uma API que registre informação dos utilizadores que necessitam do serviço, das encomendas e da gestão geral do serviço.

What our API will do:
* Your time should be focused on creating something amazing. A project that solves a problem and helps others
* You shouldn't be doing the same tasks over and over like creating a README from scratch
* You should implement DRY principles to the rest of your life :smile:



<p align="right">(<a href="#readme-top">back to top</a>)</p>



### Built With

This section should list any major frameworks/libraries used to bootstrap your project. Leave any add-ons/plugins for the acknowledgements section. Here are a few examples.

* ![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white)
* ![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
* ![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
* ![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Sever-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)
* ![Postman](https://img.shields.io/badge/Postman-FF6C37?style=for-the-badge&logo=postman&logoColor=white)
* ![Swagger](https://img.shields.io/badge/-Swagger-%23Clojure?style=for-the-badge&logo=swagger&logoColor=white)
* ![Jest](https://img.shields.io/badge/-jest-%23C21325?style=for-the-badge&logo=jest&logoColor=white)
* ![Azure](https://img.shields.io/badge/azure-%230072C6.svg?style=for-the-badge&logo=microsoftazure&logoColor=white)
* ![Google Drive](https://img.shields.io/badge/Google%20Drive-4285F4?style=for-the-badge&logo=googledrive&logoColor=white)
* ![Discord](https://img.shields.io/badge/Discord-%235865F2.svg?style=for-the-badge&logo=discord&logoColor=white)
* ![GitHub](https://img.shields.io/badge/github-%23121011.svg?style=for-the-badge&logo=github&logoColor=white)

Vamos Usar neste trabalho a Arquictetura de .Net 3 Tier. 
Desta Forma, 
Three-layer architecture is dividing the project into three layers that are User interface layer, business layer and data(database) layer where we separate UI, logic, and data in three divisions. Suppose the user wants to change the UI from windows to the phone than he has to only make change in UI layer, other layers are not affected by this change. Similarly, if the user wants to change the database then he has to only make a change in the data layer, rest everything remains the same.


https://www.geeksforgeeks.org/what-is-net-3-tier-architecture/

<!--
* [![Next][Next.js]][Next-url]
* [![React][React.js]][React-url]
* [![Vue][Vue.js]][Vue-url]
* [![Angular][Angular.io]][Angular-url]
* [![Svelte][Svelte.dev]][Svelte-url]
* [![Laravel][Laravel.com]][Laravel-url]
* [![Bootstrap][Bootstrap.com]][Bootstrap-url]
* [![JQuery][JQuery.com]][JQuery-url]
-->


<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- GETTING STARTED -->
## Getting Started

This are the instructions on setting up the project locally.
To get a local copy up and running follow these simple example steps.

### Prerequisites

This is an example of how to list things you need to use the software and how to install them.
* npm
  ```sh
  npm install npm@latest -g
  ```

### Installation

_Below is an example of how you can instruct your audience on installing and setting up your app._

1. Get a free API Key at [https://example.com](https://example.com)
2. Clone the repo
   ```sh
   git clone https://github.com/your_username_/Project-Name.git
   ```
3. Install NPM packages
   ```sh
   npm install
   ```
4. Enter your API in `config.js`
   ```js
   const API_KEY = 'ENTER YOUR API';
   ```

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->
## Usage

Use this space to show useful examples of how a project can be used. Additional screenshots, code examples and demos work well in this space. You may also link to more resources.


[<img src="https://www.ctt.pt/contentAsset/raw-data/e5f516be-5216-4c07-bfb7-ef844cf0580f/imagemBanner/50b931f4-0745-4f5c-bea8-58257b2913be" width="50%">](https://www.youtube.com/watch?v=T24ynh05xKs&t=70s "Now in Android: 55")


_For more examples, please refer to the [Documentation](https://example.com)_

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- ROADMAP -->
## Roadmap

- [x] Build a README.md
- [ ] Add a documentation API
- [ ] Add "components" document to easily copy & paste sections of the readme
- [ ] Multi-language Support
    - [ ] Portuguese

See the [open issues](https://github.com/L0pesi/L4U-API-REST/issues) for a full list of proposed features (and known issues).

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- LICENSE -->
## License

Distributed under the IPCA License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

Our Team
<br />
<br />
[![github][github]][github-sergio]  <b>  Sérgio Lopes  </b>  [![gmail][gmail]][gmail-sergio]
<br />
[![github][github]][github-diogo]  <b>  Diogo Rocha  </b>  [![gmail][gmail]][gmail-diogo]
<br />
[![github][github]][github-yuno]  <b>  Sérgio Ribeiro  </b>  [![gmail][gmail]][gmail-yuno]
<br />
<br />


<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- ACKNOWLEDGMENTS -->
## Acknowledgments

Use this space to list resources you find helpful and would like to give credit to. I've included a few of my favorites to kick things off!

* [Free Logo Maker - Hatchful](https://www.shopify.com/tools/logo-maker)
* [Markdown Badges](https://ileriayo.github.io/markdown-badges/)
* [Img Shields](https://shields.io)
* [Dall-E 2](https://openai.com/dall-e-2/)


<!--
* [Choose an Open Source License](https://choosealicense.com)
* [GitHub Emoji Cheat Sheet](https://www.webpagefx.com/tools/emoji-cheat-sheet)
* [Malven's Flexbox Cheatsheet](https://flexbox.malven.co/)
* [Malven's Grid Cheatsheet](https://grid.malven.co/)
* [Img Shields](https://shields.io)
* [GitHub Pages](https://pages.github.com)
* [Font Awesome](https://fontawesome.com)
* [React Icons](https://react-icons.github.io/react-icons/search)
-->

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/L0pesi/L4U?style=for-the-badge
[contributors-url]: https://github.com/L0pesi/L4U-API-REST/graphs/contributors
[github]: https://img.shields.io/badge/github-%23121011.svg?style=flat&logo=github&logoColor=white
[github-sergio]: https://github.com/L0pesi/
[github-diogo]: https://github.com/diogorocha1999/
[github-yuno]: https://github.com/sergio0140/
[gmail]: https://img.shields.io/badge/Gmail-D14836?style=plastic&logo=gmail&logoColor=white
[gmail-sergio]: sergiomaciel21@gmail.com
[gmail-diogo]: diogocorreia1999@gmail.com
[gmail-yuno]: serginhoribeiro1@gmail.com
[forks-shield]: https://img.shields.io/github/languages/code-size/L0pesi/L4U-API-REST?style=for-the-badge
[forks-url]: https://github.com/L0pesi/L4U-API-REST/
[stars-shield]: https://img.shields.io/github/stars/othneildrew/Best-README-Template.svg?style=for-the-badge
[stars-url]: https://github.com/L0pesi/L4U-API-REST/stargazers
[issues-shield]: https://img.shields.io/github/issues/L0pesi/L4U?style=for-the-badge
[issues-url]: https://github.com/L0pesi/L4U-API-REST/issues
[license-shield]: https://img.shields.io/badge/License-IPCA-brightgreen?style=for-the-badge
[license-url]: https://github.com/L0pesi/L4U-API-REST/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/L4U-API-REST
[product-screenshot]: images/screenshot.png
[Next.js]: https://img.shields.io/badge/next.js-000000?style=for-the-badge&logo=nextdotjs&logoColor=white
[Next-url]: https://nextjs.org/
[React.js]: https://img.shields.io/badge/React-20232A?style=for-the-badge&logo=react&logoColor=61DAFB
[React-url]: https://reactjs.org/
[Vue.js]: https://img.shields.io/badge/Vue.js-35495E?style=for-the-badge&logo=vuedotjs&logoColor=4FC08D
[Vue-url]: https://vuejs.org/
[Angular.io]: https://img.shields.io/badge/Angular-DD0031?style=for-the-badge&logo=angular&logoColor=white
[Angular-url]: https://angular.io/
[Svelte.dev]: https://img.shields.io/badge/Svelte-4A4A55?style=for-the-badge&logo=svelte&logoColor=FF3E00
[Svelte-url]: https://svelte.dev/
[Laravel.com]: https://img.shields.io/badge/Laravel-FF2D20?style=for-the-badge&logo=laravel&logoColor=white
[Laravel-url]: https://laravel.com
[Bootstrap.com]: https://img.shields.io/badge/Bootstrap-563D7C?style=for-the-badge&logo=bootstrap&logoColor=white
[Bootstrap-url]: https://getbootstrap.com
[JQuery.com]: https://img.shields.io/badge/jQuery-0769AD?style=for-the-badge&logo=jquery&logoColor=white
[JQuery-url]: https://jquery.com 
