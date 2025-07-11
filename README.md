# BodyCheck Student Tracker

A full-stack web application for managing student physical measurements, built with ASP.NET Core 9.0 featuring separate Web API backend and MVC frontend.

## 🚀 Live Demo
[![Live Demo](https://img.shields.io/badge/Live%20Demo-Visit%20App-blue?style=for-the-badge&logo=render)](https://bodycheckpro-student.onrender.com)

**Frontend**: https://bodycheckpro-student.onrender.com  
**Backend API**: https://bodycheckpro-student-webapi.up.railway.app/api/BodyCheck

## ✨ Features

- **Student Management**: Complete CRUD operations for student records
- **Physical Measurements**: Track height (cm) and weight (kg)
- **Image Storage**: Upload and store student photos
- **RESTful API**: Full API endpoints for external integration
- **Responsive UI**: Bootstrap-based web interface

## 🛠️ Tech Stack

**Backend**: ASP.NET Core 9.0, C#, Entity Framework, SQLite, Swagger  
**Frontend**: ASP.NET Core MVC, Bootstrap, jQuery, HttpClient  
**Database**: SQLite with Entity Framework Core  
**Deployment**: Docker, Railway, Render  

## 📊 Database Schema

| Field | Type | Description |
|-------|------|-------------|
| Id | int | Primary key |
| StudentId | string | Student identifier |
| Firstname | string | Student's first name |
| Lastname | string | Student's last name |
| HeightCm | float | Height in centimeters |
| WeightKg | float | Weight in kilograms |

## 🔌 API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/bodycheck` | Get all records |
| GET | `/api/bodycheck/{id}` | Get specific record |
| POST | `/api/bodycheck` | Create new record |
| PUT | `/api/bodycheck` | Update existing record |
| DELETE | `/api/bodycheck/{id}` | Delete record |

## 🚀 Quick Start

### Prerequisites
- .NET 9.0 SDK

### Backend
```bash
cd backend
dotnet restore
dotnet run
```
API available at `https://localhost:5001`

### Frontend
```bash
cd frontend
dotnet restore
dotnet run
```
Web app available at `https://localhost:5000`

## 🌐 Deployment

- **Backend**: Railway with Docker containerization
- **Frontend**: Render with Docker deployment
- **Database**: SQLite with automatic creation
- **CI/CD**: Auto-deployment on GitHub push

## 📁 Project Structure

```
bodycheck-student-tracker/
├── backend/          # ASP.NET Core Web API
├── frontend/         # ASP.NET Core MVC Client
└── README.md
```

---

*Academic project for ICT325 Internet Systems Programming*