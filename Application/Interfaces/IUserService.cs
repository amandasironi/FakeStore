using FakeStore.Domain.Entities;

namespace FakeStore.Application.Interfaces;

public interface IUserService
{
    public Task<List<User>> GetAllUsers();
    public Task<User> GetUserById(int userId);
    public Task<User> InsertUser(User user);
    public Task<User> UpdateUser(User user);
    public void DeleteUser(int userId);
}