INSERT INTO Subreddits (Name, Description)
VALUES ('ExampleSubreddit1', 'This is an example subreddit for testing purposes.'),
       ('ExampleSubreddit2', 'This is another example subreddit for testing purposes.'),
       ('ExampleSubreddit3', 'This is a third example subreddit for testing purposes.'),
       ('ExampleSubreddit4', 'This is a fourth example subreddit for testing purposes.'),
       ('ExampleSubreddit5', 'This is a fifth example subreddit for testing purposes.');

INSERT INTO Users (Username, Password, Email)
VALUES ('ExampleUser1', 'ExamplePassword1', 'example1@example.com'),
       ('ExampleUser2', 'ExamplePassword2', 'example2@example.com'),
       ('ExampleUser3', 'ExamplePassword3', 'example3@example.com'),
       ('ExampleUser4', 'ExamplePassword4', 'example4@example.com'),
       ('ExampleUser5', 'ExamplePassword5', 'example5@example.com');

INSERT INTO Posts (Title, Content, DateCreated, UserId, SubredditId)
VALUES ('Example Post 1', 'This is an example post for testing purposes.', GETDATE(), 1, 1),
       ('Example Post 2', 'This is another example post for testing purposes.', GETDATE(), 2, 2),
       ('Example Post 3', 'This is a third example post for testing purposes.', GETDATE(), 3, 3),
       ('Example Post 4', 'This is a fourth example post for testing purposes.', GETDATE(), 4, 4),
       ('Example Post 5', 'This is a fifth example post for testing purposes.', GETDATE(), 5, 5);

INSERT INTO Comments (Content, DateCreated, UserId, PostId)
VALUES ('This is an example comment for testing purposes.', GETDATE(), 1, 1),
       ('This is another example comment for testing purposes.', GETDATE(), 2, 2),
       ('This is a third example comment for testing purposes.', GETDATE(), 3, 3),
       ('This is a fourth example comment for testing purposes.', GETDATE(), 4, 4),
       ('This is a fifth example comment for testing purposes.', GETDATE(), 5, 5);
