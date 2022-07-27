# WireChat

WireChat is messaging app that is inspired from Discord and Telegram.
The app has two factor authentication feature that works with QrCode(this is more secure than sms for excample, where the youser gets the auth code throuth sms),
it also allows users to choose if and how they messages will be preserved from Db. 
Besides that users will get all the functionality they expect:
-------------------------------------------------------------------
1. One-to-one chat with user friends
2.Group chat (that is not necesseraly with only friends i.e user can chat with anybody in the group)
3.Approve/Decline request from one-to-one or public chats
4.Group roles
5.Change password with email verify
6.Change profile picture
7.Block/Unblock friends or people in group
8.Current active groups pannel that shows when particular group is active (group is active 30sec after last message is send)
------------------------------------------------------------------

1. How the app looks

LogIn/SignUp page:
https://user-images.githubusercontent.com/97282923/181248953-7a14d2e3-c223-4f32-9bf3-8be83bd8c776.mp4

SingUp:
https://user-images.githubusercontent.com/97282923/181251218-10552b50-5cbb-473e-8e2e-2b35949ca0e0.mp4

Add friend and profile options:
https://user-images.githubusercontent.com/97282923/181248914-334689c1-2911-4376-a974-41e92f344670.mp4

One-to-one chat, group chat and group activity:
https://user-images.githubusercontent.com/97282923/181253929-b0cc4002-96a2-49b1-b7aa-69b54b11cef7.mp4

Block/unblock friends:
https://user-images.githubusercontent.com/97282923/181256345-754f677f-d5f9-4a22-9475-4529cbfe0bf4.mp4

2. How the app works

DataBase:
For data storage the chat uses Sql Server Db together with Entity Framework for working with the data models.
-Design Patterns:
I have implemented the repository design patter to work with the data models so that the sql queries will not be
all over the place and be contained in particular repo class (each model have its own repo class). That also allows
me to reuse particular query and not have duplication of code.

Messaging:
For the messaging part i've used SignalR api. SignalR uses 3 transport types for messaging:
-WebSockets
-Server side events
-Long pulling

I have choosen it becouse the connection will have fallback to the other's transports and not be shut down 
if for excample the server or client have problem with WebSocket.
It also allows for disconnected clients to have some time to re-connect back and to be easly indentified when the connection is closed.

Model objects:
I have used AutoMapper api to mapp model object to dto object for the reasons below:

1. No dublication for every mapping
2. In more complex situations where one type have some navigation properties set but not necesseraly all
   makes mapping to dto easy becouse AutoMapper ignores NullRef exceptions by default

For some models i have used [name]ViewModel convention to implify that the particular model will be used 
in readonly fashion by the view, besides that it has the same purpose as dto.






