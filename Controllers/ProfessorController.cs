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
    [Route("Professor")]
    public class ProfessorController : Controller
    {
        //Agora vamos criar o método para receber uma ação
        // e encaminhar para a view
        Professor professorModel = new Professor();
        public IActionResult Index()
        {
            ViewBag.ListaDeProfessores = professorModel.ListarProfessor();   
            return View();
        }
        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection formulario)
        {
            Professor professor = new Professor();
            // Vamos receber o dados do formulário
            professor.Nome = formulario["professorNome"];
            professor.Email = formulario["professorEmail"];
            professor.Endereco = formulario["professorEnd"];
            professor.Telefone = formulario["professorTel"];
            professor.Cargo = formulario["professorCargo"];
            professor.CadastrarProfessor(professor);
            return LocalRedirect("/");
        }
        [Route("Atualizar")]
        public IActionResult Atualizar (IFormCollection formulario)
        {
            Professor professor = new Professor();
            // Vamos receber o dados do formulário
            professor.Id = int.Parse(formulario["professorId"]);
            professor.Nome = formulario["professorNome"];
            professor.Email = formulario["professorEmail"];
            professor.Endereco = formulario["professorEnd"];
            professor.Telefone = formulario["professorTel"];
            professor.Cargo = formulario["professorCargo"];
            professor.AtualizarProfessor(professor);
            return LocalRedirect("/Professor");
        }
        [Route("Cadastro")]
        public IActionResult Cadastro()
        {
            return View();
        }

        [Route("~/Professor/{id}")]
        public IActionResult Remover(int id)
        {
            professorModel.RemoverProfessor(id);
            return LocalRedirect("/Professor");
        }
        [Route("~/Professor/Editar/{id}")]
        public IActionResult Editar(int id)
        {
            var listaRetornada = professorModel.BuscarPorId(id);
            var professorRetornado = listaRetornada.Find(professor => professor.Id == id);
            ViewBag.professorRetornado = professorRetornado;

            return View();
        }
    }
}
