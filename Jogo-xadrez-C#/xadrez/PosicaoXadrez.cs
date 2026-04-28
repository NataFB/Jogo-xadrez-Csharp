using tabuleiro;

namespace xadrez
{
    internal class PosicaoXadrez
    {
        public char Coluna { get; set; }
        public int Linha { get; set; }
        public PosicaoXadrez(char coluna, int linha)
        {
            Coluna = coluna;
            Linha = linha;
        }

        public Posicao ToPosicao()
        {
            //obs: o "a" tem um valor inteiro associado, igual o b e assim por diante. Então , para converter a letra da coluna em um número, basta subtrair o valor inteiro de "a" do valor inteiro da letra da coluna. Assim consigo aplicar na matriz do jogo.
            return new Posicao(8 - Linha, Coluna - 'a');
        }

        public override string ToString()
        {
            return "" + Coluna + Linha;
        }   
    }
}
