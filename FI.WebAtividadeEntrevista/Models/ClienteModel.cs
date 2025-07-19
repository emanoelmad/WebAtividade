﻿using FI.AtividadeEntrevista.DML;
using FI.WebAtividadeEntrevista.Language;
using FI.WebAtividadeEntrevista.Models;
using FI.WebAtividadeEntrevista.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAtividadeEntrevista.Models
{
    /// <summary>
    /// Classe de Modelo de Cliente
    /// </summary>
    public class ClienteModel
    {
        private List<BeneficiarioModel> _listaBeneficiario;

        public long Id { get; set; }

        /// <summary>
        /// CEP
        /// </summary>
        [Required]
        public string CEP { get; set; }

        /// <summary>
        /// Cidade
        /// </summary>
        [Required]
        public string Cidade { get; set; }

        /// <summary>
        /// E-mail
        /// </summary>
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Digite um e-mail válido")]
        public string Email { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        [Required]
        [MaxLength(2)]
        public string Estado { get; set; }

        /// <summary>
        /// Logradouro
        /// </summary>
        [Required]
        public string Logradouro { get; set; }

        /// <summary>
        /// Nacionalidade
        /// </summary>
        [Required]
        public string Nacionalidade { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// Sobrenome
        /// </summary>
        [Required]
        public string Sobrenome { get; set; }

        /// <summary>
        /// Telefone
        /// </summary>
        public string Telefone { get; set; }

        /// <summary>
        /// CPF
        /// </summary>
        [Required]
        [ValidationCPF(ErrorMessageResourceType = typeof(ValidateMsg), ErrorMessageResourceName = "MSG01")]
        public string CPF { get; set; }

        /// <summary>
        /// Beneficiarios
        /// </summary>
        [Required]
        public List<BeneficiarioModel> Beneficiarios
        {
            get => _listaBeneficiario = _listaBeneficiario == null ? new List<BeneficiarioModel>() : _listaBeneficiario;
            set => _listaBeneficiario = value;
        }
    }
}