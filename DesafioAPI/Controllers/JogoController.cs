using Microsoft.AspNetCore.Mvc;

[ApiController] // controller da API
[Route("api/[controller]")] // rota da API
public class JogoController : ControllerBase // herda a classe ControllerBase
{
    [HttpPost] // requisições POST
    public IActionResult Jogar([FromBody] JogadaRequest request) // método chamado qdo a requisição POST é feita para a rota 'api/Jogo'
    {
        // obtém as jogadas enviadas no corpo da requisição
        string jogada1 = request.Jogada1;
        string jogada2 = request.Jogada2;

        // string armazena resultado de quem venceu
        string resultado = VerificarResultado(jogada1, jogada2);

        // retorna uma resposta HTTP 200 (OK)
        return Ok(resultado);
    }

    // método privado que verifica quem venceu
    private string VerificarResultado(string jogada1, string jogada2)
    {
        // verifica se as jogadas são iguais
        if (jogada1 == jogada2)
        {
            return "Empate";
        }
        // verifica quem venceu o jogo
        else if ((jogada1 == "pedra" && (jogada2 == "tesoura" || jogada2 == "lagarto")) || // Pedra vence tesoura e lagarto
                 (jogada1 == "papel" && (jogada2 == "pedra" || jogada2 == "spock")) ||     // Papel vence pedra e Spock
                 (jogada1 == "tesoura" && (jogada2 == "papel" || jogada2 == "lagarto")) || // Tesoura vence papel e lagarto
                 (jogada1 == "lagarto" && (jogada2 == "papel" || jogada2 == "spock")) ||   // Lagarto vence papel e Spock
                 (jogada1 == "spock" && (jogada2 == "pedra" || jogada2 == "tesoura")))     // Spock vence tesoura e pedra
        {
            return "Jogador 1 venceu!"; 
        }
        else
        {
            return "Jogador 2 venceu!";
        }
    }
}

// modelo de dados da jogada
public class JogadaRequest
{
    public string Jogada1 { get; set; }
    public string Jogada2 { get; set; }
}
