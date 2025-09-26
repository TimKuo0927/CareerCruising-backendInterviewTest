# GraduationTracker

## Overview
**GraduationTracker** is a **C#** project that determines whether a student has graduated based on their course marks and a diploma's requirements.  
It calculates the student's academic standing (e.g., **Remedial**, **Average**, **MagnaCumLaude**, **SumaCumLaude**) and ensures all graduation criteria are met, including minimum credits and passing all required courses.

## Features
-  Checks if a student meets all diploma requirements  
-  Calculates total credits earned from passed courses  
-  Determines academic standing based on average marks  
-  Provides detailed graduation results  

## Prerequisites
- .NET 8 SDK
- Visual Studio 2022 or later (recommended)

## How to Run

### 1️ Clone the Repository
```bash
git clone <your-repo-url>
cd GraduationTracker
```

### 2 Build the Solution
Open the solution in Visual Studio 2022 and build, or use the command line:
```bash
dotnet build
```

### 3 Run the Unit Tests
Use Visual Studio's Test Explorer, or run from the command line:
```bash
dotnet test
```

### 4 Usage
The main logic is in the GraduationTracker class.
You can use the HasGraduated method to check a student's graduation status:
```bash
var tracker = new GraduationTracker();
var result = tracker.HasGraduated(diploma, student);

// result.Item1: bool    -> graduated or not
// result.Item2: STANDING -> academic standing
// result.Item3: int     -> credits earned
```

## Project Structure
```bash
GraduationTracker/             # Core logic and models
GraduationTracker.Tests.Unit/   # Unit tests for graduation logic
```
