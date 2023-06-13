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

In this project, the aim is to develop a replica of the popular social media platform Reddit. The platform will enable users to create secure accounts, login, and engage in various activities. Users will be able to create posts with text and/or media content, browse a feed of posts from all users or specific subreddits, upvote or downvote posts and comments, comment on posts and reply to other comments, as well as edit or delete their own posts and comments. To ensure data integrity, a relational database will be used to store user data, posts, comments, and other relevant information.

To gather and document the project requirements, a variety of methods have been employed, including stakeholder interviews, documentation study, reverse engineering, prototyping, and focus groups. The requirements have been prioritized using the MoSCoW method and categorized as Functional Requirements (FR), Constraints (B), and Quality Requirements (K).

Throughout the development process, industry best practices for software development will be followed. Standard techniques and tools for software quality assurance will be implemented to ensure the reliability and usability of the platform. Regular testing will be conducted to identify and address any bugs, enhancing the overall quality of the software. The ultimate goal is to deliver a platform that meets the needs of the stakeholders, providing a dependable and user-friendly experience.

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



### Use Cases
<details><summary>Assignment</summary>

The next step in developing the application is to create Use Cases based on the requirements. A Use Case describes "who" can do "what" with the system in question. Use Cases consist of a scenario description. The relationship between the Actors and their Use Cases can be represented in a Use Case diagram. Note that such a diagram is worthless without the descriptions.

  </details>

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

The EERD represents a database with four entities: `Comment`, `Post`, `Subreddit`, and `User`.

Entities and Attributes
- The `Comment` entity has the following attributes: `Id`, `DateCreated`, and `Content`.
- The `Post` entity has the following attributes: `Id`, `Title`, `Content`, and `DateCreated`.
- The `Subreddit` entity has the following attributes: `Id`, `Description`, and `Name`.
- The `User` entity has the following attributes: `Id`, `Email`, `Username`, and `Password`.

Relationships
- There is a many-to-one relationship between the `Comment` and `Post` entities, represented by a hollow diamond labeled "On".
- There is a many-to-one relationship between the `Comment` and `User` entities, represented by a hollow diamond labeled "Writes".
- There is a many-to-one relationship between the `Post` and `Subreddit` entities, represented by a hollow diamond labeled "In".
- There is a many-to-one relationship between the `Post` and `User` entities, represented by a hollow diamond labeled "Creates".

<div align="center">
<img src="/SEM2/The individual project/Docs/Conceptual model/V2 EER.jpg" alt="Conceptual Model">
</div>


### UI Sketches
<details><summary>Assignment</summary>
A UI sketch can help gather requirements. By thinking about what the site looks like, you also force yourself to consider what functionality must be present to make that happen. Note that an outline should be mostly sketchy; that sounds obvious, but make sure it doesn't contain too much detail. It certainly shouldn't look too detailed either.

  </details>

<div align="center">
<img src="/SEM2/The individual project/Docs/UI sketches/WireFrame Reddit Comment.png" alt="WireFrame Reddit Comment">
<img src="/SEM2/The individual project/Docs/UI sketches/WireFrame Reddit Homepage.png" alt="WireFrame Reddit Homepage">
<img src="/SEM2/The individual project/Docs/UI sketches/WireFrame Reddit Profile.png" alt="WireFrame Reddit Profile">
</div>


### Test Plan + Test Matrix
<details><summary>Assignment</summary>
Based on the requirements, you can often already come up with a number of scenarios that your application must meet. Both the 'happy flow', where you go through the steps as it should be, but also the error situations. For both of these scenarios you can invent a test to verify that your software works as intended. You can document these tests in a test plan and demonstrate that you cover your requirements with a test matrix.

  </details>

The Test Plan outlines the specific steps taken to verify each requirement of the application. It includes the actions, inputs, and the expected outcomes for each of my test cases. In essence, the Test Plan guides the testing process and helps ensure that each requirement is tested appropriately.
| Test Case | Use Case(s) | Input | Expected Output |
| --- | --- | --- | --- |
| TC01 | FR-02 | Action: “Create post”, Title: “Test post”, Content: “This is a test post” | Post created with title “Test post” and content “This is a test post” |
| TC02 | FR-03 | Action: “View feed”, Filter: “All users” | Feed displayed with posts from all users |
| TC03 | FR-06 | Action: “Edit post”, Post ID: 1, New content: “Updated content” | Post with ID 1 updated with new content |
| TC04 | FR-07 | Action: “Query database”, Query: “SELECT * FROM posts” | Query executed and results returned |
| TC05 | FR-08 | Action: “Run tests” | Tests executed and results reported |


Given that only the requirements FR-02, FR-03, FR-06, FR-07, and FR-08 are being tested, the Test Matrix looks like this:
| Test Case	| FR-02	| B-02.1	| K-02.1	| FR-03	| B-03.1	| K-03.1 | FR-06 | B-06.1 | K-06.1 | FR-07 | B-07.1 | K-07.1 | FR-08 | B-08.1 | K-08.1 |
| ---		|---	| ---		| ---		| ---	| ---		| ---		| ---	| ---	| ---		| ---	| ---		| ---		| ---	| ---		| ---		|
| TC01		| X	| X		| X		| 
| TC02		|  	|  		|  		| X	| X		| X
| TC03		|  	|  		|  		|   	|  		|   	| X	| X		| X
| TC04		|  	|  		|  		|   	|  		|   	|   	|  		|   		| X	| X		| X
| TC05		|  	|  		|  		|   	|  		|   	|   	|  		|   		|   	|  		|   	| X	| X		| X


The Test Plan and Test Matrix together form a comprehensive approach to validating the functionality and quality of my Reddit replica application.


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

This is a work in progress, i'm currently working on a Solution that has the Business, Data and Presentation layer, with the Domain model within the core of the application.
(Image still requires designing) 
<a href="/SEM2/The individual project/Reddit">Review the Solution</a>
Access the <a href="/SEM2/The individual project/Reddit/RedditProject">RedditProject</a> to open the Solution in Visual Studio (or your prefered IDE)

### Domain models, class diagrams and database design
<details><summary>Assignment</summary>
A class diagram shows the overview of the classes in a system, as well as the relationships between them. For each class, the name as well as the attributes and methods are displayed. These diagrams are used to model the static structure of your software.

By creating class diagrams, you are able to discuss and validate your design with your colleagues before you even begin programming. These diagrams are the standard way to define the design of your system.

Eventually, you will also start storing things in a database (this is one of the learning outcomes). Try to think, based on your domain model, what tables you are going to need and what the relationships are between them. Your DBMS (DataBase Mangement System) will enforce these relationships if you put keys (primary and foreign keys) on the right fields. There are also technical limitations on the data types you can store in your DBMS. These are also reflected in your Database design.

  </details>

<details><summary>Class Diagram Legend</summary>

1.Arrow with a hollow diamond (Aggregation): Represents a "has a" relationship. It signifies that one class is a part of another class. For example, the UserService has a IUserRepository. The diamond points towards the "whole" or "parent" class.
  
2. Arrow with a solid line (Association): It represents a relationship between two classes, but there is no ownership. For example, a Post is associated with a User, but they do not necessarily own each other.
  
3. Arrow with a dashed line (Dependency): It signifies that one class depends on another. This dependency could be a method parameter, local variable, or an operation call return.
  
4. Arrow with a dashed line and closed, filled arrowhead (Implements): It represents a class that implements an interface.
  
5. Arrow with a solid line and open arrowhead (Inheritance/Extension): It signifies that a class is inherited from another class or an interface.
  
6. Numbers (Cardinality): They show the number of instances of one class linked to one instance of the other class. For example, '1' means exactly one instance and '0..*' means zero to many instances.

  </details>
 
Class Diagram:
1. **User, Post, Subreddit (Entities)**: These classes represent the core business objects in the system. A user can create many posts and each post belongs to one subreddit.

2. **UserRepository, PostRepository, SubredditRepository (DataLayer)**: These classes are the implementations of their respective interfaces and are responsible for managing the interaction between the application and the database. They handle all CRUD operations for the respective entities.

3. **IUserRepository, IPostRepository, ISubredditRepository (BusinessLayer)**: These are the interfaces that the repository classes implement. They define the common methods that the repository classes must have.

4. **UserService, PostService, SubredditService (BusinessLayer)**: These classes use the repositories to perform operations on the entities and manage the business logic of the application. They also make sure that any business rules or invariants are upheld.

5. **Relations**:
    - The UserRepository, PostRepository, and SubredditRepository classes implement IUserRepository, IPostRepository, and ISubredditRepository interfaces, respectively.
    - The UserService, PostService, and SubredditService classes depend on IUserRepository, IPostRepository, and ISubredditRepository interfaces, respectively. This relationship is represented by a line with a hollow diamond at the interface end.
    - There is a one-to-many relationship from User to Post and from Subreddit to Post, indicated by "1" at User and Subreddit ends, and "0..*" at Post end. This implies that one User/Subreddit can have zero or many Posts.

6. **Packages**: The classes and interfaces are grouped into two packages: RedditBusinessLayer and RedditDataLayer. RedditBusinessLayer contains the entities, interfaces and services while RedditDataLayer contains the concrete implementations of the interfaces. This structure indicates a clear separation of concerns within the architecture of the application. 
<div align="center">
<img src="/SEM2/The individual project/Docs/Class Diagram/Class Diagram.png" alt="Class Diagram">
</div>

Entity Relationship Diagram:

The `reddit` database consists of four entities: `Comments`, `Posts`, `Subreddits`, and `Users`.

Entities and Attributes
- The `Comments` entity has the following attributes: `Id`, `Content`, `DateCreated`, `UserId`, and `PostId`.
- The `Posts` entity has the following attributes: `Id`, `Title`, `Content`, `DateCreated`, `UserId`, and `SubredditId`.
- The `Subreddits` entity has the following attributes: `Id`, `Name`, and `Description`.
- The `Users` entity has the following attributes: `Id`, `Username`, `Password`, and `Email`.

Relationships
- There is a relationship between the `Comments` and `Posts` entities, representing the foreign key constraint on the `PostId` column in the `Comments` table.
- There is a relationship between the `Comments` and `Users` entities, representing the foreign key constraint on the `UserId` column in the `Comments` table.
- There is a relationship between the `Posts` and `Subreddits` entities, representing the foreign key constraint on the `SubredditId` column in the `Posts` table.
- There is a relationship between the `Posts` and `Users` entities, representing the foreign key constraint on the `UserId` column in the `Posts` table.
<div align="center">
<img src="/SEM2/The individual project/Docs/Conceptual model/ERD1.png" alt="Entity Relationship Diagram">
</div>


## Testing
**Unittest (automatic) and Acceptance testing are not ready yet**
