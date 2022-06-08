using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Oracle.ManagedDataAccess.Client;
using projeto_financeiro.Models;
using System.Data.OracleClient;
using System.IO;
using OfficeOpenXml;
using Microsoft.VisualBasic;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace projeto_financeiro.Models.Pessoa
{

    class ConexaoOracle
    {
        //conexão com base de teste
        //public string conexaoOracle = @"DATA SOURCE=(DESCRIPTION=(ADDRESS_LIST=
        //(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.1.29)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=tubdhmlg)));User Id=teste;Password=teste;";

        // conexão com base de produção
        public string conexaoOracle = @"DATA SOURCE=(DESCRIPTION =(ADDRESS_LIST =
        (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.1.10)(PORT = 1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME = tubdprd)));User Id = valenca;Password = valenca;";

        public OracleConnection conexaoOra;
        public OracleCommand Command;
        public OracleTransaction Transaction;



        public Pessoa Conectar(Pessoa pessoa)
        {
            //Pessoa pessoa1 = new Pessoa();
            conexaoOra = new OracleConnection(conexaoOracle);
            Command = conexaoOra.CreateCommand();
            Command.CommandText = @"select IdPessoa, acesso, usuario, perfil from tbl_pessoa where usuario = '" + pessoa.USUARIO + "'and senha = '" + pessoa.SENHA + "'";
            conexaoOra.Open();
            OracleDataReader dr = Command.ExecuteReader();
            dr.Read();

            if (dr.HasRows)
            {

                pessoa.IDPESSOA = Convert.ToInt32(dr["IDPESSOA"]);
                pessoa.ACESSO = dr["ACESSO"].ToString();
                pessoa.PERFIL = dr["PERFIL"].ToString();
            }
            else
            {
                pessoa.IDPESSOA = 0;
            }
            dr.Close();
            conexaoOra.Close();
            return pessoa;
        }

        public Pessoa Conectarhome(Pessoa pessoa)
        {
            //Pessoa pessoa1 = new Pessoa();
            conexaoOra = new OracleConnection(conexaoOracle);
            Command = conexaoOra.CreateCommand();
            Command.CommandText = @"select IdPessoa, acesso, usuario, perfil from tbl_pessoa where IdPessoa = " + pessoa.IDPESSOA + "";
            conexaoOra.Open();
            OracleDataReader dr = Command.ExecuteReader();
            dr.Read();

            if (dr.HasRows)
            {

                pessoa.IDPESSOA = Convert.ToInt32(dr["IDPESSOA"]);
                pessoa.ACESSO = dr["ACESSO"].ToString();
                pessoa.PERFIL = dr["PERFIL"].ToString();
            }
            else
            {
                pessoa.IDPESSOA = 0;
            }
            dr.Close();
            conexaoOra.Close();
            return pessoa;
        }
        public List<Planilha> Excel(string docu, Planilha planilha)
        {
            List<Planilha> planilhas = new List<Planilha>();
            conexaoOra = new OracleConnection(conexaoOracle);
            Command = conexaoOra.CreateCommand();
            Command.CommandText = @"select nn.nrnota, nn.idnfe from tnotasaida_nfepack nn where nn.nrnota IN("+docu+") ";
            conexaoOra.Open();
            OracleDataReader dr = Command.ExecuteReader();
            
            if (dr.HasRows)
            {
                while(dr.Read())
                {
                    Planilha planilha1 = new Planilha();
                    planilha1.idnfe = dr["IDNFE"].ToString();
                    planilha1.Documento = dr["NRNOTA"].ToString();
                    planilhas.Add(planilha1);
                }

            }
            dr.Close();
            conexaoOra.Close();
            return planilhas;   
        }
        
    }
}
