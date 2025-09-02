# MyAcademyPortfolioProject

A personal portfolio web application with a simple admin panel, built with ASP.NET MVC 5 and Entity Framework 6 on .NET Framework 4.7.2.

## Features

- Public site (no login required)
  - Home sections via partials: Features, About, Services, Experience, Projects, Testimonials, Team, Skills, Contact
  - Projects grid with category filtering and GitHub links (lightbox for images)
  - Contact form posts messages to the database

- Admin panel (requires authentication)
  - CRUD for About, Services (with Active/Passive toggle), Skills, Experiences, Projects
  - Project management supports Category selection and GitHub URL
  - Global authorization enforced; public area explicitly allowed

## Tech Stack

- ASP.NET MVC 5, .NET Framework 4.7.2
- Entity Framework 6.5.1 (DbContext: `MyAcademyPortfolioProjectEntities`)
- Bootstrap, jQuery, Modernizr (bundled via `BundleConfig`)
- IIS Express

## Screens and Routes

- Public: `/Default/Index` (home) with partials:
  - `/Default/DefaultProjectPartial` (portfolio with filters)
  - `/Default/SendMessage` (contact)
- Admin: `/About`, `/Service`, `/Skill`, `/Experience`, `/Project`

Services support Active/Passive toggling:
- `/Service/MakeActive/{id}`
- `/Service/MakePassive/{id}`

## Getting Started

Prerequisites:
- Visual Studio 2022
- .NET Framework 4.7.2 Developer Pack
- SQL Server/LocalDB

Setup:
1. Clone the repository.
2. Open the solution in Visual Studio.
3. Restore NuGet packages and build the project:
   - __Build > Rebuild Solution__
4. Configure the connection string in `Web.config` (`MyAcademyPortfolioProjectEntities`) to your SQL Server/LocalDB.
5. Ensure the database schema exists with tables such as:
   - `TblAbouts`, `TblServices`, `TblSkills`, `TblExperiences`, `TblProjects`, `TblCategories`, `TblTestimonials`, `TblTeams`, `TblMessages`
6. Run the app:
   - Set `MyPortfolio` as Startup Project and __Debug > Start Debugging__
   - Default IIS Express SSL port: `https://localhost:44345/`

Note on authentication:
- `Global.asax` applies a global `AuthorizeAttribute`. Public pages are opened via `[AllowAnonymous]` on `DefaultController`. Integrate your preferred auth (e.g., ASP.NET Identity) to access admin controllers.

## Project Structure (high-level)

- Controllers: `DefaultController`, `AboutController`, `ServiceController`, `SkillController`, `ExperienceController`, `ProjectController`
- Views: Public partials under `Views/Default`, Admin views per entity
- App_Start: `BundleConfig` for CSS/JS bundling
- Models: Entity Framework context and entity classes

## Project Images 

- ![Home Page](https://via.placeholder.com/800x600.png?text=Home+Page)
- ![About Section](https://via.placeholder.com/800x600.png?text=About+Section)
- ![Services Section](https://via.placeholder.com/800x600.png?text=Services+Section)
- ![Contact Form](https://via.placeholder.com/800x600.png?text=Contact+Form)


## Project Video

https://github.com/user-attachments/assets/1a45198c-5838-47fd-bd33-7e3d82f18f46