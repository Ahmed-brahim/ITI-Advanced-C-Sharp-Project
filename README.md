# 📝 Examination System - C# Console Application

This is a console-based Examination System built with C# using object-oriented programming principles. The system allows users to take different types of exams (Practical or Final) in various subjects with multiple types of questions (True/False, Choose One, Choose All).

---

## 📂 Project Structure

```
Examination_System/
│
├── Program.cs               # Entry point to run the app
├── Subject.cs               # Subject model
├── Answer.cs                # Answer model
│
├── Questions/
│   ├── Question.cs          # Base abstract question class
│   ├── ChooseOneQuestion.cs
│   ├── ChooseAllQuestion.cs
│   ├── TrueOrFalseQuestion.cs
│   └── QuestionList.cs      # Manages loading/saving questions to file
│
├── Exams/
│   ├── Exam.cs              # Base exam class (shared logic)
│   ├── PracticalExam.cs     # Shows correct answers after each question
│   └── FinalExam.cs         # Hides answers, shows final score only
```

---

## ✅ Features

- 📚 Supports five subjects by default: English, Math, Computer, History, Geography.
- ✍️ Supports three question types:
  - True or False
  - Choose One
  - Choose All
- 🧠 Two exam types:
  - **Practical Exam**: shows the correct answer after each question.
  - **Final Exam**: hides correct answers until the end and displays final score.
- 🗂️ Loads questions from `.txt` files for each subject (e.g., `Math.txt`).
- ✍️ Automatically logs newly added questions to the corresponding file.

---

## ▶️ How to Run

1. Clone the repository or download the source code.
2. Build the project using Visual Studio or any compatible .NET CLI:
   ```bash
   dotnet build
   dotnet run
   ```
3. Follow the terminal prompts to:
   - Select a subject
   - Choose exam type
   - Answer the questions interactively

---

## 💡 Notes

- Each subject corresponds to a file (e.g., `Computer.txt`) that contains the question bank.
- You can prefill these files manually or modify the code to seed questions programmatically.
- The score is only calculated and shown in the **FinalExam** type.

---

## 📄 License

This project is open-source and available under the MIT License.