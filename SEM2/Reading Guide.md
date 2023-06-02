# Reading Guide

## Requirements Assignment
Of je nu een klein project in je eentje doet, of een groot multidisciplinair project voor een groot bedrijf; alles staat of valt bij goede requirements. Daarom is het van belang een overzicht te hebben wat de applicatie moet gaan doen.

Daarom ga je in overleg met de opdrachtgever (zoals in de proftaak) of op jezelf (zoals in je individuele project) een lijst van functionaliteiten opstellen en deze prioriteren. 

N.B. Kijk ook terug naar je one-slide idea en projectbeschrijving. Als het goed is heb je daar beschreven wat het doel is van je project. Dit is het goed startpunt voor het nadenken en opstellen van je requirements.

Requirements hebben vaak 3 elementen:
- Requirement: Het gedrag wat het systeem moet vertonen
- Beperkingen (op een requirement): Verdere verscherping van het observeerbare gedrag van het systeem (denk aan beperkingen aan invoer, zaken die wel of niet mogen)
- Kwaliteitseisen (op een requirement): Algemene eisen aan het systeem, meestal geen verscherping van het gedrag, maar de manier waarop het gedrag zich manifesteert (denk aan sorteren van een overzicht kan aflopend en oplopend).

### Reddit - Requirements
Look-Back at project description: In this project, I aim to create a replica of the popular social media platform Reddit. My platform will allow users to create an account and login securely, create new posts with text and/or media content, view a feed of posts from all users or from specific subreddits, upvote or downvote posts and comments, comment on posts and reply to other comments, edit or delete their own posts and comments, and connect to a relational database to store user data, posts, comments, and other relevant information.

We have gathered and documented requirements for My project using various methods, including interviews with stakeholders, studying documentation, reverse engineering, prototyping, and focus groups. We have prioritized My requirements using the MoSCoW method and have organized them according to the FR (Functional Requirement), B (Beperking), and K (Kwaliteitseis) categories.

My project will adhere to industry best practices for software development and will implement standard techniques and tools for software quality assurance. We will regularly test My software to identify and fix bugs and improve its overall quality. My goal is to deliver a reliable and user-friendly platform that meets the needs of My stakeholders.

FR = Functional Requirement
B = Beperking
K = Kwaliteitseis

- FR-01: The platform allows users to create an account and login securely. (Must have)
  - B-01.1: User authentication and authorization are implemented according to industry best practices to ensure the security of user data.
  - K-01.1: The platform must prevent unauthorized access to user data.
- FR-02: Users can create new posts with text and/or media content. (Must have)
  - B-02.1: The platform supports the creation and moderation of subreddits by users.
  - K-02.1: Posts must be displayed in a clear and organized manner.
- FR-03: Users can view a feed of posts from all users or from specific subreddits. (Must have)
  - B-03.1: The platform implements efficient algorithms to sort and filter posts based on user preferences and subreddit rules.
  - K-03.1: The platform must provide a responsive and user-friendly interface for browsing posts.
- FR-04: Users can upvote or downvote posts and comments. (Should have)
  - B-04.1: The platform implements a fair and transparent voting system that prevents abuse and ensures the integrity of user-generated content.
  - K-04.1: The voting system must be easy to use and understand.
- FR-05: Users can comment on posts and reply to other comments. (Should have)
  - B-05.1: The platform supports threaded discussions and allows users to easily navigate between different levels of comments.
  - K-05.1: Comments must be displayed in a clear and organized manner.
- FR-06: Users can edit or delete their own posts and comments. (Should have)
  - B-06.1: The platform implements appropriate access controls to ensure that users can only modify their own content.
  - K-06.1: The platform must provide a user-friendly interface for editing and deleting content.
- FR-07: The platform connects to a relational database to store user data, posts, comments, and other relevant information. (Must have)
  - B-07.1: The database is designed according to industry best practices to ensure data integrity and efficient querying.
  - K-07.1: The platform must provide fast and reliable access to data.
- FR-08: The platform implements standard techniques and tools for software quality assurance. (Could have)
  - B-08.1: The development team regularly tests the software to identify and fix bugs and improve its overall quality.
  - K-08.1: The software must be reliable and free of critical bugs.

## Use-cases Assignment
De volgende stap in het ontwikkelen van de applicatie is om op basis van de requirements Use Cases te maken. Een Use Case beschrijft “wie” met het betreffende systeem “wat” kan doen. Use Cases bestaan uit een scenariobeschrijving. De relatie tussen de Actoren en hun Use-Cases kunnen in een Use-Casediagram worden weergegeven. Let er op dat zo'n diagram waardeloos is zonder de beschrijvingen.

### Reddit Use Cases
Field | Description
--- | ---
Name | UC01: Create an account and login
Summary | - A user can create an account on the platform by providing their information and choosing a secure password.<br>- The platform implements user authentication and authorization according to industry best practices to ensure the security of user data.
Actors | User
Assumptions | None
Scenario | - The actor navigates to the platform’s homepage and clicks on the “Sign Up” button.<br>- The actor is redirected to a registration page where they are prompted to enter their personal information such as their name, email address, and date of birth.<br>- The actor chooses a unique username and a secure password that meets the platform’s password requirements.<br>- The actor clicks on the “Submit” button to create their account.<br>- The actor receives a confirmation email with a link to verify their email address.<br>- The actor clicks on the verification link to complete the registration process.<br>- The actor can now login securely using their username and password.
Exceptions | - Not all required information has been entered.<br>- The entered password does not meet the security requirements.<br>- The chosen username is already taken.
Result | A new account has been created and the user can login securely.

Field | Description
--- | ---
Name | UC02: Create a new post
Summary | - A user can create a new post with text and/or media content.<br>- The platform supports the creation and moderation of subreddits by users.
Actors | User
Assumptions | The user is logged in and has permission to create posts.
Scenario | - The actor logs into their account and navigates to the subreddit where they want to create a post.<br>- The actor clicks on the “Create Post” button located at the top of the subreddit page.<br>- The actor is redirected to a post creation page where they can enter the post title and content (text and/or media).<br>- The actor can format their post using the platform’s text editor and add media such as images or videos by uploading files or providing URLs.<br>- The actor can preview their post before publishing it by clicking on the “Preview” button.<br>- Once satisfied with their post, the actor clicks on the “Submit” button to publish it.
Exceptions | - The entered post title or content is invalid or does not meet subreddit rules.<br>- The user does not have permission to create posts in the selected subreddit.
Result | A new post has been created and is visible to other users.

Field | Description
--- | ---
Name | UC03: View a feed of posts
Summary | - A user can view a feed of posts from all users or from specific subreddits.<br>- The platform implements efficient algorithms to sort and filter posts based on user preferences and subreddit rules.
Actors | User
Assumptions | None
Scenario | - The actor navigates to the platform’s homepage or a specific subreddit page.<br>- By default, the actor sees a feed of posts sorted by “Hot”, which displays popular posts from all users or from the selected subreddit.<br>- The actor can change how posts are sorted by clicking on one of several sorting options such as “New”, “Top”, or “Controversial”.<br>- The actor can also filter posts by time range (e.g., past hour, past 24 hours, past week) using a drop-down menu.<br>- The actor can interact with posts by clicking on them to view their content, upvoting or downvoting them, commenting on them, or sharing them with others.<br>- The actor can also save posts for later viewing by clicking on the “Save” button located below each post.<br>- The actor can navigate between pages of posts using pagination controls located at the bottom of the feed.<br>- The actor can also search for specific posts using keywords or phrases by entering them into a search bar located at the top of the page.<br>- The search results are displayed in a separate feed that can be sorted and filtered using the same controls as described above.<br>- The actor can return to their original feed at any time by clearing their search query or navigating back to the homepage or subreddit page.
Exceptions | None
Result | The user can view a feed of posts from all users or from specific subreddits.

## Context Diagram
Een software applicatie draait altijd in een bepaalde context: Een aantal externe systemen en actoren waarmee de applicatie interacteert. Hierbij kun je onder andere denken aan gebruikers, externe API's en andere hardware of software. 

Om een eerste idee te geven hoe op hoofdlijnen de software eruit zou kunnen gaan zien, kun je hiervoor een contextdiagram maken. Hierbij beschouw je je applicatie als black-box en ga je bekijken met welke andere zaken de applicatie samenwerkt. 

![Context Diagram](SEM2/The individual project/Docs/Context Diagram/V2 Context Diagram.jpg)

Als je deze context hebt, dan is een dergelijk diagram in te zetten als input voor requirements of user stories, en geeft bijvoorbeeld een overzicht van de actoren van het systeem. In het ontwerp kan een contextdiagram ook gebruikt worden als basis voor de software architectuur.

Extra informatie
Het C4-model geeft een uitleg van het ContextdiagramLinks to an external site.

## Conceptual Model
Naast een schets van de context is ook zinvol om vroeg in het project conceptueel model te maken om structuur aan te brengen in het domein van de applicatie. Het dient als praatplaatje met de klant en bevat geen technische details, maar gebruikt 'de taal van de klant'. Daarom neem je hierin nog geen technische beslissingen als "welk type heeft elk attribuut", "hoe sla ik dit dan op in de database" en "welk gedrag van het systeem komt in welke entiteit".

Het conceptueel model bevat dan dus ook alleen entiteiten, relaties en de belangrijkste attributen voor de applicaite.

![Conceptual Model](SEM2/The individual project/Docs/Conceptual model/V2 EER.jpg)

In het SQL dictaat (hoofdstuk 2) Download SQL dictaat (hoofdstuk 2)is informatie te vinden over het opzetten van een conceptueel model.
Als je een Context-diagram en een Conceptueel-model hebt opgesteld, heb je een aardige analyse van de buitenwereld en het klantdomein en kun je aan de slag met het vertalen van deze eisen naar een technische oplossing.
