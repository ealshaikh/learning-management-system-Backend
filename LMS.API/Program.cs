using Microsoft.AspNetCore.Authentication.JwtBearer;
using LMS.API.AutoMapperProfiles;
using LMS.Core.Repository;
using LMS.Core.Service;
using LMS.Infra.Repository;
using LMS.Infra.Service;
using AutoMapper;
using LMS.API.AutoMapperProfiles;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LMS.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(o =>
            {
                o.AddPolicy("policy", b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //every thing goes here
            builder.Services.AddScoped<IDbContext, DbContext>();
            builder.Services.AddScoped<IAdminRepository, AdminRepository>();
            builder.Services.AddScoped<IAdminService, AdminService>();

            builder.Services.AddAutoMapper(typeof(AdminMappingProfile));

            builder.Services.AddScoped<IAdminUserloginRepository, AdminUserloginRepository>();
            builder.Services.AddScoped<IAdminUserloginService, AdminUserLoginService>();

            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IStudentService, StudentService>();

            builder.Services.AddScoped<IStudentUserLoginRepository, StudentUserLoginRepository>();
            builder.Services.AddScoped<IStudentUserLoginService, StudentUserLoginService>();

            builder.Services.AddScoped<IPlanRepository, PlanRepository>();
            builder.Services.AddScoped<IPlanService, PlanService>();

            builder.Services.AddScoped<IRoleRepository, RoleRepositpry>();
            builder.Services.AddScoped<IRoleService, RoleService>();

            builder.Services.AddScoped<IStudentEnrollmentRepository, StudentEnrollmentRepository>();
            builder.Services.AddScoped<IStudentEnrollmentService, StudentEnrollmentService>();

            builder.Services.AddScoped<IUserSectionRepository, UserSectionRepository>();
            builder.Services.AddScoped<IUserSectionService, UserSectionService>();

            builder.Services.AddScoped<IStudentAssessmentRepository, StudentAssessmentRepository>();
            builder.Services.AddScoped<IStudentAssessmentService, StudentAssessmentService>();

            builder.Services.AddScoped<IUserCourseRepository, UserCourseRepository>();
            builder.Services.AddScoped<IUserCourseService, UserCourseService>();

            builder.Services.AddScoped<IAttendenceRepository, AttendenceRepository>();
            builder.Services.AddScoped<IAttendenceService, AttendenceService>();

            

            builder.Services.AddScoped<IAuthRepository, AuthRepository>();
            builder.Services.AddScoped<IAuthService, AuthService>();

            //Ayah 


            builder.Services.AddScoped<ICertificateRepository, CertificateRepository>();
            builder.Services.AddScoped<ICertificateService, CertificateService>();

            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<IContactRepository, ContactRepository>();

            builder.Services.AddScoped<IContactService, ContactService>();
            builder.Services.AddScoped<ICourseService, CourseService>();

            builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
            builder.Services.AddScoped<ITeacherService, TeacherService>();


            builder.Services.AddScoped<ICourseSectionRepository, CourseSectionRepository>();
            builder.Services.AddScoped<ICourseSectionService, CourseSectionService>();


            builder.Services.AddScoped<IExamRepository, ExamRepository>();
            builder.Services.AddScoped<IExamService, ExamService>();

            builder.Services.AddScoped<ICardRepository, CardRepository>();
            builder.Services.AddScoped<ICardService, CardService>();

            builder.Services.AddScoped<ISectionRepository, SectionRepository>();
            builder.Services.AddScoped<ISectionService, SectionService>();

            builder.Services.AddScoped<ITeacherUserLoginRepository, TeacherUserLoginRepository>();
            builder.Services.AddScoped<ITeacherUserLoginService, TeacherUserLoginService>();


            builder.Services.AddScoped<IUserCourseRepository, UserCourseRepository>();
            builder.Services.AddScoped<IUserCourseService, UserCourseService>();




            builder.Services.AddAuthentication(opt => {
                opt.DefaultAuthenticateScheme =
                JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme =
                JwtBearerDefaults.AuthenticationScheme;
            })

          .AddJwtBearer(options =>
          {
              options.TokenValidationParameters = new TokenValidationParameters
              {
                  ValidateIssuer = false, // Set to false if you don't want to validate issuer
                  ValidateAudience = false, // Set to false if you don't want to validate audience
                  ValidateLifetime = true,
                  ValidateIssuerSigningKey = true,
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345superSecretKey@345superSecretKey@345superSecretKey@345superSecretKey@345superSecretKey@345")),
                  ClockSkew = TimeSpan.Zero
              };

          });



            var app = builder.Build();

            

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseAuthorization();


            app.UseCors("policy");



            app.MapControllers();

            app.Run();
        }

   


    }
}