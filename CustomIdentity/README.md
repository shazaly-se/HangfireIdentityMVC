📌 ASP.NET MVC Identity with Hangfire Email Background Jobs
# ✅ Features
ASP.NET MVC with custom Identity (Login, Register, Forgot/Reset Password)

SQL Server-backed Identity system

Background email sending using Hangfire

Razor views for all Identity flows

Secure token-based password reset

Clean structure using dependency injection and services

# 📂 Project Structure

/Controllers
    AccountController.cs
/Models
    ForgotPasswordVM.cs, ResetPasswordVM.cs, etc.
/Views/Account
    ForgotPassword.cshtml
    ForgotPasswordConfirmation.cshtml
    ResetPassword.cshtml
    ResetPasswordConfirmation.cshtml
/Services
    IEmailSender.cs
    EmailSender.cs
/Startup (Program.cs or Startup.cs)
/Data
    ApplicationDbContext.cs
#  🛠 Technologies
ASP.NET MVC (.NET 6 or later)

Entity Framework Core with SQL Server

Identity (customized)

Hangfire (background jobs)

Razor Views

Bootstrap (optional, for UI)

Dependency Injection

# 🚀 Getting Started
1. Clone the Repository
git clone https://github.com/your-username/your-repo-name.git
cd your-repo-name
2. Set Up SQL Server
Make sure SQL Server is running and update the connection string in appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=YourDbName;Trusted_Connection=True;MultipleActiveResultSets=true"
}
3. Apply Migrations

dotnet ef database update
4. Run the App
dotnet run

# 🔐 Identity Flow
/Account/Register — User Registration

/Account/Login — User Login

/Account/ForgotPassword — Request reset link (email sent via Hangfire)

/Account/ResetPassword — Set new password (token-based)
# 📧 Email Sender (Injected)
EmailSender implements IEmailSender and sends password reset emails.

Email is sent in the background using:
BackgroundJob.Enqueue<IEmailSender>(sender =>
    sender.SendEmailAsync(email, subject, htmlMessage));
# 🧰 Hangfire Setup
In Program.cs:
builder.Services.AddHangfire(x => 
    x.UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHangfireServer();
In app.Use... section:

app.UseHangfireDashboard();
Access dashboard at /hangfire
✔️ Status
✅ Identity working with SQL Server

✅ Email sending via Hangfire

✅ Razor UI for password reset flow

✅ Ready to deploy or extend
# 🔐 Optional: Secure Hangfire Dashboard
app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    Authorization = new[] { new MyDashboardAuthorizationFilter() }
});
# 📦 NuGet Packages
Install the following packages:
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Hangfire
dotnet add package Hangfire.AspNetCore
dotnet add package Hangfire.SqlServer
dotnet add package MailKit
# 🧪 Sample EmailSender.cs
public class EmailSender : IEmailSender
{
    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        // Send email using SMTP or MailKit
    }
}
# 👤 Author
Name:  Shazaly

Contact: shazaly.se@gmail.com

