using System;

namespace POnTheFly2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuInicial();

            void MenuInicial()
            {
                Console.WriteLine("--- Menu Inicial ---");
                Console.WriteLine("Digite a opção desejada:");
                Console.WriteLine("1- Menu Passageiro");
                Console.WriteLine("2- Menu Companhia Aerea");
                Console.WriteLine("3- Menu Voo");
                Console.WriteLine("4- Menu Aeronave");
                Console.WriteLine("5- Menu Venda");
                Console.WriteLine("6- Menu Passagem");
                Console.WriteLine("7- Menu Restritos");
                Console.WriteLine("8- Menu Bloqueadas");

                int opInicial = int.Parse(Console.ReadLine());

                if (opInicial == 1)
                {
                    MenuPassageiro();
                }

                else if (opInicial == 2)
                {
                    MenuCompanhiaAerea();
                }

                else if (opInicial == 3)
                {
                    MenuVoo();
                }

                else if (opInicial == 4)
                {
                    MenuAeronave();
                }

                else if (opInicial == 5)
                {
                    MenuVenda();
                }

                else if (opInicial == 6)
                {
                    MenuPassagem();
                }

                else if (opInicial == 7)
                {
                    MenuRestritos();
                }

                else if (opInicial == 8)
                {
                    MenuBloqueadas();
                }

                else
                {
                    while (true)
                    {
                        Console.WriteLine("Digite uma opção válida!");
                        opInicial = int.Parse(Console.ReadLine());
                    }
                }
            }

            void MenuPassageiro()
            {

                int opPassageiro;

                do
                {
                    Console.WriteLine("--- Menu Passageiro --");
                    Console.WriteLine("Digite a opção desejada: ");
                    Console.WriteLine("1-Cadastrar");
                    Console.WriteLine("2-Localizar");
                    Console.WriteLine("3-Editar");
                    Console.WriteLine("4-Restritos");
                    Console.WriteLine("5-Impressão por Registro");
                    Console.WriteLine("6-Menu Inicial");

                    opPassageiro = int.Parse(Console.ReadLine());

                    switch (opPassageiro)
                    {
                        case 1: //CadastrarPassageiro();
                            break;
                        case 2: //LocalizarPassageiro();
                            break;
                        case 3: //EditarPassageiro();
                            break;
                        case 4:
                            MenuRestritos();
                            break;
                        case 5: //ImpressãoPassageiro
                            break;
                        case 6:
                            MenuInicial();
                            break;
                    }
                } while (opPassageiro > 0 && opPassageiro < 7);
            }

            void MenuRestritos()
            {
                int opRestritos;
                do
                {
                    Console.WriteLine("--- Menu Restritos ---");
                    Console.WriteLine("Digite a opção desejada: ");
                    Console.WriteLine("1-Cadastrar");
                    Console.WriteLine("2-Localizar");
                    Console.WriteLine("3-Retirar");
                    Console.WriteLine("4-Menu Inicial");

                    opRestritos = int.Parse(Console.ReadLine());

                    switch (opRestritos)
                    {
                        case 1: //CadastrarRestritos();
                            break;
                        case 2: //LocalizarRestritos();
                            break;
                        case 3: //RetirarRestritos();
                            break;
                        case 4:
                            MenuPassageiro();
                            break;
                        case 5:
                            MenuInicial();
                            break;
                    }

                } while (opRestritos > 0 && opRestritos < 6);
            }

            void MenuCompanhiaAerea()
            {
                int opCia;

                do
                {
                    Console.WriteLine("--- Companhia Aerea ---");
                    Console.WriteLine("Digite a opção desejada: ");
                    Console.WriteLine("Digite a opção desejada!");
                    Console.WriteLine("1-Cadastrar");
                    Console.WriteLine("2-Localizar");
                    Console.WriteLine("3-Editar");
                    Console.WriteLine("4-Impressão por Registro");
                    Console.WriteLine("5-Bloqueadas");
                    Console.WriteLine("6-Menu Inicial");

                    opCia = int.Parse(Console.ReadLine());


                    switch (opCia)
                    {
                        case 1: //CadastrarCiaAerea();
                            break;
                        case 2: //LocalizarCiaAerea();
                            break;
                        case 3: //EditarCiaAerea();
                            break;
                        case 4: //ImpressaoCiaAerea();
                            break;
                        case 5:
                            MenuBloqueadas();
                            break;
                        case 6:
                            MenuInicial();
                            break;
                    }

                } while (opCia > 0 && opCia < 7);
            }

            void MenuBloqueadas()
            {
                int opBloq;

                do
                {
                    Console.WriteLine("--- Bloqueadas ---");
                    Console.WriteLine("Digite a opção desejada: ");
                    Console.WriteLine("1-Cadastrar");
                    Console.WriteLine("2-Localizar");
                    Console.WriteLine("3-Retirar");
                    Console.WriteLine("4-Menu Inicial");
                    opBloq = int.Parse(Console.ReadLine());

                    switch (opBloq)
                    {
                        case 1: //CadastrarBloqueadas();
                            break;
                        case 2: //LocalizarBloqueadas();
                            break;
                        case 3: //RetirarBloqueadas();
                            break;
                        case 4:
                            MenuPassageiro();
                            break;
                        case 5:
                            MenuCompanhiaAerea();
                            break;
                    }
                } while (opBloq > 0 && opBloq < 6);

            }

            void MenuVoo()
            {
                int opVoo;

                do
                {
                    Console.WriteLine("--- Menu Voo ---");
                    Console.WriteLine("Digite a opção desejada: ");
                    Console.WriteLine("1-Cadastrar");
                    Console.WriteLine("2-Localizar");
                    Console.WriteLine("3-Editar");
                    Console.WriteLine("4-Impressão por Registro");
                    Console.WriteLine("5-Menu Inicial");
                    opVoo = int.Parse(Console.ReadLine());

                    switch (opVoo)
                    {
                        case 1: //CadastrarVoo();
                            break;
                        case 2: //LocalizarVoo();
                            break;
                        case 3: //EditarVoo();
                            break;
                        case 4: //ImpressaoVoo();
                            break;
                        case 5:
                            MenuInicial();
                            break;
                    }

                } while (opVoo > 0 && opVoo < 6);
            }

            void MenuAeronave()
            {
                int opAeronave;
                do
                {
                    Console.WriteLine("--- Menu Aeronave ---");
                    Console.WriteLine("Digite a opção desejada: ");
                    Console.WriteLine("1-Cadastrar");
                    Console.WriteLine("2-Localizar");
                    Console.WriteLine("3-Editar");
                    Console.WriteLine("4-Impressão por Registro");
                    Console.WriteLine("5-Menu Inicial");

                    opAeronave = int.Parse(Console.ReadLine());

                    switch (opAeronave)
                    {
                        case 1: //CadastrarAeronave();
                            break;
                        case 2: //LocalizarAeronave();
                            break;
                        case 3: //EditarAeronave();
                            break;
                        case 4: //ImpressaoAeronave();
                            break;
                        case 5:
                            MenuInicial();
                            break;
                    }

                } while (opAeronave > 0 && opAeronave < 6);
            }

            void MenuPassagem()
            {
                int opPassagem;

                do
                {
                    Console.WriteLine("--- Menu Passagem ---");
                    Console.WriteLine("Digite a opção desejada: ");
                    Console.WriteLine("1-Cadastrar");
                    Console.WriteLine("2-Localizar");
                    Console.WriteLine("3-Editar");
                    Console.WriteLine("4-Impressão por Registro");
                    Console.WriteLine("5-Menu Inicial");

                    opPassagem = int.Parse(Console.ReadLine());

                    switch (opPassagem)
                    {
                        case 1: //CadastrarPassagem();
                            break;
                        case 2: //LocalizarPassagem();
                            break;
                        case 3: //EditarPassagem();
                            break;
                        case 4: //ImpressaoPassagem();
                            break;
                        case 5:
                            MenuInicial();
                            break;
                    }

                } while (opPassagem > 0 && opPassagem < 6);

            }

            void MenuVenda()
            {
                int opVenda;

                do
                {
                    Console.WriteLine("--- Menu Venda ---");
                    Console.WriteLine("Digite a opção desejada: ");
                    Console.WriteLine("1-Cadastrar");
                    Console.WriteLine("2-Localizar");
                    Console.WriteLine("3-Cancelar");
                    Console.WriteLine("4-Impressao por Registro");
                    Console.WriteLine("5-Item venda");
                    Console.WriteLine("6-Menu Inicial");

                    opVenda = int.Parse(Console.ReadLine());

                    switch (opVenda)
                    {
                        case 1: //CadastrarVenda();
                            break;
                        case 2: //LocalizarVenda();
                            break;
                        case 3: //CancelarVenda();
                            break;
                        case 4: //ImpressaoVenda();
                            break;
                        case 5:
                            MenuItemVenda();
                            break;
                    }

                } while (opVenda > 0 && opVenda < 6);
            }

            void MenuItemVenda()
            {
                int opItemVenda;

                do
                {
                    Console.WriteLine("---Menu Item Venda---");
                    Console.WriteLine("Digite a opção desejada: ");
                    Console.WriteLine("1-Cadastrar");
                    Console.WriteLine("2-Localizar");
                    Console.WriteLine("3-Editar");
                    Console.WriteLine("4- Menu Venda");

                    opItemVenda = int.Parse(Console.ReadLine());

                    switch (opItemVenda)
                    {
                        case 1: //CadastrarItemVenda();
                            break;
                        case 2: //LocalizarItemVenda();
                            break;
                        case 3: //EditarItemVenda(); 
                            break;
                        case 4:
                            MenuVenda();
                            break;

                    }

                } while (opItemVenda > 0 && opItemVenda < 5);
            }
        }
    }
}
