using CursosOnline.Data;
using CursosOnline.Data.Context;
using CursosOnline.Domain.Entities;
using Microsoft.EntityFrameworkCore;

var context = new AppDbContext();

bool executar = true;

while (executar)
{
    Console.Clear();
    Console.WriteLine("=== SISTEMA DE CURSOS ONLINE ===");
    Console.WriteLine("1 - Cadastrar Curso");
    Console.WriteLine("2 - Cadastrar Aluno");
    Console.WriteLine("3 - Matricular Aluno");
    Console.WriteLine("4 - Listar Cursos");
    Console.WriteLine("5 - Listar Alunos");
    Console.WriteLine("6 - Alunos com mais de uma matrícula");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha uma opção: ");

    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            CadastrarCurso(context);
            break;
        case "2":
            CadastrarAluno(context);
            break;
        case "3":
            MatricularAluno(context);
            break;
        case "4":
            ListarCursos(context);
            break;
        case "5":
            ListarAlunos(context);
            break;
        case "6":
            AlunosComMultiplasMatriculas(context);
            break;
        case "0":
            executar = false;
            break;
        default:
            Console.WriteLine("Opção inválida!");
            break;
    }

    Console.WriteLine("\nPressione ENTER para continuar...");
    Console.ReadLine();
}

static void AlunosComMultiplasMatriculas(AppDbContext context)
{
    var alunos = context.Alunos
        .Include(a => a.Matriculas)
        .Where(a => a.Matriculas.Count > 1)
        .ToList();

    foreach (var aluno in alunos)
    {
        Console.WriteLine($"{aluno.Nome} - {aluno.Matriculas.Count} matrículas");
    }
}


static void ListarAlunos(AppDbContext context)
{
    var alunos = context.Alunos.Where(a => a.Ativo).ToList();

    foreach (var aluno in alunos)
    {
        Console.WriteLine($"{aluno.Id} - {aluno.Nome} ({aluno.Email})");
    }
}


static void ListarCursos(AppDbContext context)
{
    var cursos = context.Cursos.ToList();

    foreach (var curso in cursos)
    {
        Console.WriteLine($"{curso.Id} - {curso.Titulo} ({curso.CargaHoraria}h)");
    }
}


static void MatricularAluno(AppDbContext context)
{
    Console.Write("ID do Aluno: ");
    int alunoId = int.Parse(Console.ReadLine());

    Console.Write("ID do Curso: ");
    int cursoId = int.Parse(Console.ReadLine());

    bool jaMatriculado = context.Matriculas
        .Any(m => m.AlunoId == alunoId && m.CursoId == cursoId);

    if (jaMatriculado)
    {
        Console.WriteLine("Erro: Aluno já matriculado nesse curso.");
        return;
    }

    var matricula = new Matricula
    {
        AlunoId = alunoId,
        CursoId = cursoId,
        DataMatricula = DateTime.Now
    };

    context.Matriculas.Add(matricula);
    context.SaveChanges();

    Console.WriteLine("Matrícula realizada com sucesso!");
}


static void CadastrarAluno(AppDbContext context)
{
    Console.Write("Nome: ");
    string nome = Console.ReadLine();

    Console.Write("Email: ");
    string email = Console.ReadLine();

    bool emailExiste = context.Alunos.Any(a => a.Email == email);
    if (emailExiste)
    {
        Console.WriteLine("Erro: Email já cadastrado.");
        return;
    }

    var aluno = new Aluno
    {
        Nome = nome,
        Email = email,
        Ativo = true
    };

    context.Alunos.Add(aluno);
    context.SaveChanges();

    Console.WriteLine("Aluno cadastrado com sucesso!");
}


static void CadastrarCurso(AppDbContext context)
{
    Console.WriteLine("Título: ");
    string titulo = Console.ReadLine();

    Console.WriteLine("Descrição: ");
    string descricao = Console.ReadLine();

    Console.WriteLine("Carga Horária: ");
    int carga = int.Parse(Console.ReadLine());

    var curso = new Curso
    {
        Titulo = titulo,
        Descricao = descricao,
        CargaHoraria = carga
    };

    context.Cursos.Add(curso);
    context.SaveChanges();

    Console.WriteLine("Curso cadastrado com sucesso!");
}