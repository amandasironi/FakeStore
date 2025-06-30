using FakeStore.Domain.Entities;
using FakeStore.Application.Interfaces;

namespace FakeStore.Application.Services;

public class UserService(IHttpService httpService) : IUserService
{
    private readonly string baseURL = "https://fakestoreapi.com/users/";
    private readonly IHttpService _httpService = httpService;

    public async Task<List<User>> GetAllUsers()
    {
        return await _httpService.GetAsync<List<User>>(baseURL);
    }

    public async Task<User> GetUserById(int userId)
    {
        return await _httpService.GetAsync<User>(baseURL + userId);
    }

    public async Task<User> InsertUser(User user)
    {
        return await _httpService.PostAsync<User>(baseURL, user);
    }

    public async Task<User> UpdateUser(User user)
    {
        return await _httpService.PutAsync<User>(baseURL, user);
    }

    public async void DeleteUser(int userId)
    {
        await _httpService.DeleteAsync(baseURL + userId);
    }
}