// See https://aka.ms/new-console-template for more information
using DIO.Series;

SerieRepositorio repositorio = new SerieRepositorio();

string opcaoUsuario = ObterOpcaoUsuario();

while (opcaoUsuario.ToUpper() != "X")
{
    switch (opcaoUsuario)
    {
        case "1":
            ListarSeries();
            break;
        case "2":
            InserirSerie();
            break;
        case "3":
            AtualizarSerie();
            break;
        case "4":
            ExcluirSerie();
            break;
        case "5":
            VisualizarSerie();
            break;
        case "C":
            Console.Clear();
            break;
        default:
            throw new ArgumentOutOfRangeException();
    }
    opcaoUsuario = ObterOpcaoUsuario();
}

Console.Write("Obrigado por utilizar nossos serviços.");
Console.ReadLine();

void VisualizarSerie() {
    System.Console.Write("Digite o id da série: ");
    int indiceSerie = int.Parse(Console.ReadLine());

    var serie = repositorio.RetornaPorId(indiceSerie);

    System.Console.WriteLine(serie);
}

void ExcluirSerie() {
    System.Console.Write("Digite o id da série: ");
    int indiceSerie = int.Parse(Console.ReadLine());
    Serie serie = repositorio.RetornaPorId(indiceSerie);
    repositorio.Exclui(indiceSerie);

    System.Console.WriteLine($"Série excluída: {serie.retornaTitulo()}");
    
}

void AtualizarSerie(){
    System.Console.Write("Digite o id da série: ");
    int indiceSerie = int.Parse(Console.ReadLine());

    foreach (int i in Enum.GetValues(typeof(Genero)))
    {
        System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
    }
    System.Console.Write("Digite o gênero entre as opções acima: ");
    int entradaGenero = int.Parse(Console.ReadLine());

    System.Console.Write("Digite o título da série: ");
    string entradaTitulo = Console.ReadLine();

    System.Console.Write("Digite o ano de início da série: ");
    int entradaAno = int.Parse(Console.ReadLine());

    System.Console.Write("Digite a descrição da série: ");
    string entradaDescricao = Console.ReadLine();

    Serie atualizaSerie = new Serie(id: indiceSerie,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao
                                    );

    repositorio.Atualiza(indiceSerie, atualizaSerie);
    
}

void ListarSeries() {
    Console.WriteLine("Listar séries");

    var lista = repositorio.Lista();

    if(lista.Count == 0) {
        System.Console.WriteLine("Nenhuma série cadastrada.");
        return;
    }

    foreach (var serie in lista)
    {
        var excluido = serie.retornaExcluido();

        System.Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
    }
}

void InserirSerie() {
    System.Console.WriteLine("Inserir nova série");

    foreach (int i in Enum.GetValues(typeof(Genero)))
    {
        System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
    }
    Console.Write("Digite o gênero entre as opções acima: ");
    int entradaGenero = int.Parse(Console.ReadLine());

    Console.Write("Digite o título da série: ");
    string entradaTitulo = Console.ReadLine();

    Console.Write("Digite o ano de início da série: ");
    int entradaAno = int.Parse(Console.ReadLine());

    Console.Write("Digite a descrição da série: ");
    string entradaDescricao = Console.ReadLine();

    Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                genero: (Genero)entradaGenero,
                                titulo: entradaTitulo,
                                ano: entradaAno,
                                descricao: entradaDescricao
                                );
    repositorio.Insere(novaSerie);

}


string ObterOpcaoUsuario() {

    Console.WriteLine();
    Console.WriteLine("DIO Séries ao seu dispor!!!");
    Console.WriteLine("Informe a opção desejada: ");

    Console.WriteLine("1- Listar séries");
    Console.WriteLine("2- Inserir nova série");
    Console.WriteLine("3- Atualizar série");
    Console.WriteLine("4- Excluir série");
    Console.WriteLine("5- Visualizar série");
    Console.WriteLine("C- Limpar tela");
    Console.WriteLine("X- Sair");
    Console.WriteLine();

    string opcaoUsuario = Console.ReadLine().ToUpper();
    Console.WriteLine();
    return opcaoUsuario;

}
