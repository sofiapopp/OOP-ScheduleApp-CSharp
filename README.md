# Uni Organizer

**Uni Organizer** is a console-based C# application developed as part of a university coursework for *Object-Oriented Programming* course.  
The project was created in **December 2023** to demonstrate principles of structured OOP design, data encapsulation, user interaction, and file operations in a real-world academic scheduling scenario.

## Purpose

The application helps organize essential aspects of the educational process in a higher education institution. It allows users to manage student groups, create and edit timetables, and associate them with specific teachers, dates, times, and classrooms.

## Features

### Student Group Management
- Create and manage student group lists
- Display student information
- Edit student data interactively

### Schedule Management
- Create and manage a timetable for a student group
- Assign teachers and classrooms
- Check classroom availability for specific date/time
- Display full schedule in the console

### File Interaction
- Save schedule data to a text file
- Open saved schedules via Notepad
- Clear contents of saved files

### Teacher Management
- Add and edit information for teachers
- Assign teachers to specific classes


## Class Structure

| Class            | Description                                                                 |
|------------------|-----------------------------------------------------------------------------|
| `Student`        | Represents a student with name and rating; includes input/output methods.   |
| `StudentsGroup`  | Manages a group of students; supports list editing and display.             |
| `Teacher`        | Models a teacher with department, full name, and position.                  |
| `Date`           | Represents calendar date; includes input and format validation.             |
| `Time`           | Represents class time; includes input and validation logic.                 |
| `Class`          | Base class for an academic lesson (discipline, type, time, date, location). |
| `Pair`           | Inherits from `Class`; connects lesson with teacher and student group.      |
| `Schedule`       | Manages a list of `Pair` objects (schedule); supports file I/O and display. |
| `Menu`           | Console interface for interacting with users and routing program flow.      |
| `Program`        | Entry point of the application; starts the interactive menu.                |


## Technologies Used

- **Language:** C#
- **Platform:** .NET 6.0 Console Application
- **IDE:** Visual Studio 2022
- **Testing Framework:** MSTest
- **File I/O:** `System.IO.StreamWriter`, `Notepad`
- **LINQ:** for teacher filtering and manipulation
- **OOP Concepts:** Inheritance, Encapsulation, Static Methods, Operator Overloading, Input Validation


## Project Structure

CW2/  
├── CW2.sln                   # Solution file  
├── CW2/                      # Main project folder  
│   ├── Program.cs  
│   ├── Menu.cs  
│   ├── Schedule.cs  
│   ├── Pair.cs  
│   ├── Class.cs  
│   ├── Student.cs  
│   ├── StudentsGroup.cs  
│   ├── Teacher.cs  
│   ├── Date.cs  
│   ├── Time.cs  
│   └── CW2.csproj  
├── InputTests/               # Unit test project  
│   ├── InputTests.csproj  
│   ├── UnitTest1.cs  
│   └── Usings.cs  
├── .gitignore                # Ignore build files and temp folders  


## How to Use

After launching the application, the user is presented with an interactive console menu.

### Navigation
- Use the **Up** and **Down** arrow keys to navigate the menu.
- Press **Enter** to select an option.

### Menu Options Overview

#### 1. Create a group of students
- Input the group code and number of students.
- You can either fill in the student list immediately (`yes`) or do it later (`later`).
- Student data (last name and rating) can be added via console prompts.

#### 2. Display the list of students
- Shows all students currently added to the group.
- Requires the group and student list to be created beforehand.

#### 3. Create a schedule
- Requires a student group to exist.
- For each lesson (called "pair"), input:
  - Subject (discipline)
  - Teacher's full name
  - Number of lessons per week
- Then, for each class:
  - Select class type, date, time, and location.
  - The input is validated for correct format.
- You can continue adding lessons or finish the process.
  
#### 4. Display the schedule
- Shows the current schedule in a formatted table.
- Saves the schedule to a text file.
- Optionally, you can open the file or clear it via prompts (`yes`/`no`).

#### 5. Display occupied/unoccupied classrooms
- Input a date and time.
- The program checks room availability and shows two lists: occupied and free classrooms.

#### 6. Add and display info about teachers
- You can enrich the schedule by adding department and position info for teachers.
- Data is collected via prompts and assigned using LINQ queries.

#### 7. Exit
- Ends the session.
- Press any key to close the console after exit confirmation.


## Example

### Initial program interface

<img width="652" height="316" alt="image" src="https://github.com/user-attachments/assets/06cc5534-b9fe-497b-8eb3-865eddd214a1" />

### Output of the "Create a group of students" option

<img width="663" height="274" alt="image" src="https://github.com/user-attachments/assets/fadab979-0116-45b5-a4da-70909ca91cbb" />

### Entering student information

<img width="626" height="308" alt="image" src="https://github.com/user-attachments/assets/65ebf725-4538-49d7-9317-2fd2d09d10c2" />

### Warning message

<img width="431" height="184" alt="image" src="https://github.com/user-attachments/assets/ef2be1f3-3b43-4bbf-a1d6-1e3b8e53cbf5" />

### Output of the "Display the list of students" option

<img width="749" height="245" alt="image" src="https://github.com/user-attachments/assets/9c2d698f-dbca-4ed6-bda6-38a3b6d3f117" />

### Output of the "Create a schedule" option

<img width="483" height="396" alt="image" src="https://github.com/user-attachments/assets/a468758d-ae29-4134-9c37-e667f6fa5ccb" />

### Output of the "Display the schedule" option

<img width="783" height="362" alt="image" src="https://github.com/user-attachments/assets/3772d758-14e7-424f-8cb8-172a6c0db69d" />

### File output of the "Display the schedule" option

<img width="618" height="310" alt="image" src="https://github.com/user-attachments/assets/a3b48be3-7a67-4549-bf45-f2bc163e50d5" />

### Output of the "Display occupied/unoccupied classrooms" option

<img width="528" height="326" alt="image" src="https://github.com/user-attachments/assets/19e27b53-9cb0-452a-95da-44f8f9855792" />

### Output of the "Add and display info about teachers" option

<img width="697" height="301" alt="image" src="https://github.com/user-attachments/assets/b89295bd-77dc-4d85-81c1-e491d9ab9e24" />


## License

This project was developed for educational purposes.  
If you use it or modify it, please credit the original author.




