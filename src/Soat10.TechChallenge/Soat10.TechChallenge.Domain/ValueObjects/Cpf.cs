using Soat10.TechChallenge.Domain.Base;

namespace Soat10.TechChallenge.Domain.ValueObjects
{
    public class Cpf : ValueObject
    {
        public string Number { get; private set; }

        public Cpf(string numero)
        {
            Number = numero;
        }

        // Para o EF
        protected Cpf() { }

        public bool Validar()
        {
            if (Number.Length > 11)
                return false;

            while (Number.Length != 11)
                Number = '0' + Number;

            var igual = true;
            for (var i = 1; i < 11 && igual; i++)
                if (Number[i] != Number[0])
                    igual = false;

            if (igual || Number == "12345678909")
                return false;

            var numeros = new int[11];

            for (var i = 0; i < 11; i++)
                numeros[i] = int.Parse(Number[i].ToString());

            var soma = 0;
            for (var i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            var resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;
            for (var i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }
    }
}
