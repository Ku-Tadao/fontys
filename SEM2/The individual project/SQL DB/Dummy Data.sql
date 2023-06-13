USE [reddit]
GO

-- Inserting data into Subreddits table
INSERT INTO [dbo].[Subreddits] ([Name], [Description])
VALUES ('Technology', 'A subreddit for discussing technology'),
       ('Gaming', 'A subreddit for discussing video games'),
       ('Science', 'A subreddit for discussing science');

-- Inserting data into Users table
INSERT INTO [dbo].[Users] ([Username], [Password], [Email])
VALUES ('JohnDoe', 'password123', 'johndoe@email.com'),
       ('JaneDoe', 'password456', 'janedoe@email.com');

-- Inserting data into Posts table
INSERT INTO [dbo].[Posts] ([Title], [Content], [DateCreated], [UserId], [SubredditId])
VALUES ('New iPhone release', 'Apple has just released their new iPhone model!', GETDATE(), 1, 1),
       ('New game release', 'A new game has just been released!', GETDATE(), 2, 2);

-- Inserting data into Comments table
INSERT INTO [dbo].[Comments] ([Content], [DateCreated], [UserId], [PostId])
VALUES ('I can''t wait to get the new iPhone!', GETDATE(), 1, 1),
       ('I''ve been waiting for this game for so long!', GETDATE(), 2, 2);
