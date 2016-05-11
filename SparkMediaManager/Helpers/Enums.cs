﻿// Developed by: Gabriel Duarte
// 
// Created at: 30/04/2016 01:54

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using SparkMediaManager.Localization;

namespace SparkMediaManager.Helpers
{
    public static class Enums
    {
        public enum MetodoDeProcessamento
        {
            HardLink = 0,

            Copiar = 1
        }

        public enum IdiomaAplicacao
        {
            [Display(ResourceType = typeof(Label), Description = "Portugues")]
            Portugues,
            [Display(ResourceType = typeof(Label), Description = "Ingles")]
            Ingles
        }

        public static string GetDescricao(this Enum enuTipo)
        {
            Type type = enuTipo.GetType();
            string name = Enum.GetName(type, enuTipo);
            if (name == null)
            {
                return enuTipo.ToString();
            }

            FieldInfo field = type.GetField(name);

            if (field == null)
            {
                return enuTipo.ToString();
            }

            var attr =
                Attribute.GetCustomAttribute(field,
                                             typeof(DisplayAttribute)) as DisplayAttribute;
            return attr != null
                       ? attr.GetDescription()
                       : enuTipo.ToString();
        }

        public static Dictionary<Enum,string> GetListaValores(Type enuTipo)
        {
            Array arrValores = Enum.GetValues(enuTipo);

            return arrValores.Cast<Enum>().ToDictionary(objValor => objValor, objValor => objValor.GetDescricao());
        }
    }
}
