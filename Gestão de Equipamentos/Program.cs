using System;

namespace Gestão_de_Equipamentos
{
    public class Equipamento
    {
        public string nome;
        public double preço;
        public string serie;
        public DateTime data;
        public string fabricante;

        //construtor
        public Equipamento(string nome, double preço, string serie, DateTime data, string fabricante)
        {
            this.nome = nome;
            this.preço = preço;
            this.serie = serie;
            this.data = data;
            this.fabricante = fabricante;
        }
    }

    public class Chamado
    {
        public string titulo;
        public string descriçao;
        public Equipamento equipamento;
        public DateTime abertura;

        public Chamado(string titulo, string descriçao, Equipamento equipamento, DateTime abertura)
        {
            this.titulo = titulo;
            this.descriçao = descriçao;
            this.equipamento = equipamento;
            this.abertura = abertura;
        }
    }

    internal class Program
    {
        static int registrosEquip = 0;
        static Equipamento[] estoqueEquip = new Equipamento[1000];
        static int registrosManutencao = 0;
        static Chamado[] chamadosManutencao = new Chamado[1000];
        static void Main(string[] args)
        {
            Teste();
            MenuPrincipal();
        }

        private static void Teste()
        {
            Equipamento novoEquip = new Equipamento("qualquer", 12, "423", new DateTime(1955, 02, 14), "viadossauro");
            estoqueEquip[registrosEquip++] = novoEquip;
            Chamado novoChamado = new Chamado("cigarro jr", "usar droga eh mt bom", novoEquip, new DateTime(2005, 04, 23));
            chamadosManutencao[registrosManutencao++] = novoChamado;
        }

        private static void MenuPrincipal()
        {
            string comando = " ";
            while (comando != "s")
            {

                Console.WriteLine("Gestão de Equipamentos");
                Console.WriteLine("\nDigite 1 para mostrar o menu de Equipamentos.");
                Console.WriteLine("Digite 2 para mostrar o menu de Chamados de Manutenção.");
                Console.WriteLine("Digite s para sair.");
                comando = Console.ReadLine().ToLower();

                switch (comando)
                {
                    case "1":
                        MostrarMenuEquipamentos();
                        break;
                    case "2":
                        MostrarMenuChamados();
                        break;
                    default:
                        Console.WriteLine("Comando Inválido!");
                        break;
                }
            }
        }

        private static void MostrarMenuChamados()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Digite 1 para registrar um chamado de manutenção.");
                Console.WriteLine("Digite 2 para visualizar um chamado de manutenção.");
                Console.WriteLine("Digite 3 para editar um chamado de manutenção.");
                Console.WriteLine("Digite 4 para excluir um chamado de manutenção.");
                string comando = Console.ReadLine();
                Console.Clear();

                switch (comando)
                {
                    case "1":
                        RegistrarChamado();
                        break;
                    case "2":
                        VisualizarChamados();
                        Console.ReadKey();
                        break;
                    case "3":
                        EditarChamado();
                        break;
                    case "4":
                        ExcluirChamado();
                        break;
                    default:
                        Console.WriteLine("\nComando inválido!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void MostrarMenuEquipamentos()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Digite 1 para registrar um equipamento novo.");
                Console.WriteLine("Digite 2 para visualizar um equipamento.");
                Console.WriteLine("Digite 3 para editar um equipamento.");
                Console.WriteLine("Digite 4 para excluir um equipamento.");
                string comando = Console.ReadLine();
                Console.Clear();

                switch (comando)
                {
                    case "1":
                        RegistrarEquipamento();
                        break;
                    case "2":
                        VisualizarEquipamentos();
                        Console.ReadKey();
                        break;
                    case "3":
                        EditarEquipamento();
                        break;
                    case "4":
                        ExcluirEquipamento();
                        break;
                    default:
                        Console.WriteLine("\nComando inválido!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void RegistrarEquipamento()
        {
            estoqueEquip[registrosEquip++] = MontarEquipamento();
        }

        private static void EditarEquipamento()
        {
            VisualizarEquipamentos();
            Console.Write("\nDigite o nº do equipamento: ");
            int numeroEquip = Convert.ToInt32(Console.ReadLine());
            estoqueEquip[numeroEquip - 1] = MontarEquipamento();
        }

        private static void ExcluirEquipamento()
        {
            VisualizarEquipamentos();
            Console.Write("\nDigite o nº do equipamento a ser excluído: ");
            int numEquip = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < chamadosManutencao.Length; i++)
            {
                if (chamadosManutencao[i].equipamento == estoqueEquip[numEquip - 1])
                {
                    Console.WriteLine("Este equipamento não pode ser excluído!");
                    return;
                }

            }
            estoqueEquip[numEquip - 1] = null;
        }

        private static void VisualizarEquipamentos()
        {
            for (int i = 0; i < estoqueEquip.Length; i++)
            {
                if (estoqueEquip[i] != null)
                {
                    Console.WriteLine($"Nº do equipamento: {i + 1}");
                    Console.WriteLine($"Nome do equipamento: {estoqueEquip[i].nome}");
                    Console.WriteLine($"Nº de série do equipamento: {estoqueEquip[i].serie}");
                    Console.WriteLine($"Nome do fabricante: {estoqueEquip[i].fabricante}");
                }
            }
        }

        private static Equipamento MontarEquipamento()
        {
            Console.Write("Digite um nome (mín. 6 letras): ");
            string nome = Console.ReadLine();
            if (nome.Length < 6)
            {
                Console.WriteLine("O nome precisa ter mais de 6 caracteres.");
                return MontarEquipamento();
            }

            Console.Write("Digite o preço de aquisição: R$ ");
            double preço = Convert.ToDouble(Console.ReadLine());
            Console.Write("Digite o número de série: ");
            string serie = Console.ReadLine();
            Console.Write("Digite a data de fabricação: ");
            DateTime data = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Digite o nome da fabricante: ");
            string fabricante = Console.ReadLine();

            Equipamento novoEquip = new Equipamento(nome, preço, serie, data, fabricante);
            return novoEquip;
        }

        private static void RegistrarChamado()
        {
            chamadosManutencao[registrosManutencao++] = MontarChamado();
        }

        private static Chamado MontarChamado()
        {
            Console.Write("\nDigite o título do chamado: ");
            string titulo = Console.ReadLine();
            Console.Write("Faça a descrição do chamado: ");
            string descriçao = Console.ReadLine();
            VisualizarEquipamentos();
            Console.Write("Selecione o equipamento digitando seu nº: ");
            int indiceEquip = Convert.ToInt32(Console.ReadLine()) - 1;
            Equipamento equipamento = estoqueEquip[indiceEquip];
            Console.Write("Digite a data de abertura do chamado: ");
            DateTime abertura = DateTime.Now;

            Chamado chamadoEquip = new Chamado(titulo, descriçao, equipamento, abertura);
            return chamadoEquip;
        }

        private static void VisualizarChamados()
        {
            for (int i = 0; i < chamadosManutencao.Length; i++)
            {
                if (chamadosManutencao[i] != null)
                {
                    Console.WriteLine($"Título do chamado: {chamadosManutencao[i].titulo}");
                    Console.WriteLine($"Nome do equipamento: {estoqueEquip[i].nome}");
                    Console.WriteLine($"Data de abertura: {chamadosManutencao[i].abertura}");
                    Console.WriteLine($"Dias em aberto: {DateTime.Now - chamadosManutencao[i].abertura}");
                }
            }

        }

        private static void ExcluirChamado()
        {
            VisualizarChamados();
            Console.Write("\nDigite o nº do chamado de manutenção a ser excluído: ");
            int numChamado = Convert.ToInt32(Console.ReadLine());
            chamadosManutencao[numChamado - 1] = null;
        }

        private static void EditarChamado()
        {
            VisualizarChamados();
            Console.Write("\nDigite o nº do chamado: ");
            int numeroChamado = Convert.ToInt32(Console.ReadLine());
            chamadosManutencao[numeroChamado - 1] = MontarChamado();
        }

    }
}
