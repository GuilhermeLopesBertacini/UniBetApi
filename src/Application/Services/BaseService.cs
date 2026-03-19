using UniBet.Application.Interfaces;
using UniBet.Domain.Exceptions;

namespace UniBet.Application.Services
{
  public abstract class BaseService<T> : IBaseService<T> where T : class
  {
    protected readonly IBaseRepository<T> _repository;
    public BaseService(IBaseRepository<T> repository)
    {
      _repository = repository;
    }
        public List<T> GetAll()
    {
      return _repository.GetAll();
    }

    public T GetById(Guid id)
    {
      T ?entity = _repository.GetById(id);
      if (entity == null) throw new NotFoundException($"T with Id {id} not found.");
      return entity;
    }

    public T Create(T entity)
    {
      return _repository.Create(entity);
    }

    public void Delete(Guid id)
    {
      T? entity = _repository.GetById(id) ?? throw new NotFoundException($"T with Id {id} not found.");
      _repository.Delete(entity);
    }
  }
}
