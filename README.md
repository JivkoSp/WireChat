# WireChat

<p align="center">
  <img src="https://user-images.githubusercontent.com/97282923/181274131-ba383de9-e9ef-4da0-9ab4-043d496c2497.png" alt="Logo" width="100" height="500">
</p>

---

WireChat is a messaging app inspired by Discord and Telegram. The app features two-factor authentication using QR codes for enhanced security, options for message preservation in the database, and a comprehensive set of functionalities including:

1. One-to-one chat with friends
2. Group chat (open to anyone, not just friends)
3. Approval/Decline of requests for one-to-one or public chats
4. Group roles management
5. Password change with email verification
6. Profile picture update
7. Block/Unblock friends or group members
8. Active groups panel showing current activity (active status persists for 30 seconds after last message)

## 1. How the app looks

### LogIn/SignUp page:
<p align="center">
  <video width="100%" controls>
    <source src="https://user-images.githubusercontent.com/97282923/181248953-7a14d2e3-c223-4f32-9bf3-8be83bd8c776.mp4" type="video/mp4">
    Your browser does not support the video tag.
  </video>
</p>

### SignUp:
<p align="center">
  <video width="100%" controls>
    <source src="https://user-images.githubusercontent.com/97282923/181251218-10552b50-5cbb-473e-8e2e-2b35949ca0e0.mp4" type="video/mp4">
    Your browser does not support the video tag.
  </video>
</p>

### Add friend and profile options:
<p align="center">
  <video width="100%" controls>
    <source src="https://user-images.githubusercontent.com/97282923/181248914-334689c1-2911-4376-a974-41e92f344670.mp4" type="video/mp4">
    Your browser does not support the video tag.
  </video>
</p>

### One-to-one chat, group chat and group activity:
<p align="center">
  <video width="100%" controls>
    <source src="https://user-images.githubusercontent.com/97282923/181253929-b0cc4002-96a2-49b1-b7aa-69b54b11cef7.mp4" type="video/mp4">
    Your browser does not support the video tag.
  </video>
</p>

### Block/unblock friends:
<p align="center">
  <video width="100%" controls>
    <source src="https://user-images.githubusercontent.com/97282923/181256345-754f677f-d5f9-4a22-9475-4529cbfe0bf4.mp4" type="video/mp4">
    Your browser does not support the video tag.
  </video>
</p>

## 2. How the app works

### Database:
The chat uses SQL Server DB with Entity Framework for data management. The repository design pattern is implemented to encapsulate SQL queries into specific repository classes, ensuring code reuse and maintainability.

### Messaging:
SignalR API is utilized for real-time messaging, supporting WebSockets, Server-Sent Events, and Long Polling. SignalR ensures seamless connection fallback and handles disconnected clients effectively.

### Model objects:
AutoMapper API is employed for mapping between model objects and DTOs, minimizing code duplication and simplifying complex mappings where necessary. ViewModel convention is used for read-only views of model data.

### Motivation:
The project was motivated by a desire to understand messaging applications and technologies such as WebSocket in practice. It serves as a practical application to explore and implement these protocols while enhancing skills in MVC development.
