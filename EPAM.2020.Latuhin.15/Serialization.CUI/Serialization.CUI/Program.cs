using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Serialization.CUI
{
    class Program
    {
        static void Main()
        {
            var listWithModelsA = new List<object>
            {
                new Gates.BL.ViewModels.AccountViewModel
                {
                    Password = "*****", Role = "Project manager", UserName = "Admin"
                },

                new Gates.BL.ViewModels.BoardTaskViewModel() 
                {
                    AuthorLogin = "TestLogin", DeadlineDate = DateTime.Now, 
                    Description = "Description for task", Priority = "minor", 
                    Project = "Test", Status = "InWork", TaskId = 1, Title = "TestTitle"
                },

                new Gates.BL.ViewModels.ProjectViewModel()
                {
                    AuthorId = "1", CreateDate = DateTime.Now, Title = "TestTitle", ProjectId = 1
                }
            };

            var listWithModelsB = new List<object>
            {
                new Gates.BL.ViewModels.CommentViewModel() 
                {
                    CommentId = 1, Content = "Please, enter enter the title project", 
                    CreateDate = DateTime.Now, Login = "Nickname", TaskId = 1
                },

                new Gates.BL.ViewModels.TaskViewModel()
                {
                    AuthorId = "1", CreateDate = DateTime.Now, DeadlineDate = DateTime.Now, Description = "Test", ExecutorId = "1",
                    Priority = "Minor", ProjectId = 1, Status = "InWork", TaskId = 1, Title = "TestTitle"
                },

                new Gates.BL.ViewModels.UserViewModel()
                {
                    FirstName = "William", LastName = "Doe", Login = "Will"
                }
            };

            var serializedEntitiesA = JsonConvert.SerializeObject(listWithModelsA);
            var serializedEntitiesB = JsonConvert.SerializeObject(listWithModelsB);

            PrintSerializedEntities(serializedEntitiesA);
            PrintSerializedEntities(serializedEntitiesB);
        }

        private static void PrintSerializedEntities(string serializedEntities)
        {
            Console.WriteLine(serializedEntities);
        }


    }
}
