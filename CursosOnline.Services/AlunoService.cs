using CursosOnline.Domain.Entities;
using CursosOnline.Domain.Interfaces;

namespace CursosOnline.Services;

public class AlunoService
{
    private readonly IRepository<Aluno> _repository;

    public AlunoService(IRepository<Aluno> repository)
    {
        _repository = repository;
    }

    public void Cadastrar(Aluno aluno)
    {
        _repository.Add(aluno);
    }
}

