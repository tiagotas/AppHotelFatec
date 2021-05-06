using System;
using System.Collections.Generic;
using System.Text;

namespace AppHotelFatec.Model
{
    public class Hospedagem
    {
        private Quarto acomodacao;

        public Quarto Acomodacao 
        {
            get
            {
                return acomodacao;
            } 
            
            set
            {
                if (value == null)
                    throw new Exception("Por favor, selecione uma acomodação");

                acomodacao = value;
            }
        }


        public int QuantidadeAdultos { get; set; }
        public int QuantidadeCriancas { get; set; }
        public int QuantidadeDias 
        { 
            get
            {
                int total_dias = DataCheckout.Subtract(DataCheckin).Days;

                if (total_dias <= 0)
                    throw new Exception("A data do Check-out não pode ser antes da data do Check-in");
                                
                return total_dias;
            } 
        }

        public DateTime DataCheckin { get; set; }
        public DateTime DataCheckout { get; set; }
        public double ValorTotal 
        { 
            get
            {
                double valor_adulto = QuantidadeAdultos * Acomodacao.ValorDiariaAdulto;
                double valor_crianca = QuantidadeCriancas * Acomodacao.ValorDiariaCrianca;

                double valor_total_diaria = valor_adulto + valor_crianca;

                return valor_total_diaria * QuantidadeDias;
            }
        }
    }
}
