# MoodChat
*Real-time Chat Application with Sentiment Analysis*

[Available on Azure](https://moodchat.azurewebsites.net)

## Overview

This web app offers real time anonymous chat functionality with AI sentiment analysis.

Sentiment analysis is a process where AI determines the emotional tone behind a series of words. For more details, you can refer to [Microsoft's documentation](https://learn.microsoft.com/en-us/azure/ai-services/language-service/).


### Technologies used

- Backend of the Web App is developed using ASP.NET Core. 

- Messages are received in real time by all clients thanks to Azure SignalR.

- Sentiment analysis is provided by Azure Cognitive Services Text Analytics API.

- Data is stored in Azure SQL Server.

- App is deployed on Azure App Service and available by [this link.](https://moodchat.azurewebsites.net)

### Functionality

- Website:
- * Website contains single page that displays messages and input field.

- Data:
- * When visiting page 5 last messages are pulled from  database and displayed.

- UI:
- * All messages are color-coded based on sentiment that AI managed to determine from text:
- * + ${\color{#adffad} green}$  for positive sentiment
- * + ${\color{#ffadad} red}$ for negative
- * + ${\color{#d6d6ad} pale olive}$ for mixed
- * + ${\color{#d0d0d0} gray}$ for neutral


## Room for improvement

There are several improvements that may be made to project:
- Improved UI. Any of the frontend libraries may be used to improve User Experience.
- More detailed display of sentiment analysis result. Currently servers sends string with analysis result to client. It is possible to integrate more detailed results into UI if needed.
- User management. Adding input field for username and displaying it with message is trivial. It is also possible to add user authorization and authentication and save users to database.

