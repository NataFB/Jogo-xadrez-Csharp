namespace tabuleiro
{
    internal class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] _Pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            _Pecas = new Peca[linhas, colunas];
        }

        public Peca peca(int linha, int coluna)
        {
            return _Pecas[linha, coluna];
        }

        public Peca peca(Posicao pos)
        {
            return _Pecas[pos.Linha, pos.Coluna];
        }

        public bool existePeca(Posicao pos)
        {
            ValidarPosicao(pos);
            return peca(pos) != null;
        }

        public void colocarPeca(Peca p, Posicao pos)
        {
            if(existePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            _Pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }

        public Peca retirarPeca(Posicao pos)
        {
           if(peca(pos) == null)
            {
                return null;
            }
            //se tiver peça na posição, retirar a peça e retornar a peça retirada
            Peca aux = peca(pos);
            aux.Posicao = null; // a peça retirada não tem mais posição no tabuleiro
            _Pecas[pos.Linha, pos.Coluna] = null; // a posição do tabuleiro fica vazia
            return aux;
        }

        public bool PosicaoValida(Posicao pos)
        {
           if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
            {
                return false;
            }
            return true;
        }

        public void ValidarPosicao(Posicao pos)
        {
            if (!PosicaoValida(pos))
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }
    }
}
