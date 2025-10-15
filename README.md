Bayview Municipal Services App

Project Overview
The Bayview Municipal Services App is a Windows Forms application designed to digitise citizen services for the Bayview Metropolitan Municipality. The system allows residents to report municipal issues, view announcements, and track the status of service requests. Employees can manage reported issues and mark them as resolved once addressed.
This project demonstrates role-based authentication, simple in-memory data storage, and an interactive GUI with modern design principles.
Features
For Residents:
Sign up and log in as a resident.
Submit municipal service issues with location, category, description, and optional attachment.
View all reported issues, including status updates.
Access digital announcements and local events (placeholder functionality for now).
For Employees:
Sign up and log in as an employee.
View all reported issues in a centralised dashboard.
Mark issues as Resolved once completed.
Access the dashboard directly after login for faster issue management.
User Roles
Role	Access
Resident:	Main menu, report issues, view status of all issues, see dashboard (read-only)
Employee:	Direct dashboard access, view and update issue status, mark issues as resolved
Technologies Used
Language: C# (.NET Framework / .NET Core Windows Forms)
IDE: Visual Studio
UI: Windows Forms with panels, FlowLayoutPanel, and DataGridView
Data Storage: In-memory collections (List) for users and issues
Design: Role-based access, header and background branding consistent across forms
Setup & Installation
Clone or download the repository:
git clone https:MunicipalServicesApp_Part-1 
Open the project in Visual Studio.
Set the LoginForm as the startup form.
Build and run the project (F5 in Visual Studio).
Usage
Launch the app.
Sign up a new account or log in with a default demo account:
Residents:
Username: resident1
Password: 1234
Employees:
Username: employee1
Password: admin
Navigate through the main menu (residents) or dashboard (employees).
Residents can submit issues; employees can mark them as resolved.
Project Structure
MunicipalServicesApp/
│
├─ Forms/
│  ├─ LoginForm.cs
│  ├─ SignupForm.cs
│  ├─ MainForm.cs
│  └─ DashboardForm.cs
│
├─ Models/
│  ├─ User.cs
│  └─ Issue.cs
│
├─ Services/
│  └─ IssueRepository.cs
│
├─ Properties/
│  └─ Resources.resx (images, logos, flags)
│
└─ Program.cs
Future Enhancements
Integrate a persistent database (SQL Server or SQLite) instead of in-memory storage.
Enable file attachments for issues to be uploaded and viewed.
Add notifications for residents when their issue status changes.
Implement real local events & announcements feed.
AI usage AI was used to generate the logo 
Link: Fake flag with B
Background image is from google
Link: https://www.google.com/url?sa=i&url=https%3A%2F%2Freliablebackgroundscreening.com%2Findustries-served%2Fgovernment%2F&psig=AOvVaw2scRjEvClN5ONDEW_EJsN9&ust=1757600001431000&source=images&cd=vfe&opi=89978449&ved=0CBUQjRxqFwoTCOD95cKwzo8DFQAAAAAdAAAAABAE
Video 
Link:https://youtu.be/m4j5Yti4zXI
# 🏙️ Municipal Services Application – Part 2

### Student: Soyama Pango  
### Student Number: ST10275135  
### Module: PROG6212  
### Project Type: POE Part 2 – Advanced Data Structures and Algorithms  

---

## 📘 Project Overview

The **Municipal Services Application** is a C# Windows Forms application that provides users with access to local events and announcements within their municipality.  
This version (Part 2) enhances the previous project by integrating **advanced data structures and algorithms** such as stacks, queues, hash tables, dictionaries, and sets to improve data management and user experience.

---

## 🧩 Key Features

### 1. **Main Menu**
- Allows users to navigate to different modules of the application, including:
  - Local Events and Announcements
  - Citizen Service Requests
  - Contact and Help sections

### 2. **Local Events & Announcements**
- Displays a list of all upcoming municipal events and public announcements.
- Includes search, category, and date filtering options.
- Uses **Dictionary** (Hash Table) for quick event lookups.
- Integrates **Stack**, **Queue**, and **HashSet** for optimized data processing.
- Provides intelligent **recommendations** based on user searches.
- Includes a **Refresh Button** to reload updated event data.
- Allows users to navigate back to the main menu.

### 3. **Recommendation Feature**
- Based on recent searches and viewed events.
- Uses:
  - **Stack** – to track search history.  
  - **Queue** – to maintain a list of recently viewed events.  
  - **Dictionary** – for quick access to related events by category.  
  - **HashSet** – to ensure unique categories.

---

## ⚙️ Technologies Used
- **C# (.NET Framework 4.8)**
- **Windows Forms**
- **Object-Oriented Programming (OOP)**
- **Data Structures**: Stack, Queue, Dictionary, HashSet
- **Visual Studio 2022 / 2019**

---

## 🧠 Data Structures Summary

| Data Structure | Module Used In | Purpose |
|----------------|----------------|----------|
| **Stack** | Local Events & Announcements | Tracks user search history for recommendations |
| **Queue** | Local Events & Announcements | Manages recently viewed events (FIFO) |
| **Dictionary** | Local Events & Announcements | Stores and retrieves events by category efficiently |
| **HashSet** | Local Events & Announcements | Ensures categories are unique (no duplicates) |
| **SortedDictionary** *(optional)* | Future extension | Could be used for sorting events by date or priority |

---

## 🖱️ How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/SoyamaPango/ST10275135_MUNICIPAL-SERVICE-APP-PART-2.git

