# 📱 Term Tracker — .NET MAUI Mobile App (WGU C971)

![Status](https://img.shields.io/badge/Status-In_Progress-blue?style=for-the-badge)
![MAUI](https://img.shields.io/badge/Mobile.NET-MAUI-blueviolet?style=for-the-badge&logo=.net)
![Platform](https://img.shields.io/badge/Target-Android%20%7C%20iOS-lightgrey?style=for-the-badge&logo=android&logoColor=green)

---

## 🧠 About the Project

**Term Tracker** is a mobile application built using **.NET MAUI (Multi-platform App UI)** as part of WGU’s **C971: Mobile Application Development Using C#**.

This app allows users (students) to:

- 📅 Track academic **terms**
- 📘 Organize **courses** by term
- ✅ Create and manage **assessments**
- 🛎️ Enable reminders and notifications
- 🎨 Navigate a modern UI with animated splash screen

> ⚠️ **This project is currently in development. Functionality and design are actively evolving.**

---

## 🔧 Tech Stack

| Feature                | Tech Used                  |
|------------------------|----------------------------|
| 🧩 UI Framework         | .NET MAUI (.NET 8)         |
| 🛠 Language             | C#                         |
| 🗃 Local Database       | SQLite + `sqlite-net-pcl` |
| 🎨 UI Design            | XAML                       |
| 📱 Emulator Tested On   | Android 11+                |
| 📁 Architecture         | MVVM                       |
| 🔄 Navigation           | Shell Routes               |

---

## 🎯 Key Features (in progress)

- ✅ Dashboard showing all forecasted terms
- ✅ Add/Edit/Delete Terms with date range & weeks remaining
- ✅ Course management per term (status, notes, notifications)
- ✅ Assessment tracking (Objective/Performance types)
- ✅ SQLite database with seeding on launch
- ✅ Animated landing splash screen with graduation-themed icons
- 🔜 Dark Mode toggle & calendar-based reminders

---

## 🚀 Getting Started

### Prerequisites

- Visual Studio 2022 with `.NET MAUI` workload
- Android SDK / Emulator
- NuGet packages installed:
  - `sqlite-net-pcl`
  - `CommunityToolkit.Mvvm`
  - `Plugin.LocalNotifications`

### Run the App

```bash
git clone https://github.com/YOUR_USERNAME/term-tracker
cd term-tracker
