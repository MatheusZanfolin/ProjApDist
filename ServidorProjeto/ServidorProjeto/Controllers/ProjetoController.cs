using ServidorProjeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServidorProjeto.Controllers
{
    [RoutePrefix("api/projetos")]
    public class ProjetoController : ApiController
    {
        static readonly ProjetoRepositorio repositorio = new ProjetoRepositorio();

        [AcceptVerbs("GET")]
        [Route("GetTodosOsProjetos")]
        public IEnumerable<Projeto> TodosOsProjetos()
        {
            return repositorio.TodosOsProjetos();
        }
    }
}
