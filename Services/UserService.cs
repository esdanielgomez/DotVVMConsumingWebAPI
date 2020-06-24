using DotVVM_APIConsume.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DotVVM_APIConsume.Services
{
    public class UserService
    {

        private readonly string URLbase = "https://localhost:5003/api/User";
        private string id;

        public async Task<List<UserListModel>> GetAllUsersAsync()
        {
            List<UserListModel> usersList = new List<UserListModel>();
            using (var httpClient = new HttpClient())
            {
                string URL = URLbase + "/GetUsers";
                HttpResponseMessage response = await httpClient.GetAsync(URL);
                string apiResponse = await response.Content.ReadAsStringAsync();
                usersList = JsonConvert.DeserializeObject<List<UserListModel>>(apiResponse).Select(
                    s => new UserListModel
                    {
                        Id = s.Id,
                        FirstName = s.FirstName,
                        LastName = s.LastName
                    }
                    ).ToList();
            }
            return usersList;
        }

        public async Task<UserDetailModel> GetUserByIdAsync(int Id)
        {
            string URL = URLbase + "/GetUserById?id=" + Id;
            UserDetailModel User = new UserDetailModel();

            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(URL);
                string apiResponse = await response.Content.ReadAsStringAsync();
                User = JsonConvert.DeserializeObject<UserDetailModel>(apiResponse);
            }
            return User;
        }

        public async Task InsertUserAsync(UserDetailModel user)
        {
            string URL = URLbase + "/InsertUser";
            
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(URL, content);
                string apiResponse = await response.Content.ReadAsStringAsync();       
            }
        }

        public async Task UpdateUserAsync(UserDetailModel user)
        {
            string URL = URLbase + "/UpdateUser";

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PutAsync(URL, content);
                string apiResponse = await response.Content.ReadAsStringAsync();
            }
        }

        public async Task DeleteUserAsync(int Id)
        {
            string URL = URLbase + "/DeleteUser/" + Id;

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(URL);
                string apiResponse = await response.Content.ReadAsStringAsync();
            }
        }
    }
}
