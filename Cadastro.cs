using System;
using System.Collections.Generic;
using System.Threading;

class Cadastro{

    public static List<string> nome = new List<string>();
    public static List<string> endereco = new List<string>();
    public static List<string> cpf = new List<string>();

    static void Main(){
        
        bool s = login();
        if(s){
            inicio();
        }else{
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Sistema fechando...");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);
        }
    }

    static void pausar(){
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("[ENTER] para continuar...");
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadLine();
    }

    static bool login(){
        int resp = 2;
        int tot = 3;
        do{
            Console.Clear();
            Console.WriteLine("---------------------");
            Console.WriteLine("        LOGIN        ");
            Console.WriteLine("---------------------");

            string user = "admin", senha = "admin";
            string u, s;

            Console.Write("Usuário: ");
            u = Console.ReadLine();
            Console.Write("Senha: ");
            Console.ForegroundColor = ConsoleColor.Black;
            s = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            if(user == u && senha == s){
                resp = 1;
            }else{
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Usuário ou senha incorretos!");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1000);
                tot--;
                if(tot == 0){
                    resp = 0;
                }
            }
        }while(resp != 1 && resp != 0);

        if(resp == 1){
            return true;
        }else{
            return false;
        }
    }

    static void inicio(){
        string opc;
        do{
            opc = menu();

            if(opc == "0"){
                bool s = sair();
                if(s){
                    Console.WriteLine("Saindo do programa... Volte sempre!");
                    pausar();
                }else{
                    opc = "999";
                }

            }else if(opc == "1"){
                cadastro();

            }else if(opc == "2"){
                relatorio();

            }else if(opc == "3"){
                pesquisar();

            }else if(opc == "4"){
                editar();

            }else if(opc == "5"){
                excluir();

            }else{
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opção inválida!");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1000);
            }
        }while(opc != "0");
    }

    static string menu(){
        Console.Clear();
        Console.WriteLine("---------------------");
        Console.WriteLine("        MENU         ");
        Console.WriteLine("---------------------");
        Console.WriteLine("[ 1 ] - CADASTRAR    ");
        Console.WriteLine("[ 2 ] - RELATORIO    ");
        Console.WriteLine("[ 3 ] - PESQUISAR    ");
        Console.WriteLine("[ 4 ] - EDITAR       ");
        Console.WriteLine("[ 5 ] - EXCLUIR    \n");
        Console.WriteLine("[ 0 ] - SAIR         ");
        Console.WriteLine("---------------------");

        Console.Write("Qual opção: ");
        string opc = Console.ReadLine().Trim();

        return opc;
    }

    static bool sair(){
        string s;
        Console.Write("Deseja sair realmente? [S/N]: ");
        s = Console.ReadLine().ToLower().Trim();
        while(s != "s" && s != "n"){
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Opção inválida!");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Digite S ou N: ");
            Console.ForegroundColor = ConsoleColor.White;
            s = Console.ReadLine().ToLower().Trim();
        }
        if(s == "s"){
            return true;
        }else{
            return false;
        }
    }
    static void cadastro(){

        Console.Clear();
        Console.WriteLine("---------------------");
        Console.WriteLine("      CADASTRAR      ");
        Console.WriteLine("---------------------");

        string n, e, c;
        Console.Write("Nome: ");
        n = Console.ReadLine();
        Console.Write("Endereço: ");
        e = Console.ReadLine();
        Console.Write("CPF: ");
        c = Console.ReadLine();

        nome.Add(n);
        endereco.Add(e);
        cpf.Add(c);

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("{0} cadastrado com sucesso!", n);
        Console.ForegroundColor = ConsoleColor.White;

        string s;
        Console.Write("Deseja cadastrar outra pessoa? [S/N]: ");
        s = Console.ReadLine().ToLower().Trim();
        while(s != "s" && s != "n"){
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Opção inválida!");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Digite S ou N: ");
            Console.ForegroundColor = ConsoleColor.White;
            s = Console.ReadLine().ToLower().Trim();
        }
        if(s == "s"){
            cadastro();
        }
    }

    static void relatorio(){
        Console.Clear();
        Console.WriteLine("---------------------");
        Console.WriteLine("      RELATORIO      ");
        Console.WriteLine("---------------------");
        for(int i = 0; i < nome.Count; i++){
            Console.WriteLine("Nome....: {0}", nome[i]);
            Console.WriteLine("Endereço: {0}", endereco[i]);
            Console.WriteLine("CPF.....: {0}", cpf[i]);
            Console.WriteLine("---------------------");
        }
        pausar();
    }

    static void pesquisar(){
        Console.Clear();
        Console.WriteLine("---------------------");
        Console.WriteLine("      PESQUISAR      ");
        Console.WriteLine("---------------------");

        string pesq;
        Console.Write("CPF: ");
        pesq = Console.ReadLine();

        if(cpf.Contains(pesq)){
            int p = cpf.IndexOf(pesq);
        
            Console.WriteLine("Nome....: {0}", nome[p]);
            Console.WriteLine("Endereço: {0}", endereco[p]);
            Console.WriteLine("CPF.....: {0}", cpf[p]);
            Console.WriteLine("---------------------");
            pausar();

        }else{
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("CPF não encontrado!");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);
        }  
    }

    static void editar(){
        Console.Clear();
        Console.WriteLine("---------------------");
        Console.WriteLine("       EDITAR        ");
        Console.WriteLine("---------------------");

        string pesq;
        Console.Write("CPF: ");
        pesq = Console.ReadLine();

        if(cpf.Contains(pesq)){
            int p = cpf.IndexOf(pesq);
            
            Console.WriteLine("Nome....: {0}", nome[p]);
            Console.WriteLine("Endereço: {0}", endereco[p]);
            Console.WriteLine("CPF.....: {0}", cpf[p]);
            Console.WriteLine("---------------------");

            string novo_nome, novo_endereco, novo_cpf;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Digite um novo valor ou ENTER para permanecer o atual");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Novo Nome: ");
            novo_nome = Console.ReadLine();
            Console.Write("Novo Endereço: ");
            novo_endereco = Console.ReadLine();
            Console.Write("Novo CPF: ");
            novo_cpf = Console.ReadLine();
            
            if(novo_nome == "" && novo_endereco == "" && novo_cpf == ""){
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Nenhum dado alterado!");
                Console.ForegroundColor = ConsoleColor.White;
            }else{
                if(novo_nome != ""){
                nome[p] = novo_nome;
                }
                if(novo_endereco != ""){
                    endereco[p] = novo_endereco;
                }
                if(novo_cpf != ""){
                    cpf[p] = novo_cpf;
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Dados atualizados com sucesso!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }else{
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("CPF não encontrado!");
            Console.ForegroundColor = ConsoleColor.White;
        }
        Thread.Sleep(1000);
    }

    static void excluir(){
        Console.Clear();
        Console.WriteLine("---------------------");
        Console.WriteLine("       EXCLUIR       ");
        Console.WriteLine("---------------------");

        string pesq;
        Console.Write("CPF: ");
        pesq = Console.ReadLine();

        if(cpf.Contains(pesq)){
            int p = cpf.IndexOf(pesq);
            
            Console.WriteLine("Nome....: {0}", nome[p]);
            Console.WriteLine("Endereço: {0}", endereco[p]);
            Console.WriteLine("CPF.....: {0}", cpf[p]);
            Console.WriteLine("---------------------");

            string s;
            Console.Write("Tem certeza que deseja excluir? [S/N]: ");
            s = Console.ReadLine().ToLower().Trim();

            while(s != "s" && s != "n"){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opção inválida!");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Digite S ou N: ");
                Console.ForegroundColor = ConsoleColor.White;
                s = Console.ReadLine().ToLower().Trim();
            }

            if(s == "s"){
                nome.RemoveAt(p);
                endereco.RemoveAt(p);
                cpf.RemoveAt(p);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Dados excluidos com sucesso!");
                Console.ForegroundColor = ConsoleColor.White;
            }else{
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Nenhum dado excluido!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }else{
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("CPF não encontrado!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        Thread.Sleep(1000);
    }
}
