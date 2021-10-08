using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCRazorCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCRazorCRUD.Controllers
{
    // O controller define as rotas para acessar as views
    // É o controller quem recebe as requisições WEB
    [Route("Aluno")]
    public class AlunoController : Controller
    {
        //Agora vamos criar o método para receber uma ação
        // e encaminhar para a view
        Aluno alunoModel = new Aluno();
        public IActionResult Index()
        {
            ViewBag.ListaDeAlunos = alunoModel.ListarAluno();   
            return View();
        }
        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection formulario)
        {
            Aluno aluno = new Aluno();
            // Vamos receber o dados do formulário
            aluno.Nome = formulario["alunonome"];
            aluno.Email = formulario["alunoemail"];
            aluno.Endereco = formulario["alunoend"];
            aluno.Telefone = formulario["alunotel"];
            aluno.Escolaridade = formulario["alunoesc"];
            aluno.CadastrarAluno(aluno);
            return LocalRedirect("/");
        }
        [Route("Atualizar")]
        public IActionResult Atualizar (IFormCollection formulario)
        {
            Aluno aluno = new Aluno();
            // Vamos receber o dados do formulário
            aluno.Id = int.Parse(formulario["alunoId"]);
            aluno.Nome = formulario["alunoNome"];
            aluno.Email = formulario["alunoEmail"];
            aluno.Endereco = formulario["alunoEnd"];
            aluno.Telefone = formulario["alunoTel"];
            aluno.Escolaridade = formulario["alunoEsc"];
            aluno.AtualizarAluno(aluno);
            return LocalRedirect("/Aluno");
        }
        [Route("Cadastro")]
        public IActionResult Cadastro()
        {
            return View();
        }

        [Route("~/Aluno/{id}")]
        public IActionResult Remover(int id)
        {
            alunoModel.RemoverAluno(id);
            return LocalRedirect("/Aluno");
        }
        [Route("~/Aluno/Editar/{id}")]
        public IActionResult Editar(int id)
        {
            var listaRetornada = alunoModel.BuscarPorId(id);
            var alunoRetornado = listaRetornada.Find(aluno => aluno.Id == id);
            ViewBag.alunoRetornado = alunoRetornado;

            return View();
        }
    }
}
