using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quiz.Data;
using Quiz.Services;
using System;
using System.IO;

namespace Quiz.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var quizService = serviceProvider.GetService<IQuizService>();
            var quiz = quizService.GetQuizById(1);

            Console.WriteLine(quiz.Title);

            foreach (var question in quiz.Questions)
            {
                Console.WriteLine(question.Title);

                foreach (var answer in question.Answers)
                {
                    Console.WriteLine(answer.Title);
                }
            }

            /*var questionService = serviceProvider.GetService<IQuestionService>();
            questionService.Add("What is Entity Framework Core?", 1);*/

            /*var answerService = serviceProvider.GetService<IAnswerService>();
            answerService.Add("It is a MicroORM", 0, false, 1);*/

            /*var userAnswerService = serviceProvider.GetService<IUserAnswerService>();
            userAnswerService.AddUserAnswer("54bd0a0d-ebe4-487e-9871-ecccbf6a0378", 1, 1, 2);*/
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options =>
                 options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddTransient<IQuizService, QuizService>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<IAnswerService, AnswerService>();
            services.AddTransient<IUserAnswerService, UserAnswerService>();

        }
    }
}
