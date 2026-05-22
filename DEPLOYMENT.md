# ReadLog Application Deployment Guide

This document outlines the steps required to set up, install, and deploy the ReadLog Desktop Application on another machine.

---

## 1. System Requirements
* **Operating System:** Windows 10 or Windows 11
* **Runtime Environment:** .NET Desktop Runtime 6.0 / 8.0 (or matching your current project environment)
* **Database System:** Microsoft SQL Server Express LocalDB

## 2. Default Login Credentials
If authentication is enabled on the startup view:
* **Username / Email:** `admin@readlog.com` *(Change to match your test user)*
* **Password:** `password123`

---

## 3. Step-by-Step Installation Instructions
1. Extract the submission ZIP file to your local drive.
2. Ensure **SQL Server Express LocalDB** is running on the target machine.
3. Open the main directory and verify that the `Database` folder contains both `ReadLogDB.mdf` and `ReadLogDB_log.ldf`.

### Database Configuration (If Paths Change)
If you move the application build folder to a new path or a different computer:
1. Locate the `ReadLog.exe.config` file inside the compilation folder (`/bin/Debug/` or `/bin/Release/`).
2. Open it using any standard text editor (like Notepad).
3. Update the `AttachDbFilename` absolute path inside the connection string configuration to match the new location of your database `.mdf` file:

```xml
connectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\YOUR_NEW_PATH\Database\ReadLogDB.mdf;Integrated Security=True;"