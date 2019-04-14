using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteDeveloper
{
    class MontaTrilha
    {

        int max = 0;
        int soma = 0;
        int indMax = 0;
        List<string> listaFormatada;
        StringBuilder texto = new StringBuilder();


        public void Manha(ref List<int> duracao, ref List<string> titulo, ref List<int> duracaoSelcionada, ref List<string> tituloSelcionado)
        {
            soma = 0;

            for (int i = 0; i < duracao.Count; i++)
            {
                if (soma == 180)
                    break;

                soma += duracao[i];
                duracaoSelcionada.Add(duracao[i]);
                tituloSelcionado.Add(titulo[i]);

                if (soma > 180)
                {
                    max = duracaoSelcionada.Max();
                    indMax = duracaoSelcionada.IndexOf(max);

                    soma -= max;
                    duracaoSelcionada.RemoveAt(indMax);
                    tituloSelcionado.RemoveAt(indMax);
                }
            }

            // REMOVE O QUE FOI USADO
            for (int i = 0; i < duracaoSelcionada.Count; i++)
            {
                duracao.Remove(duracaoSelcionada[i]);
                titulo.Remove(tituloSelcionado[i]);
            }
        }

        public void Tarde(ref List<int> duracao, ref List<string> titulo, ref List<int> duracaoSelcionada, ref List<string> tituloSelcionado)
        {
            soma = 0;

            for (int i = 0; i < duracao.Count; i++)
            {
                if (soma == 240)
                    break;

                soma += duracao[i];
                duracaoSelcionada.Add(duracao[i]);
                tituloSelcionado.Add(titulo[i]);

                if (soma > 240)
                {
                    max = duracaoSelcionada.Max();
                    indMax = duracaoSelcionada.IndexOf(max);

                    soma -= max;
                    duracaoSelcionada.RemoveAt(indMax);
                    tituloSelcionado.RemoveAt(indMax);
                }
            }

            // REMOVE O QUE FOI USADO
            for (int i = 0; i < duracaoSelcionada.Count; i++)
            {
                duracao.Remove(duracaoSelcionada[i]);
                titulo.Remove(tituloSelcionado[i]);
            }
        }

        public List<string> FormataSaidaManha(List<int> duracaoSelecionada, List<string> tituloSelecionado)
        {
            listaFormatada = new List<string>();
            TimeSpan horaInicial = new TimeSpan(9, 0, 0);

            texto.Append($"{horaInicial.ToString(@"hh\:mm")} ").Append(tituloSelecionado[0]).Append($" {duracaoSelecionada[0]}mim");
            listaFormatada.Add(texto.ToString());
            horaInicial = horaInicial.Add(new TimeSpan(0, duracaoSelecionada[0], 0));
            texto.Clear();
            for (int i = 1; i < duracaoSelecionada.Count; i++)
            {
                texto.Append($"{horaInicial.ToString(@"hh\:mm")} ").Append(tituloSelecionado[i]).Append($" {duracaoSelecionada[i]}mim");
                horaInicial = horaInicial.Add(new TimeSpan(0, duracaoSelecionada[i], 0));
                listaFormatada.Add(texto.ToString());
                texto.Clear();
            }
            texto.Append($"{horaInicial.ToString(@"hh\:mm")} ").Append("Almoço");
            listaFormatada.Add(texto.ToString());
            texto.Clear();

            return listaFormatada;
        }

        public List<string> FormataSaidaTarde(List<int> duracaoSelecionada, List<string> tituloSelecionado)
        {
            listaFormatada = new List<string>();
            TimeSpan horaInicial = new TimeSpan(13, 0, 0);

            texto.Append($"{horaInicial.ToString(@"hh\:mm")} ").Append(tituloSelecionado[0]).Append($" {duracaoSelecionada[0]}mim");
            listaFormatada.Add(texto.ToString());
            horaInicial = horaInicial.Add(new TimeSpan(0, duracaoSelecionada[0], 0));
            texto.Clear();
            for (int i = 1; i < duracaoSelecionada.Count; i++)
            {
                texto.Append($"{horaInicial.ToString(@"hh\:mm")} ").Append(tituloSelecionado[i]).Append($" {duracaoSelecionada[i]}mim");
                horaInicial = horaInicial.Add(new TimeSpan(0, duracaoSelecionada[i], 0));
                listaFormatada.Add(texto.ToString());
                texto.Clear();
            }
            texto.Append($"{horaInicial.ToString(@"hh\:mm")} ").Append("Evento de Networking");
            listaFormatada.Add(texto.ToString());
            texto.Clear();

            return listaFormatada;
        }
    }
}