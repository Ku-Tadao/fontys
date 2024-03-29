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
Name | UC01: Comment on posts and reply to other comments
Summary | - A user can comment on posts and reply to other comments.<br>- The platform supports threaded discussions and allows users to easily navigate between different levels of comments.
Actors | User
Assumptions | None
Scenario | - The actor navigates to a post that they want to comment on.<br>- The actor clicks on the “Comment” button located below the post.<br>- The actor is redirected to a comment creation page where they can enter their comment text.<br>- The actor can format their comment using the platform’s text editor.<br>- The actor can preview their comment before publishing it by clicking on the “Preview” button.<br>- Once satisfied with their comment, the actor clicks on the “Submit” button to publish it.<br>- The actor can also reply to other comments by clicking on the “Reply” button located below each comment.<br>- The actor is redirected to a reply creation page where they can enter their reply text following the same steps as described above.
Exceptions | - The entered comment or reply text is invalid or does not meet subreddit rules.
Result | A new comment or reply has been created and is visible to other users.

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
| TC01 | UC01: Comment on posts and reply to other comments | Action: “Comment on post”<br>Post ID: 1<br>Comment text: “This is a test comment” | Comment with text “This is a test comment” created on post with ID 1 |
| TC02 | UC02: Create a new post | Action: “Create post”<br>Title: “Test post”<br>Content: “This is a test post” | Post created with title “Test post” and content “This is a test post” |
| TC03 | UC03: View a feed of posts | Action: “View feed”<br>Filter: “All users” | Feed displayed with posts from all users |

Given that only the requirements FR-02, FR-03, FR-06, FR-07, and FR-08 are being tested, the Test Matrix looks like this:
| Test Case	| UC01: Comment on posts and reply to other comments	| UC02: Create a new post	| UC03: View a feed of posts |
| ---		|---					| ---				| ---				|
| TC01		| X				|  				|  				|
| TC02		|  				| X				|  				|
| TC03		|  				|  				| X				|

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

In my project, I use a layered architecture to achieve separation of concerns. The architecture consists of four layers: Presentation Layer, Business Layer, Data Access Layer, and Database.

**The Presentation Layer** is the top layer of the architecture. It represents the user interface and the communication part of the software. In my project, I use ASP.NET Core Razor Pages to build dynamic web pages using C# and Razor syntax. This layer communicates with the Business Layer to retrieve and display data to the user.

**The Business Layer**, also known as the logic layer, contains the application’s core logic. It is where I define my business rules. In my project, this layer is structured as a group of Services (PostService, RedditService, SubredditService, UserService) that encapsulate the business logic and communicate with the Data Access Layer to retrieve and manipulate data. This layer communicates with both the Presentation Layer and the Data Access Layer.

**The Data Access Layer** contains the logic for the business layer to handle the CRUD operations against my database. In my project, this layer uses a Repository pattern to segregate these operations. It contains the repositories (PostRepository, SubredditRepository, UserRepository) that communicate directly with the Database using SQL queries. This layer should only be responsible for performing database operations and should not contain any business logic.
<div align="center">
<img src="/SEM2/The individual project/Docs/Architecture Multilayered Architecture/Multilayered Architecture.jpg" alt="Multilayered Architecture Diagram">
</div>

**The Database** is where the data is stored and retrieved from. In my project, it would be represented as a Microsoft SQL Server Database.

By separating the different concerns into different layers, I can avoid having one layer interact directly with another layer that it shouldn’t interact with. For example, the Presentation Layer should not interact directly with the Database because that would violate the separation of concerns and make it harder to maintain and test my code.


### Domain models, class diagrams and database design
<details><summary>Assignment</summary>
A class diagram shows the overview of the classes in a system, as well as the relationships between them. For each class, the name as well as the attributes and methods are displayed. These diagrams are used to model the static structure of your software.

By creating class diagrams, you are able to discuss and validate your design with your colleagues before you even begin programming. These diagrams are the standard way to define the design of your system.

Eventually, you will also start storing things in a database (this is one of the learning outcomes). Try to think, based on your domain model, what tables you are going to need and what the relationships are between them. Your DBMS (DataBase Mangement System) will enforce these relationships if you put keys (primary and foreign keys) on the right fields. There are also technical limitations on the data types you can store in your DBMS. These are also reflected in your Database design.

  </details>

<details><summary>Class Diagram Legend</summary>

1. **Association**: An association represents a relationship between two classes. It is represented by a line connecting the two classes. The cardinality of the relationship can be indicated by numbers or symbols next to the line. For example, “1” at one end and “0…*” at the other end indicates that one instance of the first class can be associated with zero or many instances of the second class.

2. **Composition**: A composition is a strong form of association where the lifetime of the part is dependent on the lifetime of the whole. It is represented by a line with a filled diamond at one end. The diamond end represents the whole, while the other end represents the part. The cardinality of the relationship can be indicated by numbers or symbols next to the line.


  </details>
 
Class Diagram:
1. **User, Post, Subreddit (Entities)**: These classes represent the core business objects in the system. A user can create many posts, and each post belongs to one subreddit.

2. **UserService, PostService, SubredditService (BusinessLayer)**: These classes perform operations on the entities and manage the business logic of the application. They also make sure that any business rules or invariants are upheld.

3. **Relations:**
- There is a one-to-many relationship from User to Post and from Subreddit to Post, indicated by "1" at User and Subreddit ends, and "0..*" at Post end. This implies that one User/Subreddit can have zero or many Posts.

4. **Packages**: The classes are grouped into the RedditBusinessLayer package. RedditBusinessLayer contains the entities and services. This structure indicates a clear separation of concerns within the architecture of the application.
<div align="center">
<img src="/SEM2/The individual project/Docs/Class Diagram/Final2 Class Diagram.png" alt="Class Diagram">
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
