using UniBet.Application.Interfaces;
using UniBet.Domain.Entities;

namespace UniBet.Application.UseCases
{
  public class ChangeProfileUseCase
  {
    private readonly IUserRepository _userRepository;
    public ChangeProfileUseCase(IUserRepository userRepository)
    {
      this._userRepository = userRepository;
    }
        public async void Run(string firstName, string lastName, string email, Guid userID)
        {
            User ?user = _userRepository.GetById(userID);
            if (user == null)
            {
                throw new Exception("Invalid User");
            }

            user.ChangeProfile(firstName, lastName, email);
            _userRepository.Update(user);
        }
    }
}
