using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtAniversarioWebCore.Models;
using AtAniversarioWebCore.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtAniversarioWebCore.Controllers
{
    public class PessoaController : Controller
    {
        private PessoaRepository PessoaRepository { get; set; }

        public PessoaController(PessoaRepository pessoaRepository)
        {
            this.PessoaRepository = pessoaRepository;
        }
        // GET: Pessoa
        public ActionResult Index()
        {
            var model = this.PessoaRepository.GetAll();


            return View(model);
        }

        // GET: Pessoa/Details/5
        public ActionResult Details(int id)
        {
            var model = this.PessoaRepository.GetPessoaById(id);

            return View(model);
        }
        private static string ListaDeAniversarianteHoje(Pessoa aniversariante)
        {
            string retorno;
            DateTime aniversarioAnoCorrente = new DateTime(DateTime.Now.Year, aniversariante.DataNascimento.Month, aniversariante.DataNascimento.Day);
            if (aniversarioAnoCorrente.Date > DateTime.Now.Date)
            {
                TimeSpan ts = aniversarioAnoCorrente.Date - DateTime.Now.Date;
                retorno = string.Format("Faltam {0} dias para seu aniversário.", ts.Days);
            }
            else
            {
                DateTime aniversarioProximoAno = new DateTime(DateTime.Now.Year + 1, aniversariante.DataNascimento.Month, aniversariante.DataNascimento.Day);
                TimeSpan ts = aniversarioProximoAno.Date - DateTime.Now.Date;
                retorno = string.Format("Faltam {0} dias para seu aniversário.", ts.Days);
            }

            return retorno;
        }

        [HttpGet]
        public ActionResult Search([FromQuery] string query)
        {
            var model = this.PessoaRepository.Search(query);

            return View("Index", model);
        }
        
        
        // GET: Pessoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pessoa pessoa)
        {
            try
            {
                this.PessoaRepository.Save(pessoa);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int id)
        {
            var model = this.PessoaRepository.GetPessoaById(id);

            return View(model);
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Pessoa model)
        {
            try
            {
                model.Id = id;
                this.PessoaRepository.Update(model);
                                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int id)
        {
            var model = this.PessoaRepository.GetPessoaById(id);
            return View(model);
        }

        // POST: Pessoa/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Pessoa model)
        {
            try
            {
                model.Id = id;
                this.PessoaRepository.Delete(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}