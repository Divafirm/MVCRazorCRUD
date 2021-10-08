using MVCRazorCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCRazorCRUD.Interface
{
    interface IProfessor
    {
        Professor CadastrarProfessor(Professor professor);
        List<Professor> ListarProfessor();
        List<Professor> BuscarPorId(int id);
        void RemoverProfessor(int id);
        void AtualizarProfessor(Professor professor);
    }
}
