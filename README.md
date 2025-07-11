# BodyCheck Student Tracker

A comprehensive student body check tracking application built with ASP.NET Core 9.0, featuring a separate Web API backend and MVC frontend for managing student physical measurements.

## 🚀 Live Demo
[![Live Demo](https://img.shields.io/badge/Live%20Demo-Visit%20App-blue?style=for-the-badge&logo=render)](https://bodycheckpro-student.onrender.com)

### 🔗 Service URLs
- **Frontend (MVC)**: https://bodycheckpro-student.onrender.com
- **Backend (API)**: https://bodycheckpro-student-webapi.up.railway.app
- **API Endpoint**: https://bodycheckpro-student-webapi.up.railway.app/api/BodyCheck

## Project Architecture

```
bodycheck-student-tracker/
├── backend/          # ASP.NET Core Web API (BodyCheckWebAPI)
├── frontend/         # ASP.NET Core MVC Client (BodyCheckMVCWebAPIClient)
└── README.md
```

## Features

- **Student Management**: Complete CRUD operations for student records
- **Physical Measurements**: Track height (cm) and weight (kg) for each student
- **Image Storage**: Upload and store student photos with measurements
- **RESTful API**: Full API endpoints for external integration
- **Responsive UI**: Bootstrap-based web interface
- **Data Persistence**: SQLite database with Entity Framework Core
- **Error Handling**: Comprehensive error handling with user feedback

## Technology Stack

### Backend (Web API)
- **Framework**: ASP.NET Core 9.0
- **Database**: SQLite with Entity Framework Core 9.0
- **ORM**: Entity Framework Core with MySQL support
- **API Documentation**: Swagger/OpenAPI integration
- **Architecture**: RESTful API with proper HTTP status codes

### Frontend (MVC Client)
- **Framework**: ASP.NET Core MVC 9.0
- **HTTP Client**: HttpClientFactory for API communication
- **UI Framework**: Bootstrap with jQuery
- **Database**: Local SQLite with Entity Framework Core
- **Styling**: Custom CSS with responsive design

## Database Schema

### BodyCheckViewModel
- **Id**: Primary key (int)
- **StudentId**: Student identifier (string, nullable)
- **Firstname**: Student's first name (required string)
- **Lastname**: Student's last name (required string)
- **HeightCm**: Height in centimeters (float)
- **WeightKg**: Weight in kilograms (float)

## API Endpoints

### Backend API Routes
- `GET /api/bodycheck` - Retrieve all body check records
- `GET /api/bodycheck/{id}` - Retrieve specific record by ID
- `POST /api/bodycheck` - Create new body check record
- `PUT /api/bodycheck` - Update existing record
- `DELETE /api/bodycheck/{id}` - Delete record by ID

### Frontend MVC Routes
- `GET /BodyCheck` - Display all records
- `GET /BodyCheck/Create` - Create new record form
- `POST /BodyCheck/Create` - Submit new record
- `GET /BodyCheck/Edit/{id}` - Edit record form
- `POST /BodyCheck/Edit` - Submit edited record
- `GET /BodyCheck/Delete/{id}` - Delete confirmation
- `POST /BodyCheck/Delete` - Confirm deletion

## Getting Started

### Prerequisites
- .NET 9.0 SDK
- SQLite (included with .NET)

### Backend Setup
1. Navigate to the backend directory:
   ```bash
   cd backend
   ```
2. Restore dependencies:
   ```bash
   dotnet restore
   ```
3. Run the Web API:
   ```bash
   dotnet run
   ```
4. API will be available at `https://localhost:5001` with Swagger UI

### Frontend Setup
1. Navigate to the frontend directory:
   ```bash
   cd frontend
   ```
2. Restore dependencies:
   ```bash
   dotnet restore
   ```
3. Configure API endpoint in `Program.cs` if needed
4. Run the MVC application:
   ```bash
   dotnet run
   ```
5. Web application will be available at `https://localhost:5000`

## Configuration

### Backend Configuration
- **Database**: SQLite database file (`Year2024.db`)
- **CORS**: Configured for frontend communication
- **Swagger**: Available in development environment

### Frontend Configuration
- **HttpClient**: Named client "BodyCheckApi" for API communication
- **API Base URL**: Configured via HttpClientFactory
- **Error Handling**: TempData for user feedback messages

## Deployment

### Current Architecture
- **Backend**: Deployed on Railway (https://bodycheckpro-student-webapi.up.railway.app)
- **Frontend**: Deployed on Render (https://bodycheckpro-student.onrender.com)
- **Database**: SQLite with automatic creation in both environments
- **CORS**: Configured for cross-origin communication between services

### Railway (Backend)
- Docker containerization via `Dockerfile`
- Railway configuration in `railway.json`
- Production environment variables
- Automatic restart policies
- Auto-deployment on GitHub push

### Render (Frontend)
- Docker-based deployment
- Automatic builds from GitHub
- Free tier hosting
- Auto-deployment on GitHub push
- Root directory configured for frontend folder

### Docker
Both applications include:
- Multi-stage Docker builds
- Production-optimized images
- Environment-specific configurations
- SQLite database initialization

## File Structure

### Backend Key Files
- `BodyCheckWebAPI.csproj` - Project configuration
- `Controllers/BodyCheckController.cs` - API endpoints
- `Models/BodyCheckViewModel.cs` - Data model
- `Data/BodyCheckDbContext.cs` - Database context
- `Program.cs` - Application configuration

### Frontend Key Files
- `BodyCheckMVC.csproj` - Project configuration
- `Controllers/BodyCheckController.cs` - MVC controller
- `Views/BodyCheck/` - Razor views (Index, Create, Edit, Delete)
- `wwwroot/` - Static files (CSS, JS, images)
- `Program.cs` - Application and HttpClient configuration

## Image Storage

Student photos are stored in `wwwroot/images/` with timestamp-based naming convention for uniqueness and organization.

## Error Handling

- **Backend**: Comprehensive try-catch blocks with appropriate HTTP status codes
- **Frontend**: User-friendly error messages via TempData
- **Validation**: Model validation with user feedback
- **API Communication**: Proper handling of HTTP response status codes

## Development Notes

- **Entity Framework**: Code-first approach with SQLite
- **HttpClient**: Factory pattern for efficient HTTP communication
- **JSON Serialization**: Case-insensitive property matching
- **Bootstrap**: Responsive design for mobile compatibility