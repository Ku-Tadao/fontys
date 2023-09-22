# Reading Guide

## Table of Contents
- [Reading Guide](#reading-guide)
  - [Analysis](#analysis)
    - [Requirements](#requirements)
    - [Use Cases](#use-cases)
    - [Context Diagram](#context-diagram)
    - [Conceptual Model](#conceptual-model)
    - [UI Sketches](#ui-sketches)
    - [Test Plan + Test Matrix](#test-plan--test-matrix)
  - [Design](#design)
    - [Architecture: Multilayered Architecture](#architecture-multilayered-architecture)
    - [Domain models, class diagrams and database design](#domain-models-class-diagrams-and-database-design)
  - [Testing](#testing)
  - [Algorithmics](#Algorithmics)
    - [Visitor Placement Tool for Events](#visitor-placement-tool-for-events)
    - [Circustrain-challenge](#circustrain)

## Analysis

### Requirements
<details><summary>Assignment</summary>
Whether you are doing a small project on your own, or a large multidisciplinary project for a large company; everything depends on good requirements. Therefore, it is important to have an overview of what the application should do.

Therefore, in consultation with the client (as in the pro task) or on your own (as in your individual project), you will create a list of functionalities and prioritize them. 

N.B. Also look back at your one-slide idea and project description. If all goes well, you have described there what the goal of your project is. This is the good starting point for thinking and drafting your requirements.

Requirements often have 3 elements:
- Requirement: The behavior the system must exhibit.
- Constraints (on a requirement): Further tightening of the observable behavior of the system (think restrictions on input, things that are or are not allowed)
- Quality requirements (on a requirement): General requirements for the system, usually not a tightening of the behavior, but the way the behavior manifests itself (think sorting a view can be descending and ascending).

</details>

This project aims to create a Digital Game Library, similar to platforms like Steam. The main goal of the application is to provide a platform for users to manage and access their digital game collection efficiently.

The primary users of this application will be gamers who have a vast collection of digital games and want an organized system to manage them. This application will resemble platforms like Steam, Epic Games Store, and GOG but will have its unique features tailored to the needs of our target users.

The application will allow users to add games to their library, categorize them, track their playtime, and even provide recommendations based on their gaming preferences. It will also have social features allowing users to connect with friends, see what they are playing, and join multiplayer games with them.

**Functional Requirements (FR)**:
- FR-01: The platform allows users to create an account and login securely. (Must have)
  - B-01.1: User authentication and authorization are implemented according to industry best practices to ensure the security of user data.
  - K-01.1: The platform must prevent unauthorized access to user data.
- FR-02: Users can add games to their library. (Must have)
  - B-02.1: The platform supports the addition of games by users.
  - K-02.1: Games must be displayed in a clear and organized manner.
- FR-03: Users can categorize their games. (Should have)
  - B-03.1: The platform implements efficient algorithms to sort and filter games based on user preferences and game categories.
  - K-03.1: The platform must provide a responsive and user-friendly interface for categorizing games.
- FR-04: Users can track their playtime. (Should have)
  - B-04.1: The platform implements a fair and transparent tracking system that prevents abuse and ensures the integrity of user-generated content.
  - K-04.1: The tracking system must be easy to use and understand.
- FR-05: Users can receive game recommendations based on their preferences. (Should have)
  - B-05.1: The platform supports a recommendation system that takes into account user preferences and gaming history.
  - K-05.1: Recommendations must be accurate and relevant.
- FR-06: Users can connect with friends, see what they are playing, and join multiplayer games with them. (Could have)
  - B-06.1: The platform implements appropriate access controls to ensure that users can only connect with friends who have approved them.
  - K-06.1: The social features must be easy to use and intuitive.
- FR-07: Users can edit their account details. (Should have)
  - B-07.1: The platform implements appropriate access controls to ensure that users can only modify their own account details.
  - K-07.1: The platform must provide a user-friendly interface for editing account details.


**Constraints (B)**:
- B-07: Users cannot add a game to their library without owning it.
- B-08: Users cannot connect with friends without their approval.
- B-09: Users cannot edit the details of a game in their library.
- B-10: Users cannot see the gaming activity of a friend who has not approved them.

**Quality Requirements (K)**:
- K-07: The system should display the game library in an organized manner.
- K-08: The system should provide accurate game recommendations.
- K-09: The system should provide fast and reliable access to data.
- K-10: The system should be reliable and free of critical bugs.

### Use Cases
<details><summary>Assignment</summary>

The next step in developing the application is to create Use Cases based on the requirements. A Use Case describes "who" can do "what" with the system in question. Use Cases consist of a scenario description. The relationship between the Actors and their Use Cases can be represented in a Use Case diagram. Note that such a diagram is worthless without the descriptions.

  </details>
  
Field | Description
--- | ---
Name | UC01: Add games to library
Summary | - A user can add games to their library.<br>- The platform supports the addition of games by users.
Actors | User
Assumptions | The user is logged in and owns the game they want to add.
Scenario | - The actor logs into their account and navigates to the game they want to add.<br>- The actor clicks on the “Add to Library” button located below the game.<br>- The actor is redirected to a confirmation page where they can confirm their action.<br>- Once confirmed, the actor clicks on the “Confirm” button to add the game to their library.
Exceptions | - The entered game is invalid or does not exist.<br>- The user does not own the game they are trying to add.
Result | A new game has been added to the user's library and is visible in their game collection.

Field | Description
--- | ---
Name | UC02: Categorize games
Summary | - A user can categorize games in their library.<br>- The platform supports the categorization of games by users.
Actors | User
Assumptions | The user is logged in and has games in their library.
Scenario | - The actor logs into their account and navigates to the game they want to categorize.<br>- The actor clicks on the “Categorize” button located below the game.<br>- The actor is redirected to a categorization page where they can select a category for their game.<br>- Once a category is selected, the actor clicks on the “Confirm” button to categorize the game.
Exceptions | - The selected category is invalid or does not exist.<br>- The user does not have the game they are trying to categorize in their library.
Result | A game has been categorized and is visible under the selected category in the user's library.

Field | Description
--- | ---
Name | UC03: Connect with friends
Summary | - Users can connect with friends, see what they are playing, and join multiplayer games with them.<br>- The platform supports social features that allow users to connect with friends.
Actors | User
Assumptions | The user is logged in and has friends who also use the platform.
Scenario | - The actor logs into their account and navigates to their friends list.<br>- The actor clicks on a friend's profile to see what they are playing.<br>- If a friend is playing a multiplayer game, the actor can click on the “Join Game” button to join them.<br>- If a friend is not currently playing a multiplayer game, the actor can send them an invitation to play together.
Exceptions | - The friend does not approve of the connection.<br>- The friend is not currently playing a multiplayer game.
Result | A connection has been made with a friend and/or a multiplayer game has been joined.


### Context Diagram
<details><summary>Assignment</summary>

A software application always runs in a certain context: A number of external systems and actors with which the application interacts. These include users, external APIs and other hardware or software. 

To give a first idea of what the software might look like, you can make a context diagram for this purpose. Here you consider your application as a black-box and start looking at what other things the application interacts with. 


If you have this context, then such a diagram can be used as input for requirements or user stories, and gives, for example, an overview of the actors of the system. In design, a context diagram can also be used as a basis for the software architecture.

Additional information
The C4 model provides an explanation of the Context diagramLinks to an external site.

  </details>

### Conceptual Model
<details><summary>Assignment</summary>

In addition to an outline of the context, it also makes sense to create conceptual models early in the project to provide structure to the application domain. It serves as a talking picture with the customer and does not contain technical details, but uses "the language of the customer. Therefore, in it you do not yet make technical decisions such as "what type does each attribute have", "how do I then store this in the database" and "what behavior of the system comes in which entity".

Therefore, the conceptual model contains only entities, relationships and the most important attributes for the applicaite.

In the SQL dictation (Chapter 2) Download SQL dictation (Chapter 2)there is information about setting up a conceptual model.
Once you have set up a Context diagram and a Conceptual model, you have a nice analysis of the outside world and the customer domain and can get to work translating these requirements into a technical solution.

  </details>

### UI Sketches
<details><summary>Assignment</summary>
A UI sketch can help gather requirements. By thinking about what the site looks like, you also force yourself to consider what functionality must be present to make that happen. Note that an outline should be mostly sketchy; that sounds obvious, but make sure it doesn't contain too much detail. It certainly shouldn't look too detailed either.

  </details>

### Test Plan + Test Matrix
<details><summary>Assignment</summary>
Based on the requirements, you can often already come up with a number of scenarios that your application must meet. Both the 'happy flow', where you go through the steps as it should be, but also the error situations. For both of these scenarios you can invent a test to verify that your software works as intended. You can document these tests in a test plan and demonstrate that you cover your requirements with a test matrix.

  </details>

## Design

### Architecture: Multilayered Architecture
<details><summary>Assignment</summary>
The architecture of a software system provides an abstract description, often presented through an architecture diagram, of the logical components and their relationships within the application. It plays a crucial role in defining the main responsibilities of the application and influencing the organization of the codebase.

The choice of architecture is often driven by the specific requirements of the application. Factors such as scalability, deployment ease, development speed, testability, and performance heavily influence the architectural decisions. Each of these considerations impacts the overall design.

One example of a commonly used architecture is the multilayer architecture, also known as layered or N-tier architecture. It involves dividing the application into distinct components or layers, each responsible for specific functions, including:

1. Presentation (View/UI): Handles the interaction between users and the application.
2. Application (Logic/Business): Implements the core behavior and functionality of the application.
3. Persistence (DAL - Data Access Layer): Manages the connection between the application and the chosen data storage method.
4. Domain (Model): Represents the data containers used by the application.
5. ApiWrapper: Facilitates the integration between the application and external APIs.
6. Hardware Abstraction Layer (HAL): Establishes the communication between the application and external hardware.

When designing the architecture, you determine the necessary components and define their connections. The analysis, particularly the contextual understanding of the project, serves as valuable input in this decision-making process. In your design document, you should provide an explanation justifying the chosen architecture based on its suitability for the project's requirements.

  </details>


### Domain models, class diagrams and database design
<details><summary>Assignment</summary>
A class diagram shows the overview of the classes in a system, as well as the relationships between them. For each class, the name as well as the attributes and methods are displayed. These diagrams are used to model the static structure of your software.

By creating class diagrams, you are able to discuss and validate your design with your colleagues before you even begin programming. These diagrams are the standard way to define the design of your system.

Eventually, you will also start storing things in a database (this is one of the learning outcomes). Try to think, based on your domain model, what tables you are going to need and what the relationships are between them. Your DBMS (DataBase Mangement System) will enforce these relationships if you put keys (primary and foreign keys) on the right fields. There are also technical limitations on the data types you can store in your DBMS. These are also reflected in your Database design.

  </details>

### Algorithmics
<details><summary>Assignment Visitor Placement Tool</summary>
For event organizers, a tool must be created that assigns a spot to each visitor. Along the course, which is different each time, boxes are created containing rows of chairs; there is variation in the shape and arrangement of the boxes. There are also quite a few requirements about the visitors.

Download an overview of the requirements for this assignment Download an overview of the requirements for this assignment.

When building a solution, it is important that you work on the following things:

The structure of the different classes in the domain (for example, by creating a class diagram);
The order in which a user will go through the different steps (for example, by working out scenarios);
The operation of the classification algorithm (for example, by working out a flow chart);
Using SOLID principles when setting up the code;
Testing parts of the logic using unit tests.

  </details>

<details><summary>Circustrain</summary>
Fewer and fewer animals are allowed to perform in circuses. Director Hans of circus Cirque du Goodbye is therefore forced to sell his animals. He is going to transport the animals by train to give them a good home elsewhere. However, the rent for the wagons is very high. Hans is not sure how to get all the animals on the train without paying too much for the rent.

We are going to give Hans a hand. Create a program that allows different kinds of animals to be added. Each animal eats meat or plants and is small, medium or large in size. After entering all the animals, the program must be able to make a distribution of wagons. The distribution must meet the following requirements:

An animal that likes meat will eat other animals that are of the same or smaller size. So make sure this does not occur.
Each small animal counts for 1 point. Medium-sized animals count are 3 and large animals are 5 points. Each train wagon can carry a maximum of 10 points.
Each wagon must be optimally utilized. So it is not allowed to place each animal in a separate wagon.
Assignment
Create a program that can enter animals and give a distribution of wagons based on the above description. The program must meet the specified requirements. Also make unit tests that show that your algorithm does not violate any of the requirements.

  </details>
  
[Circustrain](https://github.com/Ku-Tadao/fontys/tree/main/SEM2/The%20individual%20project/Circustrain-challenge)
