# 🏛️ Municipal Services Application – Task 3 Reports

## 🔗 Links
- **Demo Video:** [https://studio.youtube.com/video/54SkerS9ESw/edit](https://studio.youtube.com/video/54SkerS9ESw/edit)

---

## 🧩 Implementation Report

### Overview
The Municipal Services Application Task 3 focused on implementing the **Service Request Status** functionality, integrating advanced data structures and algorithms to manage, organise, and display service request information efficiently. The application allows users to track the progress of service requests using unique identifiers and view dependencies between requests.

---

### How to Compile and Run
1. Open the solution in **Visual Studio 2022 or later**.  
2. Build the solution: **Ctrl + Shift + B**  
3. Run the application: **F5** or **Ctrl + F5**  
4. On the main menu, select **Service Request Status** to view and interact with requests.  
5. Use the **Search by ID** field to locate specific service requests.  
6. Click **Show Dependencies** to display dependent service requests.  
7. Click **Refresh** to reload the list of service requests after any updates.  

---

## 🧮 Implemented Data Structures

### 1. Binary Search Tree (BST)
- **Role:** Efficiently stores and retrieves service requests by unique ID.  
- **Contribution:** Searching a request by ID has O(log n) average complexity.  
- **Example:** The user enters REQ002 → BST quickly locates and displays the request.  

### 2. AVL Tree
- **Role:** Self-balancing BST for ordered traversal of requests by date.  
- **Contribution:** Maintains balance automatically, ensuring O(log n) insertion, deletion, and search.  
- **Example:** Service requests sorted chronologically for reporting purposes.  

### 3. MinHeap
- **Role:** Prioritises requests by submission date (older = higher priority).  
- **Contribution:** Supports priority-based views efficiently.  
- **Example:** The oldest pending requests appear at the top of the display.  

### 4. Graph
- **Role:** Represents service request dependencies.  
- **Contribution:** Supports depth-first search traversal to track progress and identify connected requests.  
- **Example:** Selecting REQ005 and clicking Show Dependencies displays the chain of dependent requests.  

### 5. Custom Data Structures
- **Linked List, Queue, Stack, Set** used for managing requests by status, storing recently resolved requests, and ensuring uniqueness where required.  

### 6. Optional Advanced Structures
- **Red-Black Tree / Minimum Spanning Tree:** Not implemented as dependencies were unweighted; can be added for enhanced efficiency in complex scenarios.  

---

## 📘 Project Completion Report

### Challenges Faced
1. Integrating multiple data structures – Ensuring that BST, AVL Tree, Heap, and Graph work together without data conflicts required careful design.  
2. Dependency management – Initially, new service requests did not appear in the dependency graph. This was resolved by adding sample edges and ensuring the repository updated correctly.  
3. UI responsiveness – Maintaining a smooth and accurate DataGridView while reflecting changes in multiple underlying structures required event handling and refresh logic.  
4. Data persistence – Since the application currently uses in-memory storage, refreshing the form rebuilds data structures dynamically.  

---

### Solutions Implemented
- Created a unified repository (**ServiceRequestRepository**) to feed all data structures.  
- Implemented refresh functionality to rebuild trees, heap, and graph whenever data changes.  
- Validated user inputs to avoid invalid or incomplete service requests.  
- Used depth-first traversal (**DFS**) to display request dependencies clearly.  

---

### Key Learnings
- Improved understanding of **binary trees, AVL trees, heaps, and graphs**.  
- Learned to combine multiple data structures efficiently for real-world applications.  
- Developed skills in **Windows Forms UI design**, **event handling**, and **data binding**.  
- Gained experience in **problem-solving**, **debugging complex logic**, and integrating algorithms in practical software.  

---

## 💡 Technology Recommendations

### 1. Database Integration (SQL Server / SQLite)
- **Current storage is in-memory**; a database would allow persistent storage and multi-user access.  
- **Benefit:** All service requests and updates are retained across sessions.  

### 2. Graphical Data Visualization
- Use a charting library (e.g., **LiveCharts**) to visualise dependencies and request status.  
- **Benefit:** Makes dependency relationships clearer and easier to interpret.  

### 3. REST API Layer
- Implement a backend API to allow mobile and web clients to submit and track requests.  
- **Benefit:** Enables future expansion to cross-platform use.  

### 4. Red-Black Tree / Weighted Graph for Dependencies
- If dependency relationships become complex with weights (priority, severity), these structures will optimise retrieval and reporting.  

---

## 🔄 Updates Based on Feedback
- Added dropdown selection for **Resident vs Employee** login.  
- Fixed UI navigation to prevent non-employee features appearing for employees.  
- Implemented refresh logic to ensure dashboards update after adding or resolving requests.  
- Added **sample data** (15+ events and service requests) for demonstration purposes.  

---

## ✅ Conclusion
Task 3 of the Municipal Services Application is complete, with fully functional **Service Request Status** management. All key data structures have been implemented, and the application is able to efficiently display, search, and manage service requests. Minor enhancements (persistent storage, advanced visualization, weighted MST) could further improve performance and usability.
