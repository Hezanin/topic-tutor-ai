# TopicTutorAI 

TopicTutorAI is a mobile application that dynamically generates custom quizzes with the help of OpenAI's ChatGPT language model. 

## Table of Contents

1. [Overview](#overview)
2. [Features](#features)
3. [Technologies Used](#technologies-used)
4. [Single player Mode](#single-player-mode)
5. [Multiplayer Mode](#multiplayer-mode)
6. [Screenshots](#screenshots)

## Overview

An innovative Unity project that creates AI-generated quizzes -  with TopicTutorAI, you can easily create personalized quizzes by entering your desired topic, quiz difficulty, and size. The [OpenAI](https://openai.com/) [ChatGPT](https://openai.com/chatgpt) language model (currently GPT-3.5) will then generate a custom quiz tailored to your specifications.

## Features

- **Dynamically Generated Quizzes:** Quizzes are generated dynamically based on each custom request received from the user.
- **Single player Mode:** Single player mode can be used for individual challenges against a desired topic.
- **Multiplayer Mode:** With multiplayer mode, players can create rooms and join a custom game created by the host.
- **Android Compatibility:** Build for Android devices.
  
## Technologies Used

- [Unity](https://unity.com/): Game engine used for development.
- [OpenAI](https://openai.com/) API: Used to make requests to [ChatGPT](https://openai.com/chatgpt) 3.5 language model.
- [Photon Pun2](https://www.photonengine.com/PUN): Networking framework that handles all processes involved in building the multiplayer mode. 

## Single player Mode

Single player mode contains the core functionality of the app, in which players can challenge themselves to complete dynamically generated quizzes tailored to their preferences.
As stated before, options such as topic name, size and difficulty can be adjusted to personal preference and at the click of a button, a quiz will be generated using OpenAI's AI. Players will receive immediate feedback upon completing the quiz with a score screen that displays a score percentage.

## Multiplayer Mode

Multiplayer mode envelops the single player mode with the addition of joining a regional lobby and having the possibility of creating and joining rooms. Once all party members mark themselves as 'Ready', the host can proceed with the generation of the quiz, after which all party members will receive. Upon completition of the quiz, each player will be able to see a leaderboard with the score percentage of each player in the party.   

## Screenshots
<img src="https://github.com/Hezanin/topic-tutor-ai/assets/62186294/45dab3e6-df64-4814-89ea-3b2b8cf31a2c" alt="In Quiz" width="900"/>
<img src="https://github.com/Hezanin/topic-tutor-ai/assets/62186294/8fadb0f1-d110-4b80-8a2c-2b6b50e50793" alt="Multiplayer" width="900"/>
<img src="https://github.com/Hezanin/topic-tutor-ai/assets/62186294/09836f6b-c853-4551-9677-bb47aac498ce" alt="Score" width="900"/>
