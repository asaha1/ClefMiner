# Clef Miner
##Learn staffs the most amazing way!


##Team Members

Himangshu Ranjan Borah
[hborah@ncsu.edu]

Arnab Saha
[asaha@ncsu.edu]



##Subject Matter and Learning Objectives:

The game is centered around the basic concepts of the Musical Notation theory. The staffs are the fundamental latticework of music notation used to express music in written form which is one of the very basic things anybody has to learn whenever he or she is starting off with any kind of musical education. Frequently we see that learners find it very difficult in the beginning to grab the concepts of even basic notations and often jumble up different notations and their audio feedbacks. Before going to start off with reading and writing complex scales and full songs in these symbolic notations, it is very important to grab the basic symbol to sound mapping at the very beginning of music education. Here we focus on teaching the rudimentary staff notations with their corresponding notes’ audio feedback and the relevant basic concepts a student needs to get themselves started with any kind of formal musical notation education in the most fun way.

##Target Audience:

The target audience domain of our game can be novices who has started to learn music or can be amateurs who have trouble in learning the notations spread across different age groups. Basically, anybody who is starting off with any kind of formal education in music will find it very useful. Even people who don’t belong to any of these categories may find it interesting to play the game as one can learn some basic idea of written music in a fun way.

##Overview (Genre, Objective, Gameplay):

The exact genre of the game would be a Music Game [Wikipedia]. However, depending on the actual gameplay mechanics and the arena layout, we will be able to categorize it further later(for e.g. Platformer). The objective of the gameplay would be to mainly teach the players the mapping of staff notations to their corresponding sounds. The initial stages of the game start off with the single notes and their corresponding staff formations. Then it incrementally builds upon the baseline and teaches about various related concepts like pitches, different clefs, duration signifiers, bars, rests etc. Then slowly the game moves into the domain of chords and scales progressively. During the gameplay, the backend student modeling will be used to give constructive immediate feedback based on students’ performance and keep suggesting new levels. The main idea behind this is to try to use the symmetry and repetitiveness of musical theory to dynamically generate new levels depending on what the ITS learns about the ability and progress of the player. The main concepts that we are trying to focus in the very beginning of the game are listed below (References for the technical terms given later). 

A small introductory tutorial explaining the navigation and rules of the game. It also explains the notations very briefly.
Introduction to 3 major Clefs F, C and G.

First level consists of identifying different clefs.

Second level focuses on different notes located in different clefs.

Third level teaches the note duration and bars related concepts.

Later states will simulate chords and scales and so on.

##Basic Gameplay Idea:

We have roughly thought about the layout and gameplay mechanics of the first few levels. The levels can be seamlessly generated or can be discrete.  

##Level 1: 
The Clefs are the basic building blocks of the notation theory which tell us about the pitch of the notes. There are three major Clefs namely F, C and G which we will be covering in our environment. The idea of this stage is to familiarize the player with the symbols of the clefs, which are shown on the pic on the left. (Source: Wikipedia)

##Level 2: 
After the Clefs, there come actual notes. The notes are usually drawn using some symbols on a 5 line ruled sheet (Called the “Staff”). The exact location of the symbols on the Staff with respect to the positioning of one Clef describes a note which corresponds to one sound. For example, the following shows different notes and theirs corresponding staff notations.  (Source: The Internet)


The idea is to familiarize the player with different notations. We have ideated a few gameplay tactics to implement in various levels.

Gameplay Mechanics 1: One of the gameplay mechanics that we think of it as a vertically moving arena. There will be balls falling from the top with different Clefs drawn on it. The player will be asked to consume a specific kind of clef at a time. Correct consumption keeps the player alive, or he loses a life. 

Gameplay Mechanics 2: As opposed to the Clefs, the notes are significantly similar to each other. So here we will create a level where the notes will be static and it would give the learner enough time to identify the correct symbol. The game will also play the sound of the note when the learner identifies the correct note.

Gameplay Mechanics 3: The third mechanics that we think of it as to design the Game Arena as a race track with many lanes. The lanes will have correct notes and incorrect notes. The player has to drive through the pathways of correct note set (as indicated in the beginning) and reach the goal. Here we are assuming that the player has enough experience with the notations and can identify the notes even when they are moving.

Gameplay Mechanics 4: Yet another way of implementing this could be to design a basket of notes from where they will keep falling and the player has to collect correct notes as denoted by their staffs to gain score. Throughout the gameplay, the audio feedback of the corresponding notes will be played in order to help the player map the sounds to the staff and the notations.

Gameplay Mechanics 5: For this purpose we plan to create a 3D level where the aim of the user will be to hit some notations in the correct order so as to create a chord. The chord will be played if the user managed to hit the right chords. The difficulty of the game will steadily increase or decrease according to the performance of the player.

Gameplay Mechanics 6: Another very interesting approach would be to design a horizontally movable world where there will be a moving character who keeps searching for a specific note at one time as directed by the gameplay(Platformer Genre). The notes will be hidden at places and the player has to hunt for the treasure. As and when the player uncovers treasures, new objects will appear dynamically and the player will be moving horizontally and vertically to find the hidden treasure.

##Platforms/Technologies:

The game will be mainly designed in Unity. But few of our resources like staffs and notes might be very much customized and hence we will also be using some photo editing tools like Photoshop to design those resources. We will record and edit the Audio with POD HD 300 Edit and Apple Garage Band using feedbacks from synthesizers and Electric Guitar processing units(Line 6 POD HD 300). We are planning to use Crescendo for designing the staff notations.

##References:

https://method-behind-the-music.com/theory/notation/#staff
http://www.musicnotes.com/blog/2014/04/11/how-to-read-sheet-music/
https://en.wikipedia.org/wiki/Clef
https://en.wikipedia.org/wiki/List_of_musical_symbols






# Level 1: Learning the Clefs.
# Identify the Clefs.
The Story line of Level 1:

1. The player Enters the arena.
2. A tutorial page is shown explaining the details of what to, the page has a button for OKAY!.
3. The Score Board is initalized with Correct Notes, Wrong Notes, Life Left(Initalized to 3 lives), Boxes left to find.
4. There are a number of note miner boxes lying in the arena, shoot the box to pop open the note.
5. The Notes start moving in random directions when pops out.
6. Notes can be either allowed to touch the player or can be shoot down or cut with a knife.
7. If a friend note touches you, you get +100 points and if you shoot them, you loose 50 points from you Frindship Score.
8. If an enemy note touches, you go dead with death animation and loose a life. Shoot an enemy note and you get +100 points in Enmity Score..
9. Final Score is the addiction of Correct Note Score(Friendship Score) and Wrong Notes Score(Enmity Score).
10. When fall down to hell wall, loose a life.
11. Loose all 3 lives, then Go Back to Main Menu with Game Over(Or Retat as of now with Game Over Animation!).
12. All the time, boxes left to find keeps getting updated.
13. Game Ends when all the Boxes are found, ends with proper cheering up!
14. Walking Sound needed?
15. There will be a level timer.
16. There'a a timer for every Note Mine. On the expiration,  no matter enemy or frind, you loose 20 points.
17. Hit a wrong Note, player dies. Press R to resurrect. Die thrice to Game Over.
18. Give popups or some signal on correct and wrong note selection.


Feedbacks:

1. Consecutive 3 wrong note selection will pop up a guide to clarify the specific Notes on which he makes mistakes.
2. If the player wants, then put spot lights on the notes that needs to be found.
3. if not able to find more boxes, then after 1 minutes give hints on where the next boxes are located.
4. Depending on the final scores, gives feedback on what were the most mistaken notes and show the notes again once.


Assets:
1. Mild background Music.
2. Poping out sound when the note is uncovered.
3. As soon as shot or touched, the audio feedback should be played. Need the audio for the notes.(Mild Clossion sound for clefs.)
4. 3 Sprites for 3 clefs.




