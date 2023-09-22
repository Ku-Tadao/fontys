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

### Use Cases
<details><summary>Assignment</summary>

The next step in developing the application is to create Use Cases based on the requirements. A Use Case describes "who" can do "what" with the system in question. Use Cases consist of a scenario description. The relationship between the Actors and their Use Cases can be represented in a Use Case diagram. Note that such a diagram is worthless without the descriptions.

  </details>

### Context Diagram
<details><summary>Assignment</summary>

A software application always runs in a certain context: A number of external systems and actors with which the application interacts. These include users, external APIs and other hardware or software. 

To give a first idea of what the software might look like, you can make a context diagram for this purpose. Here you consider your application as a black-box and start looking at what other things the application interacts with. 


If you have this context, then such a diagram can be used as input for requirements or user stories, and gives, for example, an overview of the actors of the system. In design, a context diagram can also be used as a basis for the software architecture.

Additional information
The C4 model provides an explanation of the Context diagramLinks to an external site.

  </details>

<div align="center">
<img src="/SEM2/The individual project/Docs/Context Diagram/V3 Context Diagram.jpg" alt="Context Diagram">
</div>




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

