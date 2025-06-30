using FakeStore.Domain.Entities;
using FakeStore.Web.ViewModels;

namespace FakeStore.Web.Mappers;

public static class UserViewModelMapper
{
    public static UserViewModel MapToViewModel(User user)
    {
        return new UserViewModel()
            {
                UserId = user.Id,
                FullName = user.Name.FirstName + " " + user.Name.LastName,
                Address = user.Address.Street + ", " + user.Address.Number + ". " + user.Address.City + ", " + user.Address.ZipCode + ".",
            };
    }
}