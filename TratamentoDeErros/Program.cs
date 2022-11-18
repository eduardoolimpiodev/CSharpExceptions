using System;
using System.Data.Common;
using System.Globalization;
using System.Net.Http.Headers;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exception é algo que não deveria acontecer
            var arr = new int[3];

            try
            {
                //for (var index = 0; index < 10; index++)
                //{
                //   Console.WriteLine(arr[index]);
                //}
                Salvar("");
            } 
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                Console.WriteLine("Não encontrei o índice na lista");
            }

            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                Console.WriteLine("Falha ao cadastrar o texto");
            }
            catch (MinhaException ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.QuandoAconteceu);
                Console.WriteLine("Minha excecão aconteceu...");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                Console.WriteLine(ex.Message);
                Console.WriteLine("ops, algo deu errado!");
            }
            finally
            {
                Console.WriteLine("Chegou ao fim!");
            }
        }

        private static void Salvar(string texto)
        {
            if(string.IsNullOrEmpty(texto))
            {
                throw new ArgumentNullException("O texto não pode ser nulo ou vazio.");
                throw new MinhaException(DateTime.Now);
                throw new Exception("O texto não pode ser nulo ou vazio.");
            }
        }

        public class MinhaException : Exception
        {
            public MinhaException(DateTime date)
            {
                QuandoAconteceu = date;
            }

            public DateTime QuandoAconteceu { get; set; }
        }
    }
}