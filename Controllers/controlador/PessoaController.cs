using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projeto_financeiro.Models.Pessoa;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;


using Xamarin.Essentials;

namespace projeto_financeiro.Controllers.controlador
{
    public class PessoaController : Controller
    {
        //static object documento;
        public ActionResult Login(Pessoa pessoa)
        {
            if (TempData["Redirect"] != null)
            {
                TempData["sucesso1"] = "Senha alterada com sucesso !!!";
            }

            TempData.Remove("Pessoa");

            return View();
        }

        public ActionResult Entrar(Pessoa pessoa)
        {
            ConexaoOracle log = new ConexaoOracle();
            var login = log.Conectar(pessoa);

            if (login.IDPESSOA != 0)
            {
                //redirect para alterar a senha caso seja o primeiro acesso do usuario
                if (login.ACESSO == "0")
                {
                    TempData["Pessoa"] = login.IDPESSOA;
                    return RedirectToAction(nameof(UpdateSenha));
                }
                //TempData["Pessoa"] = login.IDPESSOA;
                var id = Convert.ToString(login.IDPESSOA);
                var U = login.USUARIO;
                //criptografa o id pessoa para passar na url
                string d = null;

                using (MD5 md5 = MD5.Create())
                {
                    //criptografia id
                    byte[] inputBytes = Encoding.UTF8.GetBytes(id);
                    byte[] hash = md5.ComputeHash(inputBytes);
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    for (int i = 0; i < hash.Length; i++)
                    {
                        sb.Append(hash[i].ToString("x2"));
                    }
                    d = sb.ToString();

                }
                TempData["USUARIO"] = login.USUARIO;
                //TempData["Perfil"] = login.PERFIL;
                ViewData["Exibir"] = "sim";
                return RedirectToAction(nameof(PessoaController.Home), new { id });

            }
            else
            {
                TempData["mensagemErro"] = "Usuario e/ou Senha Incorreto !!!";
                return RedirectToAction("Login", "Pessoa");
            }
            return View();
        }

        public ActionResult Home(Pessoa pessoa)
        {
            var idusuari = TempData.Peek("Pessoa");
            ViewData["exibir login"] = "sim";
            ViewData["Exibir"] = "sim";
            //string idcripto = Request.QueryString.Value.Split("?d=")[1];
            if (idusuari == null)
            {
                string idusuario = Request.Path.Value.Split("/Pessoa/Home/")[1];
                pessoa.IDPESSOA = Convert.ToInt32(idusuario);
            }
            else
            {

                pessoa.IDPESSOA = Convert.ToInt32(idusuari);
            }
            //Boolean compare = MD5.ReferenceEquals(idcripto, idusuario);


            //object USUARIO = TempData.Peek("USUARIO");

            ConexaoOracle log = new ConexaoOracle();
            var login = log.Conectarhome(pessoa);


            //object idusuario = TempData.Peek("Pessoa");
            //object perfil = TempData.Peek("Perfil");
            if (login.IDPESSOA > 0)
            {

                string idusuario1 = "" + login.IDPESSOA;
                //exibe ou não tag cadastro de usuario dependdo do idUsuario logado
                if (idusuario1 == "1" || idusuario1 == "50017" || idusuario1 == "50018" || idusuario1 == "50019")
                {
                    ViewData["CadastroUsuario"] = "sim";
                }

                TempData["Pessoa"] = idusuario1;

            }
            else
            {
                return RedirectToAction("Login", "Pessoa");
            }
            return View();
        }

        public ActionResult UpdateSenha()
        {

            return View();
        }

       
        public IActionResult Planilha(IFormFile formFile, Planilha planilha)
        {
            ViewData["exibir login"] = "sim";
            ViewData["Exibir"] = "sim";
            DataTable dt = new DataTable();
            //cria um caminho temporario o arquivo escolhido
            var caminho = Path.GetTempFileName();
            // salva o arquivo escolhido no caminho temporario criado
            using (var stream = System.IO.File.Create(caminho))
            {
                formFile.CopyTo(stream);
            }
            //captura o caminho do arquivo temporario e salva em uma tempdata
            string[] Linha = System.IO.File.ReadAllLines(@""+ caminho + "");
            List<string> documentos = new List<string>();
            //Neste For, vamos percorrer todas as linhas que foram lidas do arquivo CSV
            for (int i = 0; i < Linha.Length; i++)
            {
                //Aqui Estamos pegando a linha atual, e separando os campos               
                string[] campos = Linha[i].Split(Convert.ToChar(";"));
                var doc = campos[1];
               
                if (campos[1] != "Documento")
                {                                                  
                    var documento = doc.ToString().Substring(0, 6);
                    int documen = Convert.ToInt32(documento);
                    documentos.Add(documento);
                   
                }
                                         
                //dt.Rows.Add(campos);
            }
            string docum = JsonSerializer.Serialize(documentos);
            string docu = docum.Split("[")[1].Split("]")[0].Replace("\"", "'");
            ConexaoOracle docume = new ConexaoOracle();
            var login = docume.Excel(docu, planilha);

            return View(login);
        }

        public ActionResult Copiar(Planilha planilha)
        {
            string textData = "teste segurança";

            Clipboard.SetTextAsync(textData);
            return View();
        }

    }
}
